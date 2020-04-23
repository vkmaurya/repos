using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotal_Management_System.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult MasterPage()
        {
            return View();
        }
    }
}