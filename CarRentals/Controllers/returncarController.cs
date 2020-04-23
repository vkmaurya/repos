using CarRentals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentals.Controllers
{

    public class returncarController : Controller
    {
        SuperCarRentalEntities1 db = new SuperCarRentalEntities1();
        // GET: returncar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult save(returncar returncar)
        {
            if (ModelState.IsValid)
            {
                db.returncars.Add(returncar);
                var car = db.carregs.SingleOrDefault(e => e.carno == returncar.carno);
                if (car == null)

                    return HttpNotFound("CarNo Not Found");
                car.available = "Yes";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Getid(string carno)
        {
            var carn = (from s in db.Rentails
                        where s.carid == carno
                        select new
                        {
                            StartDate = s.sdate,
                            EndDate = s.edate,
                            Custid = s.custid,
                            CarNo = s.carid,
                            Fee = s.fee,
                            ElapsedDays = SqlFunctions.DateDiff("day", s.edate, DateTime.Now)

                        }).ToArray();
            return Json(carn, JsonRequestBehavior.AllowGet);
        }
    }
}