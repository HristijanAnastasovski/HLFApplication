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
    public class CommentMultivitaminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommentMultivitamins
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Index()
        {
            return View(db.CommentMultivitamins.ToList());
        }

        // GET: CommentMultivitamins/Details/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentMultivitamin commentMultivitamin = db.CommentMultivitamins.Find(id);
            if (commentMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(commentMultivitamin);
        }

        // GET: CommentMultivitamins/Create
        [Authorize(Roles = "Member")]
        public ActionResult Create(int id)
        {
            CommentMultivitamin model = new CommentMultivitamin();
            model.MultivitaminId = id;
            return View(model);
        }

        // POST: CommentMultivitamins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentMultivitamin commentMultivitamin)
        {
            if (ModelState.IsValid)
            {
                db.CommentMultivitamins.Add(commentMultivitamin);
                db.SaveChanges();
                return RedirectToAction("Index","Multivitamins");
            }

            return View(commentMultivitamin);
        }

        // GET: CommentMultivitamins/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentMultivitamin commentMultivitamin = db.CommentMultivitamins.Find(id);
            if (commentMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(commentMultivitamin);
        }

        // POST: CommentMultivitamins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Name,Opinion,MultivitaminId")] CommentMultivitamin commentMultivitamin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentMultivitamin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentMultivitamin);
        }

        // GET: CommentMultivitamins/Delete/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentMultivitamin commentMultivitamin = db.CommentMultivitamins.Find(id);
            if (commentMultivitamin == null)
            {
                return HttpNotFound();
            }
            return View(commentMultivitamin);
        }

        // POST: CommentMultivitamins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentMultivitamin commentMultivitamin = db.CommentMultivitamins.Find(id);
            db.CommentMultivitamins.Remove(commentMultivitamin);
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
