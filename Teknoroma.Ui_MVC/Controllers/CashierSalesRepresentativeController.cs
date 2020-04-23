using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teknoroma.CORE.Entity.Enum;
using Teknoroma.MODEL.Entity;
using Teknoroma.SERVICE.Option;

namespace Teknoroma.Ui_MVC.Controllers
{
    public class CashierSalesRepresentativeController : Controller
    {
        CustomerService customerService = new CustomerService();

        public Status? Statu { get; private set; }

        public ActionResult Index()
        {
            //Güncel Döviz Kurları Gösterme
            WebRequest request = HttpWebRequest.Create("https://xn--dviz-5qa.com/");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string gelen = reader.ReadToEnd();
            //USD
            string usdMetin = gelen.Substring(gelen.IndexOf("<td>ABD DOLARI</td>") + 19, gelen.Substring(gelen.IndexOf("<td>ABD DOLARI</td>") + 19).IndexOf("</tr>"));
            string[] usd = usdMetin.Split('>');
            string[] usdAlis = usd[1].Split('<');
            string finalAlisUSD = usdAlis[0];
            string[] usdSatis = usd[3].Split('<');
            string finalSatisUSD = usdSatis[0];
            string[] usdDeger = { finalAlisUSD, finalSatisUSD };
            ViewBag.USD = usdDeger;
            //Euro
            string euroMetin = gelen.Substring(gelen.IndexOf("<td>EURO</td>") + 13, gelen.Substring(gelen.IndexOf("<td>EURO</td>") + 13).IndexOf("</tr>"));
            string[] euro = euroMetin.Split('>');
            string[] euroAlis = euro[1].Split('<');
            string finalAlisEuro = euroAlis[0];
            string[] euroSatis = euro[3].Split('<');
            string finalSatisEuro = euroSatis[0];
            string[] euroDeger = { finalAlisEuro, finalSatisEuro };
            ViewBag.Euro = euroDeger;
            return View();
        }

        public ActionResult Customer()
        {
            TempData["Customer"] = customerService.SelectAll();
            return View();
        }
        [HttpPost]
        public ActionResult Customer(Customer customer)
        {
            EmptyInfo();
            customer.Statu = Status.Active;
            customerService.Add(customer);
            Saved();
            return RedirectToAction("Customer");
        }

        
        public ActionResult UpdateCustomer(int id)
        {
            Customer customer = customerService.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            customerService.Update(customer);
            return RedirectToAction("Customer");
        }
        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = customerService.GetById(id);
            customerService.Remove(customer);
            return RedirectToAction("Customer");
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

    }
}