using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class RoomsController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();
        // GET: Rooms
        public ActionResult RoomsPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewRooms()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from AA in db.Accommodations.Where(x=>x.IsValid==true)
                      join AP in db.AccommodationPackages
                      on AA.AccomodationPackageID equals AP.AccommodationPackageID
                      join AT in db.AccommodationTypes
                      on AP.AccommodationTypeID equals AT.AccommodatioTypeID
                      select new
                      {
                         AA.AccommodationID,
                         AA.AccommodationName,
                         AA.AccomodationPackageID,
                         AP.AccommodationPackageName,
                         AP.AccommodationPackageID,
                         AP.FeePerNight,
                         AP.NoOfRoom,
                         AT.AccommodatioTypeID,
                         AT.AccommodationTypeName,
                      }).ToList();
            var data = new { data = obj };
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}