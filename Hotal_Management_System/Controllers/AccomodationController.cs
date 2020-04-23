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
    public class AccomodationController : Controller
    {
        ModelDataBase db = new ModelDataBase();
        // GET: Accomodation
        public ActionResult AccomodationPages()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AccomodationView()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<Accomo> user = new List<Accomo>();


            user = db.Accomoes.ToList<Accomo>();
            int totalrows = user.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                user = user.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.AccomodationName.ToLower().Contains(searchvalue.ToLower()) || x.AccomodationDescription.ToString().Contains(searchvalue.ToLower()) || x.AccomodationPackageId.ToString().Contains(searchvalue.ToLower())).ToList<Accomo>();
            }
            int totalrawsafterfiltering = user.Count;
            //sorting
            user = user.OrderBy(SearchColumnName + " " + SortDirection).ToList<Accomo>();

            //paging

            user = user.Skip(start).Take(length).ToList<Accomo>();

            return Json(new { data = user, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Accomodationdropdownlist()
        {
            var data = db.AccomodationPackages.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreateandUpdate(Accomo accomodation)
        {
            string message = "";



            try
            {
                if (accomodation.Id != 0)
                {
                    var objaccomodationPackage = db.Accomoes.Where(x => x.Id == accomodation.Id).FirstOrDefault();

                    objaccomodationPackage.AccomodationPackageId = accomodation.AccomodationPackageId;
                    objaccomodationPackage.AccomodationName = accomodation.AccomodationName;
                    objaccomodationPackage.AccomodationDescription = accomodation.AccomodationDescription;
                    db.Entry(objaccomodationPackage).State=EntityState.Modified;
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

                    Accomo objaccomodationPackage = new Accomo();

                    objaccomodationPackage.AccomodationPackageId = accomodation.AccomodationPackageId;
                    objaccomodationPackage.AccomodationName = accomodation.AccomodationName;
                    objaccomodationPackage.AccomodationDescription = accomodation.AccomodationDescription;
                    db.Accomoes.Add(objaccomodationPackage);
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

        public ActionResult Search(int id)
        {
            var data = db.Accomoes.Where(x => x.Id == id).FirstOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Accomoddel(int id)
        {
            string  message= "";  

            var data = db.Accomoes.Where(x => x.Id == id).FirstOrDefault();
            db.Entry(data).State = EntityState.Deleted;
           int i= db.SaveChanges();
            if(i>0)
            {
                message = "delete";
            }
            else
            {
                message = "notdelete";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}