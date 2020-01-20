using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teknoroma.MODEL.Entity;
using Teknoroma.SERVICE.Option;

namespace Teknoroma.Ui_MVC.Controllers
{
    public class UnitHeadController : Controller
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        SupplierService supplierService = new SupplierService();
        EmployeeService employeeService = new EmployeeService();
        //Homepage=>Index
        public ActionResult Index()
        {
            List<Category> categories = categoryService.GetAll();
            TempData["CatList"] = categories;
            return View();
        }
        //Adding Parts
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            EmptyInfo();
            categoryService.Add(category);
            Saved();
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            EmptyInfo();
            productService.Add(product);
            Saved();
            return View();
        }
        void EmptyInfo()
        {
            TempData["Info"] = string.Empty;
        }
        void Saved()
        {
            TempData["Info"] = "Saved.";
        }

        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            EmptyInfo();
            supplierService.Add(supplier);
            Saved();
            return View();
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            EmptyInfo();
            employeeService.Add(employee);
            Saved();
            return View();
        }
        //Reports
        public ActionResult InventoryTracking()
        {
            return View();
        }
    }
}