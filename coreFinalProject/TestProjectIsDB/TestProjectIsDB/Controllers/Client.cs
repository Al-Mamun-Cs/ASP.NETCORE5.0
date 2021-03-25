using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestProjectIsDB.Attributes;
using TestProjectIsDB.Data;
using TestProjectIsDB.Models.Classes;
using TestProjectIsDB.Models.ViewModel;

namespace TestProjectIsDB.Controllers
{
    [Authorize]
    [Controller]
    public class ClientController : Controller 
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public ClientController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        [CustomAuthorize("Client", "Index")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string SearchString, string CurrentFilter, string sortOrder, int? Page)
        {
            ViewData["Create"] = RolesForMenu.GetMenu(User.Identity.Name, "Client", "Create");
            ViewData["Edit"] = RolesForMenu.GetMenu(User.Identity.Name, "Client", "Edit");
            ViewData["Delete"] = RolesForMenu.GetMenu(User.Identity.Name, "Client", "Delete");
            var applicationDbContext = _context.Clients.Include(c => c.Name);

            ViewBag.SortNameParam = string.IsNullOrEmpty(sortOrder) ? "name_des" : "";
            ViewBag.Salary = string.IsNullOrEmpty(sortOrder) ? "salary_des" : "";
            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;


            List<ClientListViewModel> ClientList = _context.Clients.Select(p => new ClientListViewModel
            {
                ClientID = p.ClientID,
                Name = p.Name,
                DoB = p.DoB,
                IsActive = p.IsActive,
                Email = p.Email,
                Phone = p.Phone,
                Salary = p.Salary,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                AccountTypeId = p.AccountTypeId,
                AccountName = p.Accounts.AccountName,
            }).ToList();            

            if (!string.IsNullOrEmpty(SearchString))
            {
                ClientList = ClientList.Where(n => n.Name.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_des":
                    ClientList = ClientList.OrderByDescending(n => n.Name).ToList();
                    break;
                case "salary_des":
                    ClientList = ClientList.OrderByDescending(n => n.Salary).ToList();
                    break;
                default:
                    ClientList = ClientList.OrderBy(n => n.Name).ToList();
                    break;
            }
            int PageSize = 100;
            int PageNumber = (Page ?? 1);
            return View("Index", ClientList.ToPagedList(PageNumber, PageSize));           
            
        }
        [CustomAuthorize("Client", "Create")]
        [HttpGet]        
        public ActionResult Create()
        {
            CreateClientModel crObj = new CreateClientModel();
            crObj.accountList = _context.Accounts.ToList();
            return View(crObj);
        }
        [CustomAuthorize("Client", "AddOrEdit")]
        //[HttpPost, ActionName("AddOrEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(CreateClientModel viewObj)
        {
            var result = false;

            string uniqueFile = ProcessUploadFile(viewObj);
            Client clObj = new Client();
            clObj.Name = viewObj.Name;
            clObj.DoB = viewObj.DoB;
            clObj.IsActive = viewObj.IsActive;
            clObj.Email = viewObj.Email;
            clObj.Phone = viewObj.Phone;
            clObj.Salary = viewObj.Salary;
            clObj.AccountTypeId = viewObj.AccountTypeId;
            clObj.ImageUrl = uniqueFile;
            if (ModelState.IsValid)
            {
                if (viewObj.ClientID == 0)
                {
                    _context.Clients.Add(clObj);
                    _context.SaveChanges();
                    result = true;
                }
                else
                {
                    clObj.ClientID = viewObj.ClientID;
                    _context.Entry(clObj).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.ClientID == 0)
                {
                    CreateClientModel crObj = new CreateClientModel();
                    crObj.accountList = _context.Accounts.ToList();
                    return View("Create", crObj);
                }
                else
                {
                    CreateClientModel crObj = new CreateClientModel();
                    crObj.accountList = _context.Accounts.ToList();
                    return View("Edit", crObj);
                }
            }

        }
        [HttpGet]
        [CustomAuthorize("Client", "Edit")]
        public ActionResult Edit(int id)
        {

            Client clObj = _context.Clients.SingleOrDefault(p => p.ClientID == id);
            CreateClientModel viewObj = new CreateClientModel();
            if (clObj != null)
            {
                viewObj.ClientID = clObj.ClientID;
                viewObj.Name = clObj.Name;
                viewObj.DoB = clObj.DoB;
                viewObj.IsActive = clObj.IsActive;
                viewObj.Email = clObj.Email;
                viewObj.Phone = clObj.Phone;
                viewObj.ImageName = clObj.ImageName;
                viewObj.Salary = clObj.Salary;
                viewObj.AccountTypeId = clObj.AccountTypeId;
                viewObj.accountList = _context.Accounts.ToList();
                viewObj.ImageUrl = clObj.ImageUrl;
            }
            return View(viewObj);
        }

        [HttpGet]
        [CustomAuthorize("Client", "Delete")]
        public ActionResult Delete(int id)
        {
            Client clObj = _context.Clients.SingleOrDefault(p => p.ClientID == id);
            CreateClientModel viewObj = new CreateClientModel();
            if (clObj != null)
            {
                viewObj.ClientID = clObj.ClientID;
                viewObj.Name = clObj.Name;
                viewObj.DoB = clObj.DoB;
                viewObj.IsActive = clObj.IsActive;
                viewObj.Email = clObj.Email;
                viewObj.Phone = clObj.Phone;
                viewObj.Salary = clObj.Salary;
                viewObj.AccountTypeId = clObj.AccountTypeId;
                viewObj.ImageUrl = clObj.ImageUrl;
            }

            return View(viewObj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Client clObj = _context.Clients.SingleOrDefault(p => p.ClientID == id);
            if (clObj != null)
            {
                _context.Clients.Remove(clObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clObj);
        }
        [CustomAuthorize("Client", "Details")]
        [HttpGet]
        public ActionResult Details(int ClientID)
        {
            Client clObj = _context.Clients.SingleOrDefault(p => p.ClientID == ClientID);
            ClientListViewModel viewObj = new ClientListViewModel();
            viewObj.ClientID = clObj.ClientID;
            viewObj.Name = clObj.Name;
            viewObj.DoB = clObj.DoB;
            viewObj.IsActive = clObj.IsActive;
            viewObj.Email = clObj.Email;
            viewObj.Phone = clObj.Phone;
            viewObj.Salary = clObj.Salary;
            viewObj.AccountTypeId = clObj.AccountTypeId;
            //viewObj.GradeName = playerObj.Grade.GradeName;
            viewObj.ImageUrl = clObj.ImageUrl;
            return PartialView("_DetailsRecord", viewObj);
        }
        private string ProcessUploadFile(CreateClientModel viewobj)
        {
            string uniqueFileName = null;
            var files = HttpContext.Request.Form.Files;
            foreach (var image in files)
            {
                if (image != null && image.Length > 0)
                {
                    var file = image;
                    var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            uniqueFileName = fileName;
                        }
                    }

                }
            }

            return uniqueFileName;
        }
    }
}
