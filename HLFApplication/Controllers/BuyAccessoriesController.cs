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
    public class BuyAccessoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuyAccessories
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.BuyAccessories.ToList());
        }

        // GET: BuyAccessories/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyAccessory buyAccessory = db.BuyAccessories.Find(id);
            if (buyAccessory == null)
            {
                return HttpNotFound();
            }
            return View(buyAccessory);
        }

        // GET: BuyAccessories/Create
        public ActionResult Create(int id)
        {
            BuyAccessory model = new BuyAccessory();
            model.AccessoryId = id;
            return View(model);
        }

        // POST: BuyAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuyAccessory buyAccessory)
        {
            if (ModelState.IsValid)
            {
                var accessory = db.Accessories.Find(buyAccessory.AccessoryId);
                accessory.NumberOfProductsInStock = accessory.NumberOfProductsInStock - 1;
                db.BuyAccessories.Add(buyAccessory);
                db.SaveChanges();
                return RedirectToAction("Index","Accessories");
            }

            return View(buyAccessory);
        }

        // GET: BuyAccessories/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyAccessory buyAccessory = db.BuyAccessories.Find(id);
            if (buyAccessory == null)
            {
                return HttpNotFound();
            }
            return View(buyAccessory);
        }

        // POST: BuyAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyProteinId,AccessoryId,FirstName,LastName,PhoneNumber,Country,Address,CreditCardNumber")] BuyAccessory buyAccessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyAccessory);
        }

        // GET: BuyAccessories/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyAccessory buyAccessory = db.BuyAccessories.Find(id);
            if (buyAccessory == null)
            {
                return HttpNotFound();
            }
            return View(buyAccessory);
        }

        // POST: BuyAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyAccessory buyAccessory = db.BuyAccessories.Find(id);
            db.BuyAccessories.Remove(buyAccessory);
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
