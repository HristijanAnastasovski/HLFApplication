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
    public class ProteinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proteins
        public ActionResult Index()
        {
            return View(db.Proteins.ToList());
        }

        // GET: Proteins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protein protein = db.Proteins.Find(id);
            if (protein == null)
            {
                return HttpNotFound();
            }
            return View(protein);
        }

        // GET: Proteins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proteins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProteinId,Name,Price,NumberOfProductsInStock,Description,ImageURL")] Protein protein)
        {
            if (ModelState.IsValid)
            {
                db.Proteins.Add(protein);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(protein);
        }

        // GET: Proteins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protein protein = db.Proteins.Find(id);
            if (protein == null)
            {
                return HttpNotFound();
            }
            return View(protein);
        }

        // POST: Proteins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProteinId,Name,Price,NumberOfProductsInStock,Description,ImageURL")] Protein protein)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protein).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(protein);
        }

        // GET: Proteins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protein protein = db.Proteins.Find(id);
            if (protein == null)
            {
                return HttpNotFound();
            }
            return View(protein);
        }

        // POST: Proteins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Protein protein = db.Proteins.Find(id);
            db.Proteins.Remove(protein);
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
