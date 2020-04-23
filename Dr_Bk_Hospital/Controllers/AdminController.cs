using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dr_Bk_Hospital.Controllers
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