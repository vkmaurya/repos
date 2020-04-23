using Music_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MusicModel1Db db = new MusicModel1Db();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login(UserData objuser)
        {
            UserData data = db.UserDatas.Where(model => model.Email == objuser.Email && model.Password == objuser.Password).SingleOrDefault();
            if (data != null)
            {
                if (data.Roll == "Admin")
                {
                    Session["adminid"] = data.Id.ToString();
                    Session["adminname"] = data.Email.ToString();

                    return RedirectToAction("Admin", "MasterPage");
                }
                else if (data.Roll == "User")
                {
                    Session["userid"] = data.Id.ToString();
                    Session["UserName"] = data.Email.ToString();
                    ViewBag.Message = data.Email;
                }
                return RedirectToAction("Index");
            }

            else
           {
                ViewBag.error = "Invalid  UserName or password";
            }
            return View();
        }

        public ActionResult logout()
        {

            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");


        }

    }
}