using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teknoroma.CORE.Entity.Enum;
using Teknoroma.MODEL.Entity;
using Teknoroma.SERVICE.Option;

namespace Teknoroma.Ui_MVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeService employeeService = new EmployeeService();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee model)
        {
            var user = employeeService.Db.Employees.FirstOrDefault(x => x.Name == model.Name && x.LastName == model.LastName && x.Password == model.Password);
            Session["login"] = user;
            if (user.Title == EmployeeTitle.UnitHead) return RedirectToAction("Index", "UnitHead");
            else if (user.Title == EmployeeTitle.CashierSalesRepresentative) return RedirectToAction("Index", "CashierSalesRepresentative");
            else if (user.Title == EmployeeTitle.MobileSalesRepresentative) return RedirectToAction("Index", "MobileSalesRepresentative");
            else if (user.Title == EmployeeTitle.WarehouseRepresentative) return RedirectToAction("Index", "WarehouseRepresentative");
            else if (user.Title == EmployeeTitle.AccountingRepresentative) return RedirectToAction("Index", "AccountingRepresentative");
            else if (user.Title == EmployeeTitle.TechnicalServiceRepresentative) return RedirectToAction("Index", "TechnicalServiceRepresentative");
            else
            {
                ViewBag.UserError = "No user can be found.";
                return View();
            }
        }

    }
}