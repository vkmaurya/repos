using Hotal_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace Hotal_Management_System.Controllers
{
    public class AccomodationPackagesController : Controller
    {

        ModelDataBase db = new ModelDataBase();

        // GET: AccomodationPackages
        public ActionResult AccomodationPackage()
        {
            return View();
        }

        public ActionResult dropdownlistaccomodationtype()
        {
            var data = db.AccomodationTypes.ToList();

            return Json(data);
        }


        public ActionResult Searchaccomodationpackage(int id)
        {
            var data = db.AccomodationPackages.Where(x => x.ID == id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreatedandUpdate(AccomodationPackage accomodationPackage)
        {
            string message = "";
            try
            {
                if (accomodationPackage.ID != 0)
                {

                    var data = db.AccomodationPackages.Where(x => x.ID == accomodationPackage.ID).FirstOrDefault();
                    data.AccomodationTypeID = accomodationPackage.AccomodationTypeID;
                    data.Name = accomodationPackage.Name;
                    data.NoOfRoom = accomodationPackage.NoOfRoom;
                    data.FeePerNight = accomodationPackage.FeePerNight;
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
                else
                {
                    AccomodationPackage objaccomodationPackage = new AccomodationPackage();

                    objaccomodationPackage.AccomodationTypeID = accomodationPackage.AccomodationTypeID;
                    objaccomodationPackage.Name = accomodationPackage.Name;
                    objaccomodationPackage.NoOfRoom = accomodationPackage.NoOfRoom;
                    objaccomodationPackage.FeePerNight = accomodationPackage.FeePerNight;
                    db.AccomodationPackages.Add(objaccomodationPackage);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "addsuccess";
                    }
                    else
                    {
                        message = "notadd";
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
        public ActionResult AccomodationPackagesView()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<AccomodationPackage> user = new List<AccomodationPackage>();


            user = db.AccomodationPackages.ToList<AccomodationPackage>();
            int totalrows = user.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                user = user.Where(x => x.ID.ToString().Contains(searchvalue.ToLower()) || x.Name.ToLower().Contains(searchvalue.ToLower()) || x.AccomodationTypeID.ToString().Contains(searchvalue.ToLower()) || x.NoOfRoom.ToString().Contains(searchvalue.ToLower()) || x.FeePerNight.ToString().Contains(searchvalue.ToLower())).ToList<AccomodationPackage>();
            }
            int totalrawsafterfiltering = user.Count;
            //sorting
            user = user.OrderBy(SearchColumnName + " " + SortDirection).ToList<AccomodationPackage>();

            //paging

            user = user.Skip(start).Take(length).ToList<AccomodationPackage>();

            return Json(new { data = user, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteAccomodation(int id)
        {
            string message = "";
            try
            {
                var data = db.AccomodationPackages.Where(x => x.ID == id).FirstOrDefault();
                db.Entry(data).State = EntityState.Deleted;
                int i = db.SaveChanges();
                if (i > 0)
                {
                    message = "delete";
                }
                else
                {
                    message = "notdelete";
                }
            }
            catch (Exception ex)
            {
                message = "Exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}