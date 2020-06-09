using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VKHospital.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminMasterPage()
        {
            if (Session["AdminUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                return View();
            }
          
        }
    }
}