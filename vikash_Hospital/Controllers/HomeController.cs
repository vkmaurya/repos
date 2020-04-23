using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vikash_Hospital.Models;

namespace vikash_Hospital.Controllers
{
    public class HomeController : Controller
    {
        Modeldb db = new Modeldb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login(PatientData patientData)
        {
            return View();
        }

        public ActionResult LoginAction(PatientData patientData)
        {
            string message = "";
            PatientData objpatientData = new PatientData();
            try
            {
                var data = db.PatientDatas.Where(x => x.Email == patientData.Email && x.Password == patientData.Password).FirstOrDefault();
                if (data != null)
                {
                    if (data.Roll == "Doctor")
                    {
                        Session["doctorname"] = data.Name;
                        Session["doctorId"] = data.Id;
                        message = "doctor";

                    }
                    else if (data.Roll == "Admin")
                    {
                        Session["adminname"] = data.Name;
                        Session["adminId"] = data.Id;
                        message = "patient";
                    }
                    else if (data.Roll == "Patient")
                    {
                        Session["Patientname"] = data.Name;
                        Session["patientId"] = data.Id;
                        Session["patientSsno"] = data.Ssno;
                        message = "patient";
                    }
                    else
                    {
                        message = "OopsSemthingWrong";
                    }

                }
                else
                {
                    message = "usernamepasswordinvalid";
                }

            }
            catch (Exception ex)
            {

            }
            return Json(message,JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Appoiment()
        {
            return View();
        }
    }
}