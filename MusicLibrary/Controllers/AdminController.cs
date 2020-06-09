using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult AdminMasterPage()
        {
            if(Session["AdminEmail"]==null)
            {
                return RedirectToAction("UserLoginPage", "Login");
            }
            else
            {
                return View();
            }
           
        }
    }
}