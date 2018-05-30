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
            var proteins = db.Proteins.ToList();
            var ratings = db.Ratings.ToList();
            for(int i=0;i<proteins.Count;i++)
            {
                for(int j=0;j<ratings.Count;j++)
                {
                    if(proteins.ElementAt(i).ProteinId==ratings.ElementAt(j).ProteinId)
                    {
                        proteins.ElementAt(i).Ratings.Add(ratings.ElementAt(j).Value);
                    }
                }
            }
            db.SaveChanges();
            return View(db.Proteins.ToList());
        }

       /* public ActionResult AddDiscount(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protein protein = db.Proteins.Find(id);
            protein.OldPrice = protein.Price;
            db.SaveChanges();
            if (protein == null)
            {
                return HttpNotFound();
            }
            return View(protein);

        }
        [HttpPost]
        public ActionResult AddDiscount(Protein p)
        {
            var protein = db.Proteins.Find(p.ProteinId);
            
            protein.Price = p.Price;
            db.SaveChanges();
            return View("Index");
            

        }*/
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
            var proteins = db.Proteins.ToList();
            var ratings = db.Ratings.ToList();
            for (int i = 0; i < proteins.Count; i++)
            {
                for (int j = 0; j < ratings.Count; j++)
                {
                    if (proteins.ElementAt(i).ProteinId == ratings.ElementAt(j).ProteinId)
                    {
                        proteins.ElementAt(i).Ratings.Add(ratings.ElementAt(j).Value);
                    }
                }
            }
            
            var comments = db.Comments.ToList();
           
            db.SaveChanges();
            return View(protein);
        }

        [Authorize (Roles="Member")]
        public ActionResult BuyProduct(int id)
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
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult AddQuantity(int id)
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
            

            AddQuantityToItem model = new AddQuantityToItem();
            model.ItemId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddQuantity(AddQuantityToItem model)
        {
            db.Proteins.Find(model.ItemId).NumberOfProductsInStock = db.Proteins.Find(model.ItemId).NumberOfProductsInStock + model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





        // GET: Proteins/Create
        [Authorize(Roles = "Administrator,Editor")]
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
        [Authorize(Roles = "Administrator,Editor")]
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
        [Authorize(Roles = "Administrator,Editor")]
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
