using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using musiclibrary2.Models;

namespace musiclibrary2.Controllers
{
    public class MediadatasController : Controller
    {
        private MusicModeldb db = new MusicModeldb();

        // GET: Mediadatas
        public ActionResult Index()
        {
            return View(db.Mediadatas.ToList());
        }

        // GET: Mediadatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mediadata mediadata = db.Mediadatas.Find(id);
            if (mediadata == null)
            {
                return HttpNotFound();
            }
            return View(mediadata);
        }

        // GET: Mediadatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mediadatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AuthorName,CategoryName,Categorynumber,Title,Description,Price,Image,Createdby_Id,Createdby_Date,Modifiedby_Id,Modifiedby_Data,Deletedby_Id,Deletedby_Date,Media_Status")] Mediadata mediadata)
        {
            if (ModelState.IsValid)
            {
                db.Mediadatas.Add(mediadata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mediadata);
        }

        // GET: Mediadatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mediadata mediadata = db.Mediadatas.Find(id);
            if (mediadata == null)
            {
                return HttpNotFound();
            }
            return View(mediadata);
        }

        // POST: Mediadatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorName,CategoryName,Categorynumber,Title,Description,Price,Image,Createdby_Id,Createdby_Date,Modifiedby_Id,Modifiedby_Data,Deletedby_Id,Deletedby_Date,Media_Status")] Mediadata mediadata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediadata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mediadata);
        }

        // GET: Mediadatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mediadata mediadata = db.Mediadatas.Find(id);
            if (mediadata == null)
            {
                return HttpNotFound();
            }
            return View(mediadata);
        }

        // POST: Mediadatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mediadata mediadata = db.Mediadatas.Find(id);
            db.Mediadatas.Remove(mediadata);
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
