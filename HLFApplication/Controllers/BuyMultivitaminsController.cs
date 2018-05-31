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
    public class BuyMultivitaminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuyMultivitamins
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.BuyMultivitamins.ToList());
        }

        // GET: BuyMultivitamins/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMultivitamin buyMultivitamin = db.BuyMultivitamins.Find(id);
            if (buyMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(buyMultivitamin);
        }

        // GET: BuyMultivitamins/Create
        [Authorize(Roles = "Member")]
        public ActionResult Create(int id)
        {
            BuyMultivitamin model = new BuyMultivitamin();
            model.MultivitaminId = id;



            return View(model);
        }

        // POST: BuyMultivitamins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuyMultivitamin buyMultivitamin)
        {
            if (ModelState.IsValid)
            {
                var multivitamin = db.Multivitamins.Find(buyMultivitamin.MultivitaminId);
                multivitamin.NumberOfProductsInStock = multivitamin.NumberOfProductsInStock - 1;
                db.BuyMultivitamins.Add(buyMultivitamin);
                db.SaveChanges();
                return RedirectToAction("Index","Multivitamins");
            }

            return View(buyMultivitamin);
        }

        // GET: BuyMultivitamins/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMultivitamin buyMultivitamin = db.BuyMultivitamins.Find(id);
            if (buyMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(buyMultivitamin);
        }

        // POST: BuyMultivitamins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyMultivitaminId,MultivitaminId,FirstName,LastName,PhoneNumber,Country,Address,CreditCardNumber")] BuyMultivitamin buyMultivitamin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyMultivitamin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyMultivitamin);
        }

        // GET: BuyMultivitamins/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMultivitamin buyMultivitamin = db.BuyMultivitamins.Find(id);
            if (buyMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(buyMultivitamin);
        }

        // POST: BuyMultivitamins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyMultivitamin buyMultivitamin = db.BuyMultivitamins.Find(id);
            db.BuyMultivitamins.Remove(buyMultivitamin);
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
