using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class UserController : Controller
    {
        MusicLibraryModelDB db = new MusicLibraryModelDB();
        // GET: User
        public ActionResult UserAccountCreatePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAccountCreate(User user)
        {
            string message = "";
            try
            {
                var data = db.Users.Where(x => x.UserEmail == user.UserEmail || x.UserContact == user.UserContact).FirstOrDefault();
                if(data!=null)
                {
                    if(data.UserEmail==user.UserEmail)
                    {
                        message = "alredyusedemail";
                    }
                    else if(data.UserContact==user.UserContact)
                    {
                        message = "alreadycontactused";
                    }
                    else
                    {

                    }
                }
                else
                {
                    User objUser = new User();
                    objUser.UserName = user.UserName;
                    objUser.UserEmail = user.UserEmail;
                    objUser.UserContact = user.UserContact;
                    objUser.UserPasword = user.UserPasword;
                    objUser.UserAddress = user.UserAddress;
                    objUser.UserRoll = "User";
                    objUser.IsValid = true;
                    objUser.CreatedByDate = DateTime.Now;
                    db.Users.Add(objUser);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        //Session["UserEmail"] = user.UserEmail.ToString();
                        //Session["UserName"] = user.UserName.ToString();
                        //Session["UserId"] = credential.UserID;
                        message = "save";
                    }
                    else
                    {
                        message = "notsave";
                    }
                }

               

            }
            catch (Exception ex)
            {

                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public ActionResult ViewUserPage()
        {

            if (Session["AdminEmail"] == null)
            {
                return RedirectToAction("UserLoginPage", "Login");
            }
            else
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult ViewUserList()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.Users.Where(x => x.IsValid == true).ToList();

            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}