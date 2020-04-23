using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApplication.Models;

namespace webApplication.Controllers
{
    public class RentController : Controller
    {
        ModelDB db = new ModelDB();
        // GET: Rent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Getcar()
        {
            var data = db.carregs.ToList<carreg>();

            return Json(data,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.customers where s.Id == id select s.custname).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
    }
}