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
    public class RatingAccessoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RatingAccessories
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Index()
        {
            return View(db.RatingAccessories.ToList());
        }

        // GET: RatingAccessories/Details/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingAccessory ratingAccessory = db.RatingAccessories.Find(id);
            if (ratingAccessory == null)
            {
                return HttpNotFound();
            }
            return View(ratingAccessory);
        }

        // GET: RatingAccessories/Create
        [Authorize(Roles = "Member")]
        public ActionResult Create(int id)
        {
            RatingAccessory model = new RatingAccessory();
            model.AccessoryId = id;
            return View(model);
        }

        // POST: RatingAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingAccessory ratingAccessory)
        {
            if (ModelState.IsValid)
            {
                db.RatingAccessories.Add(ratingAccessory);
                db.SaveChanges();
                return RedirectToAction("Index", "Accessories");
            }

            return View(ratingAccessory);
        }

        // GET: RatingAccessories/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingAccessory ratingAccessory = db.RatingAccessories.Find(id);
            if (ratingAccessory == null)
            {
                return HttpNotFound();
            }
            return View(ratingAccessory);
        }

        // POST: RatingAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingId,Value,AccessoryId")] RatingAccessory ratingAccessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingAccessory);
        }

        // GET: RatingAccessories/Delete/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingAccessory ratingAccessory = db.RatingAccessories.Find(id);
            if (ratingAccessory == null)
            {
                return HttpNotFound();
            }
            return View(ratingAccessory);
        }

        // POST: RatingAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingAccessory ratingAccessory = db.RatingAccessories.Find(id);
            db.RatingAccessories.Remove(ratingAccessory);
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
