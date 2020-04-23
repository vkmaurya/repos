using AppAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAjax.Controllers
{
    public class HomeController : Controller
    {

        StudentModelDb db = new StudentModelDb();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudentData()
        {
            var data = db.Students.ToList<Student>();

            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddStudentRecords(Student ObjStudent)
        {
            string message = "";
            Student studentobject = new Student();
            try
            {
                if(ObjStudent !=null)
                {
                    studentobject.Name = ObjStudent.Name;
                    studentobject.Email = ObjStudent.Email;
                    studentobject.Address = ObjStudent.Address;
                    studentobject.Contact = ObjStudent.Contact;
                    db.Students.Add(studentobject);
                    int i=db.SaveChanges();
                    if(i > 0)
                    {
                        message = "RecordsSave";
                    }
                    else
                    {
                        message = "recordsnotsave";
                    }


                }

            }
            catch(Exception ex)
            {

            }


            return Json(message,JsonRequestBehavior.AllowGet);
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
    }
}