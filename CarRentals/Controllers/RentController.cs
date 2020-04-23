using CarRentals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentals.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        SuperCarRentalEntities1 db = new SuperCarRentalEntities1();
        public ActionResult Index()
        {

            var result = (from r in db.Rentails
                          join c in db.carregs on r.carid equals c.carno
                          select new RentalViewModel
                          {
                              Id = r.Id,
                              carid = r.carid,
                              custid = r.custid,
                              fee = r.fee,
                              sdate = r.sdate,
                              edate = r.edate,
                              available = c.available
                          }).ToList();
            return View(result);
        }


        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.carregs.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.customers where s.Id == id select s.custname).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getavail(string carno)
        {
            var carnomber = (from s in db.carregs where s.carno == carno select s.available).FirstOrDefault();
            return Json(carnomber, JsonRequestBehavior.AllowGet);
        }

        public ActionResult save(Rentail rentail)
        {
            Rentail objrentail = new Rentail();
            if (ModelState.IsValid)
            {
                objrentail.carid = rentail.carid.ToString();
                objrentail.custid = rentail.custid;
                objrentail.fee = rentail.fee;
                objrentail.sdate = rentail.sdate;
                objrentail.edate = rentail.edate;

                db.Rentails.Add(objrentail);

                var car = db.carregs.SingleOrDefault(e => e.carno == rentail.carid);
                if (car == null)
                    return HttpNotFound("CarNo is Not Valid");

                car.available = "no";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentail);
        }

    }
}