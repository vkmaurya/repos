using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VKHospital.Models;
using VKHospital.VwModel;

namespace VKHospital.Controllers
{
    public class AppoimentController : Controller
    {
        VkHospitalDatabaseModel db = new VkHospitalDatabaseModel();
        // GET: Appoiment
        public ActionResult DoctorTypeName()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.DoctorTypes.Where(X => X.IsValid == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult DoctorNamedropdownlist(DoctorData doctorData)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.DoctorDatas.Where(x => x.DoctorTypeID == doctorData.DoctorTypeID && x.IsValid == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Sickdropdownlist(SickData sickData)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.SickDatas.Where(x => x.DoctorTypeID == sickData.DoctorTypeID && x.IsValid == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult PatientAppoiment(int[] id, PatientSelectSickData vwMoceldata)
        {
            string message = "";
            try
            {
                var patientid = Convert.ToInt32(Session["PatientId"]);
                var data = db.AppointmentDatas.Where(x => x.PatientID == patientid && x.AppointmentStatus == null || x.AppointmentStatus == false).FirstOrDefault();
                if (data != null)
                {
                    if (data.AppointmentStatus == null)
                    {
                        message = "alreadyexitdata";
                    }
                    else if (data.AppointmentStatus == false)
                    {
                        message = "alreadyexitdata";
                    }
                    else
                    {

                    }
                }
                else
                {
                    PatientSelectSickData patientSelectSickData = new PatientSelectSickData();
                    AppointmentData appointmentData = new AppointmentData();
                    for (int i = 0; i <= id.Length - 1; i++)
                    {
                        patientSelectSickData.DoctorID = vwMoceldata.DoctorID;
                        patientSelectSickData.PatientID = Convert.ToInt32(Session["PatientId"]);
                        patientSelectSickData.SickID = id[i];
                        patientSelectSickData.IsValid = false;
                        patientSelectSickData.CreateByDate = DateTime.Now;
                        patientSelectSickData.CreatedByID = Convert.ToInt32(Session["PatientId"]);
                        db.PatientSelectSickDatas.Add(patientSelectSickData);
                        db.SaveChanges();
                    }

                    appointmentData.DoctorID = vwMoceldata.DoctorID;
                    appointmentData.PatientID = Convert.ToInt32(Session["PatientId"]);
                    appointmentData.IsValid = true;
                    appointmentData.CreateByDate = DateTime.Now;
                    appointmentData.CreatedByID = Convert.ToInt32(Session["PatientId"]);
                    appointmentData.AppointmentBookingDate = DateTime.Now;
                    db.AppointmentDatas.Add(appointmentData);
                    int j = db.SaveChanges();
                    if (j > 0)
                    {
                        message = "save";
                    }
                    else
                    {
                        message = "notsave";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //------------------------patient appoiment ---------------------------------------
        public ActionResult GetPatientAppoimentpendingList()
        {
            if (Session["DoctorUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetPatientAppoimentpendingListdoctor()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Viewpandingpatientlist()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<AppointmentData> objdoctorTypes = new List<AppointmentData>();

            var appoimentdata = (from ap in db.AppointmentDatas.Where(x => x.AppointmentStatus == null)
                                 join dd in db.DoctorDatas on ap.DoctorID equals dd.DoctorId
                                 join pd in db.PatientDatas on ap.PatientID equals pd.PatientID
                                 select new
                                 {
                                     ap.AppointmentId,
                                     ap.AppointmentDateStart,
                                     ap.AppointmentDateEnd,
                                     ap.AppointmentStatus,
                                     ap.AppointmentPatientSession,
                                     ap.AppointmentBookingDate,
                                     dd.DoctorId,
                                     dd.DoctorName,
                                     pd.PatientID,
                                     pd.PatientName,
                                     pd.SSNumber
                                 }).ToList();

            var data = new { data = appoimentdata };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetpatientAppointmentsick(PatientSelectSickData patientSelectSickData)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<AppointmentData> objdoctorTypes = new List<AppointmentData>();

            var appoimentdata = (from ps in db.PatientSelectSickDatas.Where(x => x.PatientID == patientSelectSickData.PatientID && x.IsValid == false)
                                 join sd in db.SickDatas on ps.SickID equals sd.SickTypeID
                                 select new
                                 {
                                     ps.PatientID,
                                     ps.DoctorID,
                                     sd.SickTypeID,
                                     sd.SickTypeName,

                                 }).ToList();


            return Json(appoimentdata, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SetAppoimentPatient(AppointmentData appointmentData)
        {
            string message = "";

            try
            {


                var credentialdata = db.AppointmentDatas.Where(x => x.PatientID == appointmentData.PatientID && x.AppointmentStatus == null).FirstOrDefault();
                if (credentialdata != null)
                {

                    credentialdata.AppointmentDateStart = appointmentData.AppointmentDateStart;
                    credentialdata.AppointmentDateEnd = appointmentData.AppointmentDateEnd;
                    credentialdata.AppointmentPatientSession = appointmentData.AppointmentPatientSession;
                    credentialdata.AppointmentStatus = false;
                    db.Entry(credentialdata).State = System.Data.Entity.EntityState.Modified;
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


        public ActionResult Doctorsetaptinetappoimentdonepage()
        {
            if (Session["DoctorUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewDoctorsetaptinetappoimentdone()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<AppointmentData> objdoctorTypes = new List<AppointmentData>();

            var appoimentdata = (from ap in db.AppointmentDatas.Where(x => x.AppointmentStatus == false)
                                 join dd in db.DoctorDatas on ap.DoctorID equals dd.DoctorId
                                 join pd in db.PatientDatas on ap.PatientID equals pd.PatientID
                                 select new
                                 {
                                     ap.AppointmentId,
                                     ap.AppointmentDateStart,
                                     ap.AppointmentDateEnd,
                                     ap.AppointmentStatus,
                                     ap.AppointmentPatientSession,
                                     ap.AppointmentBookingDate,
                                     dd.DoctorId,
                                     dd.DoctorName,
                                     pd.PatientID,
                                     pd.PatientName,
                                     pd.SSNumber
                                 }).ToList();

            var data = new { data = appoimentdata };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewDoctorsetaptinetappoimentcomplatespage()
        {

            if (Session["DoctorUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult ViewDoctorsetaptinetappoimentcomplates()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<AppointmentData> objdoctorTypes = new List<AppointmentData>();

            var appoimentdata = (from ap in db.AppointmentDatas.Where(x => x.AppointmentStatus == true)
                                 join dd in db.DoctorDatas on ap.DoctorID equals dd.DoctorId
                                 join pd in db.PatientDatas on ap.PatientID equals pd.PatientID
                                 select new
                                 {
                                     ap.AppointmentId,
                                     ap.AppointmentDateStart,
                                     ap.AppointmentDateEnd,
                                     ap.AppointmentStatus,
                                     ap.AppointmentPatientSession,
                                     ap.AppointmentBookingDate,
                                     dd.DoctorId,
                                     dd.DoctorName,
                                     pd.PatientID,
                                     pd.PatientName,
                                     pd.SSNumber
                                 }).ToList();

            var data = new { data = appoimentdata };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //------------------------------AppimentConfirmdone------------------------------------------------------------------

        public ActionResult AppimentConfirmdone(AppointmentData appointmentData)
        {
            string message = "";
            try
            {
                var objappoimentdate = db.AppointmentDatas.Where(x => x.AppointmentStatus == false && x.PatientID == appointmentData.PatientID).FirstOrDefault();

                var objpatientSick = db.PatientSelectSickDatas.Where(x => x.PatientID == appointmentData.PatientID && x.IsValid == false).ToList();

                if (objappoimentdate != null)
                {
                    if (objpatientSick != null)
                    {

                        foreach (var data in objpatientSick)
                        {
                            data.IsValid = true;
                            db.Entry(data).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                        objappoimentdate.AppointmentStatus = true;
                        db.Entry(objappoimentdate).State = EntityState.Modified;
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


            }
            catch (Exception ex)
            {

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------Patient Chech appoiment-----------------------------------------------------

        public ActionResult patientcheckAppoiment()
        {
            return View();
        }


        [HttpGet]
        public ActionResult patientCheckAppoiimentshudal()
        {
            db.Configuration.ProxyCreationEnabled = false;
            int patientid =Convert.ToInt32(Session["PatientId"]);

            var appoimentdata = (from ap in db.AppointmentDatas.Where(x =>x.PatientID== patientid && x.AppointmentStatus == true)
                                 join dd in db.DoctorDatas on ap.DoctorID equals dd.DoctorId
                                 join pd in db.PatientDatas on ap.PatientID equals pd.PatientID
                                 select new
                                 {
                                     ap.AppointmentId,
                                     ap.AppointmentDateStart,
                                     ap.AppointmentDateEnd,
                                     ap.AppointmentStatus,
                                     ap.AppointmentPatientSession,
                                     ap.AppointmentBookingDate,
                                     dd.DoctorId,
                                     dd.DoctorName,
                                     pd.PatientID,
                                     pd.PatientName,
                                     pd.SSNumber
                                 }).ToList();

           
            return Json(appoimentdata, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult patientCheckAppoiimentshudalpanding()
        {
            db.Configuration.ProxyCreationEnabled = false;
            int patientid = Convert.ToInt32(Session["PatientId"]);

            var appoimentdata = (from ap in db.AppointmentDatas.Where(x => x.PatientID == patientid && x.AppointmentStatus == null || x.AppointmentStatus == false)
                                 join dd in db.DoctorDatas on ap.DoctorID equals dd.DoctorId
                                 join pd in db.PatientDatas on ap.PatientID equals pd.PatientID
                                 select new
                                 {
                                     ap.AppointmentId,
                                     ap.AppointmentDateStart,
                                     ap.AppointmentDateEnd,
                                     ap.AppointmentStatus,
                                     ap.AppointmentPatientSession,
                                     ap.AppointmentBookingDate,
                                     dd.DoctorId,
                                     dd.DoctorName,
                                     pd.PatientID,
                                     pd.PatientName,
                                     pd.SSNumber
                                 }).ToList();


            return Json(appoimentdata, JsonRequestBehavior.AllowGet);
        }

    }
}