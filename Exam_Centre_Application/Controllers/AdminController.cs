using Exam_Centre_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Centre_Application.Controllers
{
    public class AdminController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: Admin


        public ActionResult AdminPage()
        {
            return View();
        }


        public ActionResult Adminlogin(Admin admin)
        {
            string message = "";

            var data = db.Admins.Where(x => x.Password == admin.Password && x.UserName == admin.UserName).FirstOrDefault();

            if(data!=null)
            {
                if(data.Password==admin.Password && data.UserName==data.UserName)
                {
                    Session["admin"] = data.UserName.ToString();

                    message = "login";
                }
                else
                {
                    message = "invalidusernameandpassword";
                }

            }
            else
            {
                message = "invalidusernameandpassword";

            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }


        public ActionResult AdminlogOut()
        {
            return View();
        }


        public ActionResult MasertPage()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View();
        }

        public ActionResult StudentPage()
        {
            if (Session["admin"]==null)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            var data = db.Students.ToList();
            return View(data);
        }
    }
}