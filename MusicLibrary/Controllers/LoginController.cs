
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicLibrary.Controllers
{
    public class LoginController : Controller
    {
        MusicLibraryModelDB db = new MusicLibraryModelDB();

        // GET: Login
        public ActionResult UserLoginPage()
        {
            return View();
        }

        public ActionResult UserLogin(User user, string ReturnUrl)
        {
            string message = "";

            try
            {
                if (user != null)
                {
                    var credential = db.Users.Where(x => x.UserEmail == user.UserEmail && x.UserPasword == user.UserPasword).FirstOrDefault();

                    if (credential != null)
                    {
                        if (credential.UserEmail == user.UserEmail && credential.UserPasword == user.UserPasword)
                        {
                            if (credential.UserRoll == "User")
                            {
                                FormsAuthentication.SetAuthCookie(user.UserEmail, false);

                                Session["UserEmail"] = credential.UserEmail.ToString();
                                Session["UserName"] = credential.UserName.ToString();
                                Session["UserId"] = credential.UserID;
                                message = "User";


                            }
                            else if (credential.UserRoll == "Admin")
                            {
                                FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                                Session["AdminEmail"] = credential.UserEmail.ToString();
                                Session["AdminName"] = credential.UserName.ToString();
                                Session["AdminId"] = credential.UserID;
                                message = "Admin";


                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        message = "InvalidUserNameAndPassword";
                    }

                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }




        public ActionResult UserLogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            Session["UserEmail"] = null;
            Session["AdminEmail"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}

