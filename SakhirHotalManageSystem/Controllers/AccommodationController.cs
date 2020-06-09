using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class AccommodationController : Controller
    {
        // GET: Accommodation

        SakhirDbModel db = new SakhirDbModel();
       
        public ActionResult AccommodationPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAccommodation()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var accommodationview = (from A in db.Accommodations.Where(x => x.IsValid == true)
                                            join AP in db.AccommodationPackages on A.AccomodationPackageID equals AP.AccommodationPackageID
                                            orderby A.AccomodationPackageID
                                            select new
                                            {
                                                A.AccommodationID,
                                                A.AccommodationName,
                                                AP.AccommodationPackageID,
                                                AP.AccommodationPackageName,
                                                
                                            }).ToList();

            var data = new { data = accommodationview};
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //----------------Accommodation Add and update--------------------------------

        public ActionResult Accommodationaddandupdate(Accommodation accommodation)
        {
            string message = "";
            try
            {
                if (accommodation != null)
                {
                    if (accommodation.AccommodationID == 0)
                    {
                        Accommodation objaccommodation = new Accommodation();
                        objaccommodation.AccommodationName = accommodation.AccommodationName;
                        objaccommodation.AccomodationPackageID = accommodation.AccomodationPackageID;
                        objaccommodation.CreatedByDate = DateTime.Now;
                        objaccommodation.CreatedByID = 1;
                        objaccommodation.IsValid = true;
                        db.Accommodations.Add(objaccommodation);
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
                        var data = db.Accommodations.Where(x => x.AccommodationID == accommodation.AccommodationID).FirstOrDefault();
                        if (data != null)
                        {
                            data.AccommodationName = accommodation.AccommodationName;
                            data.AccomodationPackageID = accommodation.AccomodationPackageID;
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
        public ActionResult SearchAccomodationid(Accommodation accommodation)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Accommodations.Where(x => x.AccommodationID == accommodation.AccommodationID).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DeletedAcccommodatoion(Accommodation accommodation)
        {
            string message = "";
            try
            {
                var data = db.Accommodations.Where(x => x.AccommodationID == accommodation.AccommodationID).FirstOrDefault();
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







    }
}