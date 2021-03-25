using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectIsDB.Data;
using TestProjectIsDB.Models.Classes;
using TestProjectIsDB.Models.ViewModel;

namespace TestProjectIsDB.Controllers
{
    [Authorize]
    public class AccountTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult AccountList(int pageNumber = 1)
        {
            List<AccountType> accountList = _context.Accounts.ToList();
            return View(accountList);
        }
        [HttpGet]
        public ActionResult AddAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAccount(CreateAccountTypeViewModel viewobj)
        {
            AccountType acObj = new AccountType();
            acObj.AccountName = viewobj.AccountName;
            _context.Accounts.Add(acObj);
            _context.SaveChanges();
            RedirectToAction("AccountList");
            return RedirectToAction("AccountList");
        }
        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            AccountType acObj = _context.Accounts.SingleOrDefault(g => g.AccountTypeId == id);
            CreateAccountTypeViewModel acObj2 = new CreateAccountTypeViewModel();
            if (acObj != null)
            {
                // gradeObj = new Grade();
                acObj2.AccountName = acObj.AccountName;
            }

            return View(acObj);
        }
        [HttpPost]
        public ActionResult EditAccount(CreateAccountTypeViewModel viewObj)
        {
            AccountType acObj = new AccountType();
            acObj.AccountName = viewObj.AccountName;
            acObj.AccountTypeId = viewObj.AccountTypeId;
            _context.Entry(acObj).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("AccountList");
        }
        [HttpGet, HttpPost]
        public ActionResult DeleteAccount(int id)
        {
            AccountType acObj = _context.Accounts.SingleOrDefault(g => g.AccountTypeId == id);
            if (acObj != null)
            {
                _context.Accounts.Remove(acObj);
                _context.SaveChanges();
                return RedirectToAction("AccountList");
            }
            return View(acObj);
        }
    }
}
