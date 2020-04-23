using CustomerAmountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomerAmountManagement.Controllers
{
    public class HomeController : Controller
    {
        DBModel db = new DBModel();

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(Admin admin, string ReturnUrl)
        //{
        //    string message = "";
        //    if(IsValid(admin)==true)
        //    {
        //        //var data = db.Admins.Where(x => x.UserName == admin.UserName && x.Password == admin.Password).FirstOrDefault();


        //        FormsAuthentication.SetAuthCookie(admin.UserName, false);
        //        Session["UserName"] = admin.UserName.ToString();
        //        Session["Id"] = admin.Id.ToString();

               
        //        if(ReturnUrl !=null)
        //        {
                    

        //                return Redirect(ReturnUrl);


        //        }
        //        else
        //        {
                    
        //            return RedirectToAction("MasterPage", "Admin");

        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
           
        //}


        //public bool IsValid(Admin admin)
        //{
        //    var credentials = db.Admins.Where(x => x.UserName == admin.UserName && x.Password == admin.Password).FirstOrDefault();
        //    return (admin.UserName == credentials.UserName && admin.Password == credentials.Password);
        //}


        //public ActionResult Logout()
        //{

        //    FormsAuthentication.SignOut();
        //    Session["username"] = null;
        //    return RedirectToAction("Index", "Home");
        //}

         public JsonResult Login(Admin admin)
        {
            string message = "";

            var data = db.Admins.Where(x => x.UserName == admin.UserName && x.Password == admin.Password).FirstOrDefault();

            if(data.UserName==admin.UserName)
            {
                Session["UserName"] = admin.UserName.ToString();
                Session["Id"] = data.Id.ToString();

                message = "adminlogin";
            }
            else
            {
                message = "invalidpassword";
            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Logout()
        {
           
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "Home");
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