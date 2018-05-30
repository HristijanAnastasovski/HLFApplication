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
    public class BuyProteinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuyProteins
        [Authorize (Roles="Administrator")]
        public ActionResult Index()
        {
            return View(db.BuyProteins.ToList());
        }

        // GET: BuyProteins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyProtein buyProtein = db.BuyProteins.Find(id);
            if (buyProtein == null)
            {
                return HttpNotFound();
            }
            return View(buyProtein);
        }

        // GET: BuyProteins/Create
        [Authorize (Roles="Member")]
        public ActionResult Create(int id)
        {
            BuyProtein model = new BuyProtein();
            model.ProteinId = id;

           
            
            return View(model);
        }

        // POST: BuyProteins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuyProtein buyProtein)
        {
            if (ModelState.IsValid)
            {
                var protein = db.Proteins.Find(buyProtein.ProteinId);
                protein.NumberOfProductsInStock = protein.NumberOfProductsInStock - 1;
                db.BuyProteins.Add(buyProtein);
                db.SaveChanges();
                return RedirectToAction("Index","Proteins");
            }

            return View(buyProtein);
        }

        // GET: BuyProteins/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyProtein buyProtein = db.BuyProteins.Find(id);
            if (buyProtein == null)
            {
                return HttpNotFound();
            }
            return View(buyProtein);
        }

        // POST: BuyProteins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyProteinId,ProteinId,FirstName,LastName,PhoneNumber,Country,Address,CreditCardNumber")] BuyProtein buyProtein)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyProtein).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyProtein);
        }

        // GET: BuyProteins/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyProtein buyProtein = db.BuyProteins.Find(id);
            if (buyProtein == null)
            {
                return HttpNotFound();
            }
            return View(buyProtein);
        }

        // POST: BuyProteins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyProtein buyProtein = db.BuyProteins.Find(id);
            db.BuyProteins.Remove(buyProtein);
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
