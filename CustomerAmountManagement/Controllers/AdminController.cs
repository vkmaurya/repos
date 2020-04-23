using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerAmountManagement.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult MasterPage()
        {
            if (Session["UserName"] ==null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public ActionResult CustomerGetData()
        {
            return View();
        }
    }
}