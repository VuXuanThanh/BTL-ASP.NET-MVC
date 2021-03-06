using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoNgoaiChinhHang.Models;
using PagedList;

namespace DoNgoaiChinhHang.Controllers
{
    public class CategoriesController : Controller
    {
        private DoNgoaiChinhHangDB db = new DoNgoaiChinhHangDB();
        
        // GET: Categories
        public ActionResult GetProductByCategory(string categoryId, int? page)
        {
            /*ViewBag.listCategoryBase = db.CategoryBases.ToList();*/
            ViewBag.listCategoryBase = db.CategoryBases.ToList();
            ViewBag.listOrgin = db.Products.Select(x => x.Orgin).Distinct().ToList();
            var category = db.Categories.Where(s => s.CategoryID == categoryId).FirstOrDefault();
            ViewBag.category = category;
            ViewBag.categoryBase = category.CategoryBase;
            var productCategory = db.Products.Where(x => x.CategoryID == category.CategoryID).ToList();
            int pageSize = 9;
            if (page == null) page = 1;
            int pageNumber = (page ?? 1);
            return View(productCategory.ToPagedList(pageNumber, pageSize));
        }
    }
}