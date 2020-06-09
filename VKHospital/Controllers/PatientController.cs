using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using VKHospital.Models;

namespace VKHospital.Controllers
{
    public class PatientController : Controller
    {

        VkHospitalDatabaseModel db = new VkHospitalDatabaseModel();
        // GET: Patient
        public ActionResult PatientRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationandUpdate(PatientData patientData)
        {
            string message = "";
            try
            {
                if (patientData != null)
                {

                    var emaildata = db.PatientDatas.Where(x => x.Email == patientData.Email || x.PhoneNumber == patientData.PhoneNumber).FirstOrDefault();


                    if (emaildata != null)
                    {
                        if (emaildata.Email == patientData.Email)
                        {
                            message = "alreadyemailexit";
                        }
                        else if (emaildata.PhoneNumber == patientData.PhoneNumber)
                        {
                            message = "alreadycontactexit";
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        byte[] EncDataByte = new byte[patientData.Password.Length];
                        EncDataByte = System.Text.Encoding.UTF8.GetBytes(patientData.Password);
                        string EncryptedData = Convert.ToBase64String(EncDataByte);

                        Random r = new Random();
                        int randNum = r.Next(10000000);
                        string sivenDigitNumber = randNum.ToString("D7");

                        PatientData objpatientData = new PatientData();
                        objpatientData.PatientName = patientData.PatientName;
                        objpatientData.Gander = patientData.Gander;
                        objpatientData.DOB = patientData.DOB;
                        objpatientData.Email = patientData.Email;
                        objpatientData.Password = EncryptedData;
                        objpatientData.Address = patientData.Address;
                        objpatientData.PhoneNumber = patientData.PhoneNumber;
                        objpatientData.SSNumber = sivenDigitNumber;
                        objpatientData.Roll = "Patient";
                        objpatientData.IsValid = true;
                        objpatientData.CreateByDate = DateTime.Now;

                        db.PatientDatas.Add(objpatientData);
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "save";
                        }
                        else
                        {
                            message = "notsave";
                        }
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllListPatient()
        {

            return View();
        }


        [HttpGet]
        public ActionResult GetAllPatientsdata()
        {
            if (Session["AdminUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                List<PatientData> testList = new List<PatientData>();
                db.Configuration.ProxyCreationEnabled = false;
                testList = db.PatientDatas.ToList();
                var obj = new { data = testList };
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Patientprofile()
        {
            if (Session["patientUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewPatientprofile()
        {
            if (Session["PatientId"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                db.Configuration.ProxyCreationEnabled = false;
                var patientid = Convert.ToInt32(Session["PatientId"]);
                var data = db.PatientDatas.Where(x => x.PatientID == patientid && x.IsValid == true).FirstOrDefault();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult SearchProfiledata(PatientData patientData)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.PatientDatas.Where(x => x.PatientID == patientData.PatientID).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult patientupdateprofile(PatientData patientData)
        {
            string message = "";
            try
            {
                if (patientData != null)
                {
                    var objpatientData = db.PatientDatas.Where(x => x.PatientID == patientData.PatientID).FirstOrDefault();

                    objpatientData.PatientName = patientData.PatientName;
                    objpatientData.Gander = patientData.Gander;
                    objpatientData.DOB = patientData.DOB;
                    objpatientData.Email = patientData.Email;
                    objpatientData.Address = patientData.Address;
                    objpatientData.PhoneNumber = patientData.PhoneNumber;
                    objpatientData.ModifyBYDate = DateTime.Now;
                    objpatientData.ModifyByID = Convert.ToInt32(Session["PatientId"]);
                    db.Entry(objpatientData).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "save";
                    }
                    else
                    {
                        message = "notsave";
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        //------------------------------Appoiment Shudale start ------------------------------------------------------------------

    }
}