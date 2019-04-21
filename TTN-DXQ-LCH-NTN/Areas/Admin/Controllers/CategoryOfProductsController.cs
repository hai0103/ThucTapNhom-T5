using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTN_DXQ_LCH_NTN.Models;

namespace TTN_DXQ_LCH_NTN.Areas.Admin.Controllers
{
    public class CategoryOfProductsController : Controller
    {
        private PetLandModel db = new PetLandModel();

        // GET: Admin/CategoryOfProducts
        public ActionResult Index()
        {
            return View(db.CategoryOfProducts.ToList());
        }

        // GET: Admin/CategoryOfProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfProduct categoryOfProduct = db.CategoryOfProducts.Find(id);
            if (categoryOfProduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryOfProduct);
        }

        // GET: Admin/CategoryOfProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryOfProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryOfProductID,CategoryOfProductName,Total")] CategoryOfProduct categoryOfProduct)
        {
            if (ModelState.IsValid)
            {
                db.CategoryOfProducts.Add(categoryOfProduct);
                db.SaveChanges();
                return RedirectToAction("Index","CategoryOfProducts");
            }

            return View(categoryOfProduct);
        }

        // GET: Admin/CategoryOfProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfProduct categoryOfProduct = db.CategoryOfProducts.Find(id);
            if (categoryOfProduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryOfProduct);
        }

        // POST: Admin/CategoryOfProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryOfProductID,CategoryOfProductName,Total")] CategoryOfProduct categoryOfProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryOfProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryOfProduct);
        }

        // GET: Admin/CategoryOfProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfProduct categoryOfProduct = db.CategoryOfProducts.Find(id);
            if (categoryOfProduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryOfProduct);
        }

        // POST: Admin/CategoryOfProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryOfProduct categoryOfProduct = db.CategoryOfProducts.Find(id);
            db.CategoryOfProducts.Remove(categoryOfProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
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
