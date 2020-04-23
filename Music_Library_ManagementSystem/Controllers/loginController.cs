using Music_Library_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_ManagementSystem.Controllers
{
    public class loginController : Controller
    {
        // GET: Login

        Music_ModelDb db = new Music_ModelDb();

        [HttpGet]
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public JsonResult Login(Customer customer)
        {
            string message = "";

            try
            {
                var objdb = db.Customers.Where(x => x.Email == customer.Email && x.Password == customer.Password).FirstOrDefault();

                if (objdb != null)
                {

                    if (objdb.Roll == "Admin")
                    {

                        Session["adminid"] = objdb.Id.ToString();
                        Session["adminusername"] = objdb.Email.ToString();
                        Session["adminname"] = objdb.Name.ToString();


                        message = "adminSuccess";


                        //return Json(new
                        //{
                        //    redirectUrl = Url.Action("Masterpage", "Admin"),
                        //    isRedirect = true
                        //});

                        //return RedirectToAction("Masterpage", "Admin");
                        //return RedirectToRoute(,);







                    }
                    else if (objdb.Roll == "User")
                    {
                        Session["customerid"] = objdb.Id.ToString();
                        Session["custmoerusername"] = objdb.Email.ToString();
                        Session["custmoername"] = objdb.Name.ToString();
                        Session["custmoertype"] = objdb.Membership.ToString();


                        message = "userSuccess";


                        //return RedirectToAction("Index", "Home");
                        //return Json(new
                        //{
                        //    redirectUrl = Url.Action("Index", "Home"),
                        //    isRedirect = true
                        //});
                    }
                    else
                    {
                        //ViewBag.mess = "invalid username and password ";
                        message = "InvalidUsernamePasssword";
                    }
                }
                else
                {
                    // ViewBag.mess = "invalid username and password ";
                    message = "InvalidUsernamePasssword";

                }
            }


            catch (Exception ex)
            {

            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }




        public ActionResult logout()
        {

            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");


        }
    }
}