using RolePllication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RolePllication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Modeldb db = new Modeldb();

       [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="User")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles ="Admin,User")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult UserList()
        {
            var data = db.Users.ToList();

            return View(data);
        }

       
    }
}