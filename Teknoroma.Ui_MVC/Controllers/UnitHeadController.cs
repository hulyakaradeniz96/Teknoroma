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
    public class UnitHeadController : Controller
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        SupplierService supplierService = new SupplierService();
        EmployeeService employeeService = new EmployeeService();
        //Homepage=>Index
        public ActionResult Index()
        {
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
            return RedirectToAction("AddCategory");
        }

        
        public ActionResult AddProduct()
        {
            List<Category> categories = categoryService.GetAll();
            ViewBag.Category = categories;
            List<Supplier> suppliers = supplierService.GetAll();
            ViewBag.Supplier = suppliers;
            return View();
        }
        //todo:Product Category ve Supplier null geliyo??
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            EmptyInfo();
            //product.Category = categoryService.Db.Categories.Find((int)TempData["cat"]);
            //product.Supplier = supplierService.Db.Suppliers.Find(suppID);
            productService.Add(product);
            Saved();
            return RedirectToAction("AddProduct");
        }
        public PartialViewResult PartialCategory()
        {
            return PartialView(categoryService.GetAll());
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
            return RedirectToAction("AddSupplier");
        }

        public ActionResult AddEmployee()
        {
            List<EmployeeTitle> titles = new List<EmployeeTitle>(6);
            titles.Add(EmployeeTitle.AccountingRepresentative);
            titles.Add(EmployeeTitle.CashierSalesRepresentative);
            titles.Add(EmployeeTitle.MobileSalesRepresentative);
            titles.Add(EmployeeTitle.TechnicalServiceRepresentative);
            titles.Add(EmployeeTitle.UnitHead);
            titles.Add(EmployeeTitle.WarehouseRepresentative);
            ViewBag.Titles = titles;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            EmptyInfo();
            employeeService.Add(employee);
            Saved();
            return RedirectToAction("AddEmployee");
        }

        void EmptyInfo()
        {
            TempData["Info"] = string.Empty;
        }
        void Saved()
        {
            TempData["Info"] = "Saved.";
        }

        //Reports
        public ActionResult InventoryTracking()
        {
            //todo:categoryname ve suppliername'e ulaşamıyorum?
            return View(productService.GetAll());
        }
        public ActionResult SalesTracking()
        {
            //todo: hangi ürünler satılmış,
            //todo: En çok satılan 10 ürün, bu ürünlerin tedarikçisi ve bu ürünü alan Müşterileri kitlesi yaş, cinsiyet gibi
            //todo: En çok satılan 10 ürün ve bunların yanında en çok satılan ürünler.)
            return View(employeeService.GetAll());
        }
        public ActionResult SupplierActivities()
        {
            //todo: Supplier'ı group by yapıp 1 ay içerisindeki productların Quantitysini toplayıp tablea yazmam lazım
            return View(supplierService.GetAll());
        }
    }
}