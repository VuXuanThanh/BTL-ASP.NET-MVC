using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoNgoaiChinhHang.Areas.Admin.Models;
using PagedList;
using PagedList.Mvc;

namespace DoNgoaiChinhHang.Areas.Admin.Controllers
{
    public class CategoryBasesController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index(int? page)
        {
            var list = db.CategoryBases.Select(s => s);
            list = list.OrderBy(s => s.CategoryBaseID);
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View(list.ToPagedList(pageNumber,pageSize));
        }


        public JsonResult Create2(CategoryBase abc)
        {
            bool result = false;
            var u = db.CategoryBases.Where(x => x.CategoryBaseID == abc.CategoryBaseID).FirstOrDefault();
            if (u != null)
            {
                result = false;
            }
            else
            {
                db.CategoryBases.Add(abc);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Edit2(CategoryBase abc)
        {
            bool result = false;
            db.Entry(abc).State = EntityState.Modified;
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Create()
        {
            return View();
        }

        

        public JsonResult Delete(string id)
        {
            bool result = false;
            var u = db.CategoryBases.Where(x => x.CategoryBaseID == id).FirstOrDefault();

            if (u != null)
            {
                var categoryChilds = db.Categories.Where(p => p.CategoryBaseID == id).ToList();
                if (categoryChilds.Count > 0)
                {
                    result = false;
                }
                else
                {
                    db.CategoryBases.Remove(u);
                    db.SaveChanges();
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryBase categoryBase = db.CategoryBases.Find(id);
            if (categoryBase == null)
            {
                return HttpNotFound();
            }
            return View(categoryBase);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
