using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VKHospital.Models;

namespace VKHospital.Controllers
{
    public class LoginController : Controller
    {
        VkHospitalDatabaseModel db = new VkHospitalDatabaseModel();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(PatientData patientData)
        {
            string message = "";

            try
            {
                byte[] EncDataByte = new byte[patientData.Password.Length];
                EncDataByte = System.Text.Encoding.UTF8.GetBytes(patientData.Password);
                string EncryptedData = Convert.ToBase64String(EncDataByte);

                var patientdata = db.PatientDatas.Where(x => x.Email == patientData.Email && x.Password == EncryptedData).FirstOrDefault();

                if (patientdata != null)
                {
                    if (patientdata.Roll == "Patient")
                    {
                        Session["patientUsername"] = patientdata.Email.ToString();
                        Session["PatientId"] = patientdata.PatientID.ToString();
                        Session["PatientSession"] = patientdata.SSNumber.ToString();

                        message = "patient";
                    }
                    else if (patientdata.Roll == "Doctor")
                    {
                        Session["DoctorUsername"] = patientdata.Email.ToString();
                        Session["DoctorId"] = patientdata.PatientID.ToString();
                        Session["DoctorSession"] = patientdata.SSNumber.ToString();

                        message = "doctor";
                    }
                    else if (patientdata.Roll == "Admin")
                    {
                        Session["AdminUsername"] = patientdata.Email.ToString();
                        Session["AdminId"] = patientdata.PatientID.ToString();
                        Session["AdminSession"] = patientdata.SSNumber.ToString();

                        message = "admin";
                    }
                    else
                    {
                        message = "";

                    }

                }
                else
                {
                    message = "invalid";
                }

            }
            catch (Exception ex)
            {
                message = "exception";
            }


            return Json(message, JsonRequestBehavior.AllowGet);

        }



        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }


        //-------------------password password---------------------------------------------------------

        public ActionResult EmailMatach(PatientData patientData)
        {
            string message = "";
            try
            {
                var objpatient = db.PatientDatas.Where(x => x.Email == patientData.Email).FirstOrDefault();
                if (objpatient != null)
                {
                    Random r = new Random();
                    int randNum = r.Next(1000000);
                    string sivenDigitNumber = randNum.ToString("D6");

                    EmailData emailData = new EmailData();
                    emailData.EmailOTP = sivenDigitNumber;
                    emailData.EmailTime = DateTime.Now;
                    emailData.PatientID = objpatient.PatientID;
                    emailData.IsValid = false;
                    emailData.CreatedByID = objpatient.PatientID;
                    emailData.CreateByDate = DateTime.Now;
                    db.EmailDatas.Add(emailData);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        using (MailMessage mm = new MailMessage("bablumaurya8052@gmail.com", objpatient.Email.ToString()))
                        {

                            mm.Subject ="password forgate";
                            string body = "";
                            body = "varification code => "+ sivenDigitNumber;
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
                            message = "EmailSend";
                           
                        };
                    }
                    else
                    {
                        message = "emailnotsend";
                    }

                      
                    }
                    else
                    {
                        message = "invalidemail";
                    }
                }
            catch (Exception ex)
            {

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult otpvarification(EmailData emailData)
        {
            var message = "";

            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var emailobj = db.EmailDatas.Where(x => x.EmailOTP == emailData.EmailOTP && x.IsValid==false).FirstOrDefault();
                if(emailobj != null)
                {
                    if (emailobj.EmailOTP == emailData.EmailOTP)
                    {
                        return Json(emailobj, JsonRequestBehavior.AllowGet);
                    }
                    
                }
                else
                {
                    message = "envalaidotp";
                }
            }
            catch(Exception ex)
            {
                message = "exception";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Patientpasswordchange(PatientData patientData)
        {
            string message = "";
            try
            {
                var objpatient = db.PatientDatas.Where(x => x.PatientID == patientData.PatientID).FirstOrDefault();
                if(objpatient!=null)
                {
                    byte[] EncDataByte = new byte[patientData.Password.Length];
                    EncDataByte = System.Text.Encoding.UTF8.GetBytes(patientData.Password);
                    string EncryptedData = Convert.ToBase64String(EncDataByte);

                    objpatient.Password = EncryptedData;
                    db.Entry(objpatient).State=EntityState.Modified;
                    int i = db.SaveChanges();
                    if(i>0)
                    {
                        var Emaildata = db.EmailDatas.Where(x => x.PatientID == patientData.PatientID && x.IsValid == false).FirstOrDefault();
                        if(Emaildata!=null)
                        {
                            if(Emaildata.PatientID==patientData.PatientID)
                            {
                                Emaildata.IsValid = true;
                                db.Entry(Emaildata).State = EntityState.Modified;
                                int j = db.SaveChanges();
                                if(j>0)
                                {
                                    message = "passwordchange";
                                }
                            }
                        }

                   
                    }
                    else
                    {
                        message = "passwordnnotchange";
                    }
                }
            }
            catch(Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }


}