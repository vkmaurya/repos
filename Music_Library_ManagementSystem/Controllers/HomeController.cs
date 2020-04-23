using Music_Library_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Music_Library_ManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        Music_ModelDb db = new Music_ModelDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult HireMediaRent()
        {

            if (Session["custmoerusername"] != null)
            {

                var mediaData = db.Mediadatas.ToList<Mediadata>();


                return View(mediaData);

            }
            return RedirectToAction("Login", "login");



        }

        //public ActionResult viewdata()
        //{

         
        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);
        //    string searchvalue = Request["search[value]"];
        //    string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
        //    string SortDirection = Request["order[0][dir]"];

        //    List<Mediadata> objmedia = new List<Mediadata>();


        //    objmedia = db.Mediadatas.ToList<Mediadata>();
        //    int totalrows = objmedia.Count;
        //    if (!string.IsNullOrEmpty(searchvalue))//filter
        //    {
        //        objmedia = objmedia.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.AuthorName.ToString().Contains(searchvalue.ToLower()) || x.CategoryName.ToLower().Contains(searchvalue.ToLower()) || x.CategoryNumber.ToLower().Contains(searchvalue.ToLower()) || x.Title.ToLower().Contains(searchvalue.ToLower()) || x.Description.ToLower().Contains(searchvalue.ToLower()) || x.Price.ToLower().Contains(searchvalue.ToLower()) || x.Media_Status.ToString().Contains(searchvalue.ToLower())).ToList<Mediadata>();
        //    }
        //    int totalrawsafterfiltering = objmedia.Count;
        //    //sorting
        //    objmedia = objmedia.OrderBy(SearchColumnName + " " + SortDirection).ToList<Mediadata>();

        //    //paging

        //    objmedia = objmedia.Skip(start).Take(length).ToList<Mediadata>();

        //    return Json(new { data = objmedia, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);


        //}

        public ActionResult checked1()
            {
            var data = db.CustomerRentDatas.ToList<CustomerRentData>();

            return Json(data,JsonRequestBehavior.AllowGet);
            }
    }
}