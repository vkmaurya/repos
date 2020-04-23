using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using vikash_Hospital.Models;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace vikash_Hospital.Controllers
{
    public class PatientController : Controller
    {
        Modeldb db = new Modeldb();

        // GET: Patient
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult Registration(PatientData patient)
        {
            string message = "";
            PatientData objpatient = new PatientData();
            try
            {

                byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(patient.Password);
                HashAlgorithm hash = new SHA256Managed();
                var originalPassword = hash.ComputeHash(plainTextBytes);

                Random r = new Random();
                int randNum = r.Next(10000000);
                string sivenDigitNumber = randNum.ToString("D7");


                objpatient.Ssno = sivenDigitNumber;
                objpatient.Name = patient.Name;
                objpatient.Dob = patient.Dob;
                objpatient.Address = patient.Address;
                objpatient.Contact = patient.Contact;
                objpatient.Password = originalPassword.ToString();

                objpatient.Email = patient.Email;
                objpatient.CreatedByDate = DateTime.Now;
                objpatient.Roll = "Patient";
                objpatient.IsValid = true;

                db.PatientDatas.Add(objpatient);
                int i = db.SaveChanges();

                if (i > 0)
                {
                    message = "registrationsuccessfullyadd";

                    Guid activationCode = Guid.NewGuid();
                    using (MailMessage mm = new MailMessage("bablumaurya8052@gmail.com", patient.Email.ToString()))
                    {
                        mm.Subject = "Account Activation";
                        string body = "Hello " + patient.Name + ",";
                      
                        body = "Welcome "+ patient.Name;
                        body = "Registration Done ";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("bablumaurya8052@gmail.com", "8052731725");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        message = "PleaseWait Email Send...";
                    }
                }
                else
                {
                    message = "registrationnotadd";
                }

            }
            catch (Exception ex)
            {
                var s = ex;

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Get()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ViewPatientList()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<PatientData> user = new List<PatientData>();

            user = db.PatientDatas.Where(x => x.IsValid == true).ToList<PatientData>();
            int totalrows = user.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                user = user.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.Name.ToLower().Contains(searchvalue.ToLower()) || x.Dob.ToLower().Contains(searchvalue.ToLower()) || x.Contact.ToLower().Contains(searchvalue.ToLower()) || x.Email.ToLower().Contains(searchvalue.ToLower()) || x.Address.ToLower().Contains(searchvalue.ToLower())).ToList<PatientData>();
            }
            int totalrawsafterfiltering = user.Count;
            //sorting
            user = user.OrderBy(SearchColumnName + " " + SortDirection).ToList<PatientData>();

            //paging

            user = user.Skip(start).Take(length).ToList<PatientData>();

            return Json(new { data = user, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int Id)
        {
            string message = "";

            try
            {
                PatientData objpatient = (from u in db.PatientDatas
                                          where u.Id == Id
                                          select u).FirstOrDefault();
                objpatient.IsValid =false;
                db.Entry(objpatient).State = EntityState.Modified;
              int i=  db.SaveChanges();
                if(i>0)
                {
                    message = "recordsdeleted";
                }
                else
                {
                    message = "recordnotdeleted";
                }

            }
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Search(int Id)
        {
            var data = db.PatientDatas.Where(x => x.Id == Id).FirstOrDefault();

            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(PatientData patientData)
        {
            string message = "";

            try
            {
                PatientData objpatient = (from u in db.PatientDatas
                                          where u.Id == patientData.Id
                                          select u).FirstOrDefault();

                
                objpatient.Name = patientData.Name;
                objpatient.Dob = patientData.Dob;
                objpatient.Email = patientData.Email;
                objpatient.Address = patientData.Address;
                objpatient.Contact = patientData.Contact;
                objpatient.ModifyByDate = DateTime.Now;
                objpatient.ModifyById =Convert.ToInt32(Session["adminId"]);

                db.Entry(objpatient).State = EntityState.Modified;
                int i = db.SaveChanges();
                if (i > 0)
                {
                    message = "recordupdate";
                    Guid activationCode = Guid.NewGuid();
                    using (MailMessage mm = new MailMessage("bablumaurya8052@gmail.com", patientData.Email.ToString()))
                    {
                        mm.Subject = "Account Activation";
                        string body = "Hello " + patientData.Name + ",";
                        body = "<h1>Hello " + patientData.Name + "</h1></br><table border='1px'><thead><tr><th>SSNO</th><th>NAME</th><th>DOB</th><th>ADDRESS</th><th>CONTACT</th><th>EMAIL</th></tr></thead><tbody><tr><td>" + objpatient.Ssno+ "</td><td>" + objpatient.Name + "</td><td>" + objpatient.Dob + "</td><td>" + objpatient.Address + "</td><td>" + objpatient.Contact + "</td><td>" + objpatient.Email + "</td></tr><tr><td>" + objpatient.Ssno + "</td><td>" + patientData.Name + "</td><td>" + patientData.Dob + "</td><td>" + patientData.Address + "</td><td>" + patientData.Contact + "</td><td>" + patientData.Email + "</td> </tr></tbody></table>";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("bablumaurya8052@gmail.com", "8052731725");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                       
                    }
                }
                else
                {
                    message = "recordnotupdate";
                }

            }
            catch (Exception ex)
            {
                message = "exception";
                    
            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public  ActionResult createproblame(Problame problame)
        {
            string message = "";

            try
            {
                Problame objproblame = new Problame();
                objproblame.DoctorId = problame.DoctorId;
                objproblame.PatientSsno = Session["patientSsno"].ToString();
                objproblame.ProblameId = problame.ProblameId;
                objproblame.CreateDate = DateTime.Now;
                db.Problames.Add(objproblame);
                int i=db.SaveChanges();
                if(i>0)
                {
                    message = "registrationdone";
                }
                else
                {
                    message = "registrationnotdone";
                }

            }
            catch (Exception ex)
            {
                message = "oopssomethingwrong";
            
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult TodayPatient()
        {
            var data = db.Problames.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult GetProblame()
        {
            var today = DateTime.Now;
            var data = db.Problames.Where(m => m.CreateDate == today).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
           
        }
    }


}