using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class CourseInformationController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: CourseInformation
        public ActionResult CourseInformation()
        {
            return View();
        }

        public ActionResult getallrecords()
        {
            var data = (from a in db.Courses
                        join c in db.CoursesDetails on a.Id equals c.CourseId
                        select new
                        { Course = a.Id, a.CourseName, CoursesDetail = c.CourseId, c.CoursePrice, c.CourseDuration }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}