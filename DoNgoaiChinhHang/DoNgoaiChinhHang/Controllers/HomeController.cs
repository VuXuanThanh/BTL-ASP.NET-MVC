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
            #region get Category
            var categoryBases = db.CategoryBases.ToList();
            
            
            #endregion
            return View(categoryBases);
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