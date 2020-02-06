using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teknoroma.CORE.Entity.Enum;
using Teknoroma.MODEL.Entity;
using Teknoroma.MODEL.Entity.Expenses;
using Teknoroma.SERVICE.Option;
using Teknoroma.SERVICE.Option.Expenses;

namespace Teknoroma.Ui_MVC.Controllers
{
    public class UnitHeadController : Controller
    {
        //Services
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        SupplierService supplierService = new SupplierService();
        EmployeeService employeeService = new EmployeeService();
        OrderDetailService detailService = new OrderDetailService();
        PaymentOfEmployeeService paymentOfEmployee = new PaymentOfEmployeeService();
        TechnicalInfrastructureService technicalInfrastructure = new TechnicalInfrastructureService();
        OtherExpenseService expenseService = new OtherExpenseService();
        //Homepage=>Index
        public ActionResult Index()
        {
            TempData["Category"] = categoryService.SelectAll();
            TempData["Supplier"] = supplierService.SelectAll();
            return View();
        }
        //Category
        public ActionResult AddCategory()
        {
            ViewBag.Category = categoryService.SelectAll();
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
        public ActionResult UpdateCategory(int id)
        {
            Category category = categoryService.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryService.Update(category);
            return RedirectToAction("AddCategory");
        }
        public ActionResult DeleteCategory(int id)
        {
            Category category = categoryService.GetById(id);
            categoryService.Remove(category);
            return RedirectToAction("AddCategory");
        }
        //Product
        public ActionResult AddProduct()
        {
            ViewBag.Category = categoryService.SelectAll();
            ViewBag.Supplier = supplierService.SelectAll();
            TempData["Product"] = productService.SelectAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            EmptyInfo();
            productService.Add(product);
            Saved();
            return RedirectToAction("AddProduct");
        }
        public ActionResult UpdateProduct(int id)
        {
            TempData["Product"] = string.Empty;
            ViewBag.Category = categoryService.SelectAll();
            ViewBag.Supplier = supplierService.SelectAll();
            TempData["Product"] = productService.SelectAll();
            Product product = productService.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            productService.Update(product);
            return RedirectToAction("AddProduct");
        }
        public ActionResult DeleteProduct(int id)
        {
            Product category = productService.GetById(id);
            productService.Remove(category);
            return RedirectToAction("AddProduct");
        }

        //Supplier
        public ActionResult AddSupplier()
        {
            TempData["Supplier"] = supplierService.SelectAll();
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
        public ActionResult UpdateSupplier(int id)
        {
            Supplier supplier = supplierService.GetById(id);
            return View(supplier);
        }
        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            supplierService.Update(supplier);
            return RedirectToAction("AddSupplier");
        }
        public ActionResult DeleteSupplier(int id)
        {
            Supplier supplier = supplierService.GetById(id);
            supplierService.Remove(supplier);
            return RedirectToAction("AddSupplier");
        }
        //Employee
        public ActionResult AddEmployee()
        {
            ViewBag.Titles = Enum.GetValues(typeof(EmployeeTitle)).Cast<EmployeeTitle>().ToList();
            TempData["Employee"] = employeeService.SelectAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            EmptyInfo();
            if (employee.Title == EmployeeTitle.CashierSalesRepresentative)
            {
                if (employeeService.GetDefault(x => x.CashierID != null).Count == 0)
                {
                    employee.CashierID = 1;
                }
                else
                {
                    var cashierID = employeeService.GetDefault(x => x.CashierID != null).Last().CashierID++;
                    employee.CashierID = cashierID;
                }

            }

            employeeService.Add(employee);
            Saved();
            return RedirectToAction("AddEmployee");
        }

        public ActionResult UpdateEmployee(int id)
        {
            ViewBag.Titles = Enum.GetValues(typeof(EmployeeTitle)).Cast<EmployeeTitle>().ToList();
            Employee employee = employeeService.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            employeeService.Update(employee);
            return RedirectToAction("AddEmployee");
        }
        public ActionResult DeleteEmployee(int id)
        {
            Employee employee = employeeService.GetById(id);
            employeeService.Remove(employee);
            return RedirectToAction("AddEmployee");
        }
        //infoMethods
        void EmptyInfo()
        {
            TempData["Info"] = string.Empty;
        }
        void Saved()
        {
            TempData["Info"] = "Saved.";
        }

        //Reports
        public ActionResult InventoryTracking()//todo: Critic level düştüğünde uyarı vermeli.. suan sadece normal listeliyo
        {
            return View(productService.SelectAll());
        }
        public ActionResult SalesTracking()
        {
            //todo:System.NullReferenceException: Object reference not set to an instance of an object. hatası
            //todo:need to control after data.
            var employee = detailService.GetDefault(x => x.CreatedDate.Month == DateTime.Now.Month).AsQueryable().GroupBy(x => x.Order.Employee.ID).FirstOrDefault();
            //todo:Product =>  sum(Quantity) , Take(10) after order by Descending --Quantity;
            var products = detailService.GetDefault(x => x.CreatedDate.Month == DateTime.Now.Month).AsQueryable().GroupBy(x => x.Product.ID, x =>x.Quantity,(key, g) => new { Product = key, Quantity = g.ToList() }).ToList();


            TempData["Products"] = products;
            return View(employee);
    }
        public ActionResult SupplierActivities()
        {
            //todo:hata veriyo dict?
            //todo: Supplier'ı group by yapıp 1 ay içerisindeki productların Quantitysini toplayıp tablea yazmam lazım
            return View(supplierService.SelectAll());
        }

        public ActionResult ProductList()
        {//todo:içi boş
            return View(productService.GetAll());
        }

        public ActionResult Expenditures()
        {
            return View();
        }
        public PartialViewResult _EmployeePayment()
        {
            return PartialView(paymentOfEmployee.SelectAll());
        }
        public PartialViewResult _TechnicalInfrastucture()
        {
            return PartialView(technicalInfrastructure.SelectAll());
        }
        public PartialViewResult _OtherExpense()
        {
            return PartialView(expenseService.SelectAll());
        }
    }
}