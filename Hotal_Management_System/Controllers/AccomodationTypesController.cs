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
    public class AccomodationTypesController : Controller
    {
        ModelDataBase db = new ModelDataBase();
        // GET: AccomodationTypes
        public ActionResult AccomodationType()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AccomodationTypeView()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<AccomodationType> user = new List<AccomodationType>();


            user = db.AccomodationTypes.ToList<AccomodationType>();
            int totalrows = user.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                user = user.Where(x => x.ID.ToString().Contains(searchvalue.ToLower()) || x.Name.ToLower().Contains(searchvalue.ToLower()) || x.Description.ToLower().Contains(searchvalue.ToLower())).ToList<AccomodationType>();
            }
            int totalrawsafterfiltering = user.Count;
            //sorting
            user = user.OrderBy(SearchColumnName + " " + SortDirection).ToList<AccomodationType>();

            //paging

            user = user.Skip(start).Take(length).ToList<AccomodationType>();

            return Json(new { data = user, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(int Id)
        {
            var credintioal = db.AccomodationTypes.Where(x => x.ID == Id).FirstOrDefault();

            return Json(credintioal);
        }


        [HttpPost]
        public ActionResult Create(AccomodationType accomodationType)
        {
            string message = "";

            try
            {


                if (accomodationType.ID != 0)
                {

                    AccomodationType dataaccomodation = db.AccomodationTypes.Where(x => x.ID == accomodationType.ID).FirstOrDefault();
                    dataaccomodation.Name = accomodationType.Name;
                    dataaccomodation.Description = accomodationType.Description;
                    dataaccomodation.ModifyByDate = DateTime.Now;
                    dataaccomodation.ModifyById = 1;
                    db.Entry(dataaccomodation).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "update";
                    }
                    else
                    {
                        message = "notUpdate";
                    }

                }
                else
                {
                    AccomodationType objaccomodationtype = new AccomodationType();
                    objaccomodationtype.Name = accomodationType.Name;
                    objaccomodationtype.Description = accomodationType.Description;
                    objaccomodationtype.CreatedByDate = DateTime.Now;
                    objaccomodationtype.CreatedById = 1;
                    objaccomodationtype.IsValid = true;
                    db.AccomodationTypes.Add(objaccomodationtype);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "success";
                    }
                    else
                    {
                        message = "error";
                    }


                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }



            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int Id)
        {
            string message = "";

            try
            {
                var data = db.AccomodationTypes.Where(x => x.ID == Id).FirstOrDefault();
                db.Entry(data).State = EntityState.Deleted;
                int i = db.SaveChanges();
                if(i>0)
                {
                    message = "delete";
                }
                else
                {
                    message = "error";
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