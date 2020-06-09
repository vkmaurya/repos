using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class AccommodationPackageController : Controller
    {
        // GET: AccommodationPackage
        SakhirDbModel db = new SakhirDbModel();

        public ActionResult AccommodationPackagePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAccommodationPackage()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var accommodationpackageview = (from AP in db.AccommodationPackages.Where(x => x.IsValid == true)
                                            join AT in db.AccommodationTypes on AP.AccommodationTypeID equals AT.AccommodatioTypeID
                                            orderby AT.AccommodatioTypeID
                                            select new
                                            {
                                                AT.AccommodatioTypeID,
                                                AT.AccommodationTypeName,
                                                AP.AccommodationPackageID,
                                                AP.AccommodationPackageName,
                                                AP.FeePerNight,
                                                AP.NoOfRoom
                                            }).ToList();



            var data = new { data = accommodationpackageview };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //----------------Accommodation Add and update--------------------------------

        public ActionResult Accommodationpackageaddandupdate(AccommodationPackage accommodationPackage)
        {
            string message = "";
            try
            {
                if (accommodationPackage != null)
                {
                    if (accommodationPackage.AccommodationPackageID == 0)
                    {
                        AccommodationPackage objaccommodationpackage = new AccommodationPackage();
                        objaccommodationpackage.AccommodationPackageName = accommodationPackage.AccommodationPackageName;
                        objaccommodationpackage.AccommodationTypeID = accommodationPackage.AccommodationTypeID;
                        objaccommodationpackage.FeePerNight = accommodationPackage.FeePerNight;
                        objaccommodationpackage.NoOfRoom = accommodationPackage.NoOfRoom;
                        objaccommodationpackage.CreatedByDate = DateTime.Now;
                        objaccommodationpackage.CreatedByID = 1;
                        objaccommodationpackage.IsValid = true;
                        db.AccommodationPackages.Add(objaccommodationpackage);
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "save";
                        }
                        else
                        {
                            message = "notsave";
                        }

                    }
                    else
                    {
                        var data = db.AccommodationPackages.Where(x => x.AccommodationPackageID == accommodationPackage.AccommodationPackageID).FirstOrDefault();
                        if (data != null)
                        {
                            data.AccommodationPackageName = accommodationPackage.AccommodationPackageName;
                            data.AccommodationTypeID = accommodationPackage.AccommodationTypeID;
                            data.FeePerNight = accommodationPackage.FeePerNight;
                            data.NoOfRoom = accommodationPackage.NoOfRoom;
                            data.ModifyByDate = DateTime.Now;
                            data.ModifyByID = 1;
                            db.Entry(data).State = EntityState.Modified;
                            int i = db.SaveChanges();
                            if (i > 0)
                            {
                                message = "update";
                            }
                            else
                            {
                                message = "notupdate";
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SearchAccomodationpackage(AccommodationPackage accommodationPackage)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.AccommodationPackages.Where(x => x.AccommodationPackageID == accommodationPackage.AccommodationPackageID).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DeletedAcccommodatoionpackage(AccommodationPackage accommodationPackage)
        {
            string message = "";
            try
            {
                var data = db.AccommodationPackages.Where(x => x.AccommodationPackageID == accommodationPackage.AccommodationPackageID).FirstOrDefault();
                if (data != null)
                {
                    data.IsValid = false;
                    data.DeletedByDate = DateTime.Now;
                    data.DeletedByID = 1;
                    db.Entry(data).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "deleted";
                    }
                    else
                    {
                        message = "notdelete";
                    }

                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //------------------dropdounlist---------------------------

        [HttpGet]
        public ActionResult Viewdropdownlistaccommodationpackage()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.AccommodationPackages.Where(x => x.IsValid == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}