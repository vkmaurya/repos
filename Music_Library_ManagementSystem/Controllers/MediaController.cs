using Music_Library_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Music_Library_ManagementSystem.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media

        Music_ModelDb db = new Music_ModelDb();




        public ActionResult GetMediaRecords()
        {

            if (Session["adminusername"] == null)
            {
                return RedirectToAction("Login", "login");
            }
            else
            {
                return View();
            }

            //var data = db.Mediadatas.ToList<Mediadata>();
            

        }



        [HttpPost]
        public ActionResult GetMediaData()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<Mediadata> objmedia = new List<Mediadata>();


            objmedia = db.Mediadatas.ToList<Mediadata>();
            int totalrows = objmedia.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                objmedia = objmedia.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.AuthorName.ToString().Contains(searchvalue.ToLower()) || x.CategoryName.ToLower().Contains(searchvalue.ToLower()) || x.CategoryNumber.ToLower().Contains(searchvalue.ToLower()) || x.Title.ToLower().Contains(searchvalue.ToLower()) || x.Description.ToLower().Contains(searchvalue.ToLower()) || x.Price.ToLower().Contains(searchvalue.ToLower()) || x.Media_Status.ToString().Contains(searchvalue.ToLower())).ToList<Mediadata>();
            }
            int totalrawsafterfiltering = objmedia.Count;
            //sorting
            objmedia = objmedia.OrderBy(SearchColumnName + " " + SortDirection).ToList<Mediadata>();

            //paging

            objmedia = objmedia.Skip(start).Take(length).ToList<Mediadata>();

            return Json(new { data = objmedia, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);



        }


        [HttpPost]
        public ActionResult CreateMedia(Mediadata objmedia)
        {
            if (ModelState.IsValid)
            {
                db.Mediadatas.Add(new Mediadata
                {
                    AuthorName = objmedia.AuthorName,
                    CategoryName = objmedia.CategoryName,
                    CategoryNumber = objmedia.CategoryNumber,
                    Title = objmedia.Title,
                    Description = objmedia.Description,

                    Price = objmedia.Price,
                    Media_Status = objmedia.Media_Status,
                    Createdby_Date = DateTime.Now,

                });

                var result = db.SaveChanges();

                if (result > 0)
                {

                    Response.Write("<script>Registration Succefully... </script>");

                }
                else
                {
                    Response.Write("<script>Some problems </script>");
                }

            }

            return View(objmedia);

        }



        [HttpPost]
        public ActionResult MediaSearchdata(int Id)

        {

            var data = db.Mediadatas.Where(x => x.Id == Id).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult mediaupdaterecords(Mediadata mediaupdate)
        {
            try
            {
                var updatemedia = (from u in db.Mediadatas
                                   where u.Id == mediaupdate.Id
                                   select u).FirstOrDefault();

                updatemedia.AuthorName = mediaupdate.AuthorName;
                updatemedia.CategoryName = mediaupdate.CategoryName;
                updatemedia.CategoryNumber = mediaupdate.CategoryNumber;
                updatemedia.Title = mediaupdate.Title;

                updatemedia.Description = mediaupdate.Description;
                updatemedia.Price = mediaupdate.Price;
                updatemedia.Media_Status = mediaupdate.Media_Status;


                updatemedia.Modifiedby_Id = Convert.ToInt32(Session["adminid"].ToString());
                updatemedia.Modifiedby_Data = DateTime.Now;

                db.Entry(updatemedia).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public ActionResult Deletemedia(int id)
        {
            try
            {
                var mediaid = db.Mediadatas.Where(x => x.Id == id).FirstOrDefault();
                if (mediaid != null)
                {
                    db.Entry(mediaid).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                return Content("some problem");
            }
            return RedirectToAction("Index");

        }

//---------------------------------------------------------------------------------------------------------------------------------



     


    }
}