using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_ManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Masterpage()
        {
           
            if (Session["adminusername"] == null)
            {
                return RedirectToAction("Login" ,"login");
            }
            return View();
        }
    }
}