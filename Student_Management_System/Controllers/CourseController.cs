using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class CourseController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: Course
        public ActionResult ViewRecords()
        {
            return View();
        }

        public ActionResult GetRecords()
        {
            var data = db.Courses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Add(Course course)
        {
            string message = "";

            try
            {
                Course objcourse = new Course();
                objcourse.CourseName = course.CourseName;
                objcourse.CreatedByData = DateTime.Now;
                objcourse.CreatedById = 1;
                db.Courses.Add(objcourse);
                int i=db.SaveChanges();
                if(i>0)
                {
                    message = "success";
                }
                else
                {
                    message = "error";
                }
            }
            catch
            {
                message = "exception";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }



        public ActionResult search(int id)
        {
            var data = db.Courses.Where(x => x.Id == id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult update(Course course)
        {
            string message = "";
            try
            {
                var data = db.Courses.Where(x => x.Id == course.Id).FirstOrDefault();

                data.CourseName = course.CourseName;
                data.ModifyByData = DateTime.Now;
                data.ModifyById = 1;
                db.Entry(data).State = EntityState.Modified;
               int i= db.SaveChanges();
                if(i>0)
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
                var data = db.Courses.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(data).State = EntityState.Deleted;
                int i = db.SaveChanges();
                if(i>0)
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
                message = "Deleteexception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}