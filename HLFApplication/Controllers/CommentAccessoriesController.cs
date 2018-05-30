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
    public class CommentAccessoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommentAccessories
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Index()
        {
            return View(db.CommentAccessories.ToList());
        }

        // GET: CommentAccessories/Details/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentAccessory commentAccessory = db.CommentAccessories.Find(id);
            if (commentAccessory == null)
            {
                return HttpNotFound();
            }
            return View(commentAccessory);
        }

        // GET: CommentAccessories/Create
        [Authorize(Roles = "Member")]
        public ActionResult Create(int id)
        {
            CommentAccessory model = new CommentAccessory();
            model.AccessoryId = id;
            return View(model);
        }

        // POST: CommentAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentAccessory commentAccessory)
        {
            if (ModelState.IsValid)
            {
                db.CommentAccessories.Add(commentAccessory);
                db.SaveChanges();
                return RedirectToAction("Index","Accessories");
            }

            return View(commentAccessory);
        }

        // GET: CommentAccessories/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentAccessory commentAccessory = db.CommentAccessories.Find(id);
            if (commentAccessory == null)
            {
                return HttpNotFound();
            }
            return View(commentAccessory);
        }

        // POST: CommentAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Name,Opinion,AccessoryId")] CommentAccessory commentAccessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentAccessory);
        }

        // GET: CommentAccessories/Delete/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentAccessory commentAccessory = db.CommentAccessories.Find(id);
            if (commentAccessory == null)
            {
                return HttpNotFound();
            }
            return View(commentAccessory);
        }

        // POST: CommentAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentAccessory commentAccessory = db.CommentAccessories.Find(id);
            db.CommentAccessories.Remove(commentAccessory);
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
