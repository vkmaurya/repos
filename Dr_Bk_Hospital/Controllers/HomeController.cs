using Dr_Bk_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dr_Bk_Hospital.Controllers
{
    public class HomeController : Controller
    {
        DbModel db = new DbModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }


        public JsonResult Login(PatientData patientData)
        {
            string message = "";
            var data = db.PatientDatas.Where(x => x.Email == patientData.Email && x.Password == patientData.Password).FirstOrDefault();

            if (data != null)
            {
                if (data.Roll == "Admin")
                {
                    Session["Adminusername"] = data.Email.ToString();
                    Session["Adminuserid"] = data.Id.ToString();

                    message = "adminurl";

                }
                else if (data.Roll == "Doctor")
                {
                    Session["Doctorusername"] = data.Email.ToString();
                    Session["Doctoruserid"] = data.Id.ToString();

                    message = "Doctorurl";

                }
                else if (data.Roll == "Patinet")
                {


                }
                else
                {

                }
            }
            else
            {
                message = "usernameandpasswordinvalid";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}