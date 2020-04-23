using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Centre_Application.Controllers
{
   
    public class ExameController : Controller
    {
        // GET: Exame
        public ActionResult studentMasterPage()
        {
            if(Session["Username"]==null)
            {
                return RedirectToAction("Contact", "Home");
            }
            return View();
        }
    }
}