using DoNgoaiChinhHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoNgoaiChinhHang.Controllers
{
    public class HomeController : Controller
    {
        private DoNgoaiChinhHangDB db = new DoNgoaiChinhHangDB();
        public ActionResult Index()
        {
            ViewBag.categoryBases = db.CategoryBases.ToList();
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}