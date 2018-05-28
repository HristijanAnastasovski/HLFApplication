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
    public class PreWorkoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PreWorkouts
        public ActionResult Index()
        {
            return View(db.PreWorkouts.ToList());
        }

        // GET: PreWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreWorkout preWorkout = db.PreWorkouts.Find(id);
            if (preWorkout == null)
            {
                return HttpNotFound();
            }
            return View(preWorkout);
        }

        // GET: PreWorkouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreWorkoutId,Name,Price,NumberOfProductsInStock,Description,ImageURL")] PreWorkout preWorkout)
        {
            if (ModelState.IsValid)
            {
                db.PreWorkouts.Add(preWorkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preWorkout);
        }

        // GET: PreWorkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreWorkout preWorkout = db.PreWorkouts.Find(id);
            if (preWorkout == null)
            {
                return HttpNotFound();
            }
            return View(preWorkout);
        }

        // POST: PreWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreWorkoutId,Name,Price,NumberOfProductsInStock,Description,ImageURL")] PreWorkout preWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preWorkout);
        }

        // GET: PreWorkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreWorkout preWorkout = db.PreWorkouts.Find(id);
            if (preWorkout == null)
            {
                return HttpNotFound();
            }
            return View(preWorkout);
        }

        // POST: PreWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreWorkout preWorkout = db.PreWorkouts.Find(id);
            db.PreWorkouts.Remove(preWorkout);
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
