using Exam_Centre_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Exam_Centre_Application.Controllers
{
    public class HomeController : Controller
    {
        Modeldb db = new Modeldb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourseName()
        {
            var data = db.Courses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult StudentLogin(Student student)
        {
            string message = "";

            try
            {
                var data = db.Students.Where(x => x.Email == student.Email && x.Password == student.Password).FirstOrDefault();
                if(data!=null)
                {
                    if (data.Email == student.Email && data.Password == student.Password)
                    {
                        Session["Username"] = student.Email.ToString();
                        Session["id"] = data.Id;
                        Session["passwword"] = student.Password.ToString();
                        message = "login";
                    }
                }
              
                else
                {
                    message = "invalid";
                }

            }
            catch (Exception ex)
            {

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult StudentLogin(Student student, string ReturnUrl)
        //{
        //    string message = "";

        //    try
        //    {

        //        var data = db.Students.Where(model => model.Email == student.Email && model.Password == student.Password).FirstOrDefault();

        //        if (data != null)
        //        {
        //            if (data.Email == student.Email && data.Password == student.Password)
        //            {
        //                FormsAuthentication.SetAuthCookie(student.Email, false);
        //                Session["StudentName"] = student.Email.ToString();
        //                if (ReturnUrl != null)
        //                {
        //                    return Redirect(ReturnUrl);
        //                }
        //                else
        //                {
        //                    return RedirectToAction("Contact", "Home");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            message = "invalid";
        //        }
        //    }
        //    catch (Exception Ex)
        //    {

        //    }


        //    return Json(message, JsonRequestBehavior.AllowGet);
        //}



        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Session["Username"] = null;

            return RedirectToAction("Index","Home");
        }


        public ActionResult emaildropdownlist()
        {
            var data = db.Students.ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}