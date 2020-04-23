using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        Modeldb db = new Modeldb();

        // GET: Student
        public ActionResult Student()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Add(Student student)
        {
            string message = "";

            try
            {
                Student objstudent = new Student();
                objstudent.Name = student.Name;
                objstudent.Gander = student.Gander;
                objstudent.Contact = student.Contact;
                objstudent.Email = student.Email;
                objstudent.Address = student.Address;
                objstudent.Collage = student.Collage;
                objstudent.Duration = student.Duration;
                objstudent.Amount = student.Amount;
                objstudent.CourseName = student.CourseName;
                objstudent.RegistrationDate = DateTime.Now;

                db.Students.Add(objstudent);
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
            catch(Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Searchstudent(int id)
        {

            var data = db.Students.Where(x => x.Id == id).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Update(Student student)
        {
            string message = "";
            try
            {
                var data = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
                data.Name = student.Name;
                data.Gander = student.Gander;
                data.Contact = student.Contact;
                data.Email = student.Email;
                data.Address = student.Address;
                data.Collage = student.Collage;
                data.CourseName = student.CourseName;
                data.Amount = student.Amount;
                data.Duration = student.Duration;
                db.Entry(data).State = EntityState.Modified;
                int i = db.SaveChanges();


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
                var data = db.Students.Where(x => x.Id == id).FirstOrDefault();

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
                message = "";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult dropdownlist()
        {
            var data = db.Courses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult dropdownduration(int id)
        {
            var data = db.CoursesDetails.Where(x=>x.CourseId==id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult coursesfee(int Id)
        {
            var data = db.CoursesDetails.Where(x => x.Id ==Id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}