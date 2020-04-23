using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vikash_Hospital.Models;

namespace vikash_Hospital.Controllers
{
    public class DoctorController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: Doctor
        public ActionResult MasterPage()
        {
            if (Session["patientSsno"]==null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult dropdownList()
        {
            var data = db.PatientDatas.Where(x => x.Roll == "Doctor").ToList();
             return Json(data,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult dropdownList1()
        {
            var data = db.PatientDatas.Where(x => x.Roll == "Patient").FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult dropdownList2()
        {
            var data = db.PatientDatas.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getpatientpro()
        {
            return View();
        }

        public ActionResult viewpatientpro()
        {
            return View();
        }
    }
}