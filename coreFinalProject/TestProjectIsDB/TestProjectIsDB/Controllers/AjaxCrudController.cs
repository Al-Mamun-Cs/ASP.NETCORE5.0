using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using TestProjectIsDB.Data;
using TestProjectIsDB.Models.Classes;
using TestProjectIsDB.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace TestProjectIsDB.Controllers
{
    [Authorize]
    public class AjaxCrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AjaxCrudController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult Index()
        {
            return View(_context.Clients.ToList());
        }
        [HttpGet]
        public JsonResult GetAllGetegory()
        {

            var dataList = _context.Accounts.Where(x => x.Status == 1).ToList();
            //var dataList = db.Categories.ToList();
            return Json(dataList);
        }
        [HttpGet]
        public JsonResult GetCategories()
        {
            //var dataList = _context.grades.ToList();
            var dataList = _context.Accounts.Select(x => new
            {
                AccountTypeId = x.AccountTypeId,
                AccountName = x.AccountName
            }).ToList();
            return Json(dataList);
        }

        
        public ActionResult AddNewProduct()
        {
            return View(_context.Clients.ToList());
        }
        [HttpPost]
        public ActionResult SaveData(CreateClientModel item)
        {
            string uniqueFile = ProcessUploadFile(item);
            Client item1;
            if (item.ClientID == 0)
            {
                item1 = new Client();
                item.ImageUrl = uniqueFile;
                item1.AccountTypeId = item.AccountTypeId;
                item1.DoB = item.DoB;
                item1.Name = item.Name;
                item1.Email = item.Email;
                item1.Phone = item.Phone;
                item1.IsActive = item.IsActive;
                item1.Salary = item.Salary;
                item1.ImageName = item.ImageName;
                item1.ImageUrl = item.ImageUrl;
                _context.Clients.Add(item1);
                _context.SaveChanges();
            }
            else
            {
                item1 = _context.Clients.SingleOrDefault(p => p.ClientID == item.ClientID);
                item.ImageUrl = uniqueFile;
                item1.ClientID = item.ClientID;
                item1.AccountTypeId = item.AccountTypeId;
                item1.DoB = item.DoB;
                item1.Name = item.Name;
                item1.Email = item.Email;
                item1.Phone = item.Phone;
                item1.IsActive = item.IsActive;
                item1.Salary = item.Salary;
                item1.ImageName = item.ImageName;
                item1.ImageUrl = item.ImageUrl;
                //db.players.Add(item);
                _context.SaveChanges();
            }
            var result = "Successfully Added";
            return Json(result);
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

        public JsonResult GetClientList()
        {
            var clList = _context.Clients.Where(p => p.ClientID > 0).Select(p => new CreateClientModel
            {
                ClientID = p.ClientID,
                Name = p.Name,
                IsActive = p.IsActive,
                DoB = p.DoB,
                Email = p.Email,
                Phone = p.Phone,
                Salary = p.Salary,
                ImageUrl = p.ImageUrl
            }).ToList();
            return Json(clList);
        }
        public JsonResult GetClientsById(int ClientID)
        {
            Client obj = _context.Clients.Where(p => p.ClientID == ClientID).SingleOrDefault();
            string value = "";
            value = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }
        public PartialViewResult GetClientDetails(int ClientID)
        {
            Client obj = _context.Clients.Where(p => p.ClientID == ClientID).SingleOrDefault();
            ClientListViewModel vObj = new ClientListViewModel();
            vObj.ClientID = obj.ClientID;
            vObj.Name = obj.Name;
            vObj.IsActive = obj.IsActive;
            vObj.DoB = obj.DoB;
            vObj.Email = obj.Email;
            vObj.Phone = obj.Phone;
            vObj.Salary = obj.Salary;
            vObj.ImageUrl = obj.ImageUrl;
            //vObj.GradeName = obj.Grade.GradeName;
            return PartialView("_ClientDetailsPartial", vObj);
        }
        public ActionResult deleteRecord(int Id)
        {
            bool result = false;
            Client obj = _context.Clients.Where(p => p.ClientID == Id).SingleOrDefault();
            if (obj != null)
            {
                _context.Clients.Remove(obj);
                _context.SaveChanges();
                result = true;
            }
            return View();
        }
        
    }
}
