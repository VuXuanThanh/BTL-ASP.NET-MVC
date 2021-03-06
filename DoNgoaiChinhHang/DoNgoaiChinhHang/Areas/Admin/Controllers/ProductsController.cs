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
using System.IO;
namespace DoNgoaiChinhHang.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index(int? page)
        {
            var products = db.Products.Include(p => p.Category);
            products = products.OrderBy(s => s.ProductID);
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        //GET
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] files, Product abc)
        {
            
            try
            {
                 if (ModelState.IsValid)
                {
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerPath = Path.Combine(Server.MapPath("~/wwwroot/Images/" + abc.ProductID + "/")+InputFileName);
                            file.SaveAs(ServerPath);
                            ViewBag.UploadStatus = files.Count().ToString() + " files uploaded";
                        }
                    }
                }
                abc.Image = "~/wwwroot/Images/" + abc.ProductID + "/";
                db.Products.Add(abc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(abc);
            }
            
            
        }
        public JsonResult Create2(Product abc)
        {
            bool result = false;
            var u = db.Products.Where(x => x.ProductID == abc.ProductID).FirstOrDefault();
            if (u != null)
            {
                result = false;
            }
            else
            {

                db.Products.Add(abc);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Delete(string id)
        {
            bool result = false;
            var u = db.Products.Where(x => x.ProductID == id).FirstOrDefault();

            if (u != null)
            {
                var productChilds = db.OrderDetails.Where(p => p.ProductID == id).ToList();
                if (productChilds.Count > 0)
                {
                    result = false;
                }
                else
                {
                    db.Products.Remove(u);
                    db.SaveChanges();
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit2(Product abc)
        {
            bool result = false;
            db.Entry(abc).State = EntityState.Modified;
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
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
