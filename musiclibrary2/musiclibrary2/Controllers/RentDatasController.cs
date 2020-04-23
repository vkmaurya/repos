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
    public class RentDatasController : Controller
    {
        private MusicModeldb db = new MusicModeldb();

        // GET: RentDatas
        public ActionResult Index()
        {
            return View(db.RentDatas.ToList());
        }

        // GET: RentDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentData rentData = db.RentDatas.Find(id);
            if (rentData == null)
            {
                return HttpNotFound();
            }
            return View(rentData);
        }

        // GET: RentDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentId,UserId,Username,AuthorName,CategoryName,CategoryNumber,Price,Createdby_Id,Createdby_Date,Modifiedby_Id,Modifiedby_Date,Deleteby_Id,Deleteby_Date,Status,RentDate")] RentData rentData)
        {
            if (ModelState.IsValid)
            {
                db.RentDatas.Add(rentData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentData);
        }

        // GET: RentDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentData rentData = db.RentDatas.Find(id);
            if (rentData == null)
            {
                return HttpNotFound();
            }
            return View(rentData);
        }

        // POST: RentDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentId,UserId,Username,AuthorName,CategoryName,CategoryNumber,Price,Createdby_Id,Createdby_Date,Modifiedby_Id,Modifiedby_Date,Deleteby_Id,Deleteby_Date,Status,RentDate")] RentData rentData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentData);
        }

        // GET: RentDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentData rentData = db.RentDatas.Find(id);
            if (rentData == null)
            {
                return HttpNotFound();
            }
            return View(rentData);
        }

        // POST: RentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentData rentData = db.RentDatas.Find(id);
            db.RentDatas.Remove(rentData);
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
