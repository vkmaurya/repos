using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace Student_Management_System.Controllers
{
    public class CourseDetailsController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: CourseDetails
        public ActionResult CourseDetails()
        {

            return View();
        }

        [HttpGet]
        public ActionResult getallcoursedetails()
        {
            var data = db.CoursesDetails.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Coursesdropdownlist()
        {
            var data = db.Courses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Add(CoursesDetail curseDetail)
        {
            string message = "";

            try
            {
                CoursesDetail objcurseDetail = new CoursesDetail();

                objcurseDetail.CourseId = curseDetail.CourseId;
                objcurseDetail.CoursePrice = curseDetail.CoursePrice;
                objcurseDetail.CourseDuration = curseDetail.CourseDuration;
                objcurseDetail.CreatedByData = DateTime.Now;
                objcurseDetail.CreatedById = 1;
                db.CoursesDetails.Add(objcurseDetail);
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
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(int id)
        {
            var data = db.CoursesDetails.Where(x => x.Id == id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(CoursesDetail coursesDetail)
        {
            string message = "";

            try
            {
                var data = db.CoursesDetails.Where(x => x.Id == coursesDetail.Id).FirstOrDefault();
                data.CourseId = coursesDetail.CourseId;
                data.CoursePrice = coursesDetail.CoursePrice;
                data.CourseDuration = coursesDetail.CourseDuration;
                data.ModifyByData = DateTime.Now;
                data.ModifyById = 1;
                db.Entry(data).State = EntityState.Modified;
                int i=db.SaveChanges();

                if (i > 0)
                {
                    message = "updatesuccess";
                }
                else
                {
                    message = "updateerror";
                }
            }
            catch(Exception ex)
            {
                message = "updateexception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            string message = "";
            try
            {
                var data = db.CoursesDetails.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(data).State = EntityState.Deleted;
                int i = db.SaveChanges();

                if (i > 0)
                {
                    message = "Deletesuccess";
                }
                else
                {
                    message = "Deleteerror";
                }
            }
            catch(Exception ex)
            {

            }
           
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}