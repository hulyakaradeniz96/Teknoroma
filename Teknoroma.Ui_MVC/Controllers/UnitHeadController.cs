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
        
        
        public ActionResult Index()
        {
            List<Category> categories = categoryService.GetAll();
            TempData["CatList"] = categories;
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            EmptyInfo();
            categoryService.Add(category);
            TempData["Info"] = "Kaydetme Başarılı";
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
            TempData["Info"] = "Kaydetme Başarılı";
            return View();
        }
        void EmptyInfo()
        {
            TempData["Info"] = string.Empty;
        }
    }
}