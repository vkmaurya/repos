using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAMS.Models;

namespace CAMS.Controllers
{
    public class CommonCustomersController : Controller
    {
        private Modeldb db = new Modeldb();

        // GET: CommonCustomers
        public ActionResult Index()
        {
            return View(db.CommonCustomers.ToList());
        }

        // GET: CommonCustomers/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var  commonCustomer = db.CommonCustomers.Find(id);
            ////if (commonCustomer == null)
            ////{
            ////    return HttpNotFound();
            ////}
            ///
            var data = db.Products.Where(x => x.CustomerId == id).ToList();
            return View(data);
        }

        // GET: CommonCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommonCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,CustomerName,TotalAmount,CreatedById,CreatedByDate,ModifyById,ModifyByDate,DeletedById,DeletedByDate,IsValid")] CommonCustomer commonCustomer)
        {
            if (ModelState.IsValid)
            {
                db.CommonCustomers.Add(commonCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commonCustomer);
        }

        // GET: CommonCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonCustomer commonCustomer = db.CommonCustomers.Find(id);
            if (commonCustomer == null)
            {
                return HttpNotFound();
            }
            return View(commonCustomer);
        }

        // POST: CommonCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,CustomerName,TotalAmount,CreatedById,CreatedByDate,ModifyById,ModifyByDate,DeletedById,DeletedByDate,IsValid")] CommonCustomer commonCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commonCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commonCustomer);
        }

        // GET: CommonCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonCustomer commonCustomer = db.CommonCustomers.Find(id);
            if (commonCustomer == null)
            {
                return HttpNotFound();
            }
            return View(commonCustomer);
        }

        // POST: CommonCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommonCustomer commonCustomer = db.CommonCustomers.Find(id);
            db.CommonCustomers.Remove(commonCustomer);
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
