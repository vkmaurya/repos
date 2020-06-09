using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class AccommodationTypeController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();
        // GET: AccommodationType
        public ActionResult AccommodationTypePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAccommodationType()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var objAccommodation = db.AccommodationTypes.Where(x => x.IsValid == true).ToList();
            var data = new { data = objAccommodation };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //----------------Accommodation Add and update--------------------------------

        public ActionResult Accommodationtypeaddandupdate(AccommodationType accommodationType)
        {
            string message = "";
            try
            {

                var profile = Request.Files;

                string imgname = string.Empty;
                string ImageName = string.Empty;
                var comPath = "";


                if (accommodationType != null)
                {
                    if (accommodationType.AccommodatioTypeID == 0)
                    {
                        AccommodationType objaccommodationType = new AccommodationType();

                        if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                        {
                            var logo = System.Web.HttpContext.Current.Request.Files["file"];
                            if (logo.ContentLength > 0)
                            {
                                var profileName = Path.GetFileName(logo.FileName);
                                var ext = Path.GetExtension(logo.FileName);

                                ImageName = profileName;

                                comPath = Server.MapPath("~/Images/") + ImageName;

                                logo.SaveAs(comPath);
                                accommodationType.AccommodationTypeImage = comPath;
                            }

                        }
                        else
                        {
                            accommodationType.AccommodationTypeImage = Server.MapPath("~/Images/") + "profile.jpg";

                        int response = 1;
                        }
                    objaccommodationType.AccommodationTypeName = accommodationType.AccommodationTypeName;
                    objaccommodationType.CreatedByDate = DateTime.Now;
                    objaccommodationType.CreatedByID = 1;
                    objaccommodationType.IsValid = true;
                        objaccommodationType.AccommodationTypeImage = comPath;
                    objaccommodationType.AccommodationTypeDescription = accommodationType.AccommodationTypeDescription;
                    db.AccommodationTypes.Add(objaccommodationType);
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
                    var data = db.AccommodationTypes.Where(x => x.AccommodatioTypeID == accommodationType.AccommodatioTypeID).FirstOrDefault();
                    if (data != null)
                    {
                        data.AccommodationTypeName = accommodationType.AccommodationTypeName;
                        data.AccommodationTypeDescription = accommodationType.AccommodationTypeDescription;
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
            catch(Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
}


[HttpPost]
public ActionResult SearchAccomodationtypeid(AccommodationType accommodationType)
{
    db.Configuration.ProxyCreationEnabled = false;
    var data = db.AccommodationTypes.Where(x => x.AccommodatioTypeID == accommodationType.AccommodatioTypeID).FirstOrDefault();
    return Json(data, JsonRequestBehavior.AllowGet);
}



public ActionResult DeletedAcccommodatoiontype(AccommodationType accommodationType)
{
    string message = "";
    try
    {
        var data = db.AccommodationTypes.Where(x => x.AccommodatioTypeID == accommodationType.AccommodatioTypeID).FirstOrDefault();
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


//-------------------------dropdownlist--------------------------------------------

[HttpPost]
public ActionResult ViewAccommodationTypedropdownlist()
{
    db.Configuration.ProxyCreationEnabled = false;
    var objAccommodation = db.AccommodationTypes.Where(x => x.IsValid == true).ToList();

    return Json(objAccommodation, JsonRequestBehavior.AllowGet);
}
    }
}