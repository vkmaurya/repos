using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class CounterController : Controller
    {
        // GET: Counter
        public ActionResult CounterPage()
        {
            return View();
        }
    }
}