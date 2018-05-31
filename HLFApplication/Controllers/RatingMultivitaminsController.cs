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
    public class RatingMultivitaminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RatingMultivitamins
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Index()
        {
            return View(db.RatingMultivitamins.ToList());
        }

        // GET: RatingMultivitamins/Details/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingMultivitamin ratingMultivitamin = db.RatingMultivitamins.Find(id);
            if (ratingMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(ratingMultivitamin);
        }

        // GET: RatingMultivitamins/Create
        [Authorize(Roles = "Member")]
        public ActionResult Create(int id)
        {
            RatingMultivitamin model = new RatingMultivitamin();
            model.MultivitaminId = id;
            return View(model);
        }

        // POST: RatingMultivitamins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingMultivitamin ratingMultivitamin)
        {
            if (ModelState.IsValid)
            {
                db.RatingMultivitamins.Add(ratingMultivitamin);
                db.SaveChanges();
                return RedirectToAction("Index","Multivitamins");
            }

            return View(ratingMultivitamin);
        }

        // GET: RatingMultivitamins/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingMultivitamin ratingMultivitamin = db.RatingMultivitamins.Find(id);
            if (ratingMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(ratingMultivitamin);
        }

        // POST: RatingMultivitamins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingId,Value,MultivitaminId")] RatingMultivitamin ratingMultivitamin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingMultivitamin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingMultivitamin);
        }

        // GET: RatingMultivitamins/Delete/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingMultivitamin ratingMultivitamin = db.RatingMultivitamins.Find(id);
            if (ratingMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(ratingMultivitamin);
        }

        // POST: RatingMultivitamins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingMultivitamin ratingMultivitamin = db.RatingMultivitamins.Find(id);
            db.RatingMultivitamins.Remove(ratingMultivitamin);
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
