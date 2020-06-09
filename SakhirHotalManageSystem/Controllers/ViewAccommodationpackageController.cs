using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class ViewAccommodationpackageController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();
        // GET: ViewAccommodationpackage
        public ActionResult ViewAccommodationpackagePage(int? accommodationtypeid)
        {
            Session["Accomodationpackageid"] = accommodationtypeid;

            return View();
        }


        [HttpPost]
        public ActionResult ViewAccommodationAllpackagenamedropdownlist()
        {
            int id = Convert.ToInt32(Session["Accomodationpackageid"]);
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.AccommodationPackages.Where(x => x.AccommodationTypeID == id && x.IsValid == true).ToList();
            return Json(data);
        }


        [HttpPost]
        public ActionResult ViewAccommodationAllList(AccommodationPackage accommodationPackage)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from AA in db.Accommodations.Where(x => x.IsValid == true && x.AccomodationPackageID== accommodationPackage.AccommodationPackageID)
                       join AP in db.AccommodationPackages.Where(x=>x.AccommodationTypeID==accommodationPackage.AccommodationTypeID && x.IsValid==true)
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

            return Json(obj,JsonRequestBehavior.AllowGet);
        }

    }
}