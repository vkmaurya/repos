using RolePllication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RolePllication.Controllers
{
    public class AccountController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(user);
                int i = db.SaveChanges();
                if(i>0)
                {
                    return Redirect("Login");
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user,string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                var data = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                if(data!=null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Session["username"] = user.UserName.ToString();
                    if(ReturnUrl!=null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}