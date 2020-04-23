using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CRUD_Application_Ajax.Models;

namespace ASP_MVC_CRUD_Application_Ajax.Controllers
{
    public class StudentController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.AjaxApplications.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AjaxApplication ajaxApplication = db.AjaxApplications.Find(id);
            if (ajaxApplication == null)
            {
                return HttpNotFound();
            }
            return View(ajaxApplication);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Contact,Address,Email")] AjaxApplication ajaxApplication)
        {
            if (ModelState.IsValid)
            {
                db.AjaxApplications.Add(ajaxApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ajaxApplication);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AjaxApplication ajaxApplication = db.AjaxApplications.Find(id);
            if (ajaxApplication == null)
            {
                return HttpNotFound();
            }
            return View(ajaxApplication);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Contact,Address,Email")] AjaxApplication ajaxApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ajaxApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ajaxApplication);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AjaxApplication ajaxApplication = db.AjaxApplications.Find(id);
            if (ajaxApplication == null)
            {
                return HttpNotFound();
            }
            return View(ajaxApplication);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AjaxApplication ajaxApplication = db.AjaxApplications.Find(id);
            db.AjaxApplications.Remove(ajaxApplication);
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
