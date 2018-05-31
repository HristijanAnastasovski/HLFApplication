using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HLFApplication.Models;

namespace HLFApplication.Controllers
{
    public class MultivitaminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Multivitamins
        public ActionResult Index()
        {
            var multivitamins = db.Multivitamins.ToList();
            var ratings = db.RatingMultivitamins.ToList();
            
            
            db.SaveChanges();
            return View(db.Multivitamins.ToList());
        }

        // GET: Multivitamins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multivitamin multivitamin = db.Multivitamins.Find(id);
            if (multivitamin == null)
            {
                return HttpNotFound();
            }
            var multivitamins = db.Multivitamins.ToList();
            var ratings = db.RatingMultivitamins.ToList();
           
            var comments = db.CommentMultivitamins.ToList();
            db.SaveChanges();
            return View(multivitamin);
        }

        [Authorize(Roles = "Member")]
        public ActionResult BuyProduct(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multivitamin multivitamin = db.Multivitamins.Find(id);
            if (multivitamin == null)
            {
                return HttpNotFound();
            }
            return View(multivitamin);
        }
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult AddQuantity(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multivitamin multivitamin = db.Multivitamins.Find(id);
            if (multivitamin == null)
            {
                return HttpNotFound();
            }


            AddQuantityToItem model = new AddQuantityToItem();
            model.ItemId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddQuantity(AddQuantityToItem model)
        {
            db.Multivitamins.Find(model.ItemId).NumberOfProductsInStock = db.Multivitamins.Find(model.ItemId).NumberOfProductsInStock + model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Multivitamins/Create
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Multivitamins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MultivitaminId,Name,Price,NumberOfProductsInStock,Description,ImageURL")] Multivitamin multivitamin)
        {
            if (ModelState.IsValid)
            {
                db.Multivitamins.Add(multivitamin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multivitamin);
        }

        // GET: Multivitamins/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multivitamin multivitamin = db.Multivitamins.Find(id);
            if (multivitamin == null)
            {
                return HttpNotFound();
            }
            return View(multivitamin);
        }

        // POST: Multivitamins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MultivitaminId,Name,Price,NumberOfProductsInStock,Description,ImageURL")] Multivitamin multivitamin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multivitamin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multivitamin);
        }

        // GET: Multivitamins/Delete/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multivitamin multivitamin = db.Multivitamins.Find(id);
            if (multivitamin == null)
            {
                return HttpNotFound();
            }
            return View(multivitamin);
        }

        // POST: Multivitamins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Multivitamin multivitamin = db.Multivitamins.Find(id);
            db.Multivitamins.Remove(multivitamin);
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
