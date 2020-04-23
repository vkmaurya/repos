using Exam_Centre_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Exam_Centre_Application.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Modeldb db = new Modeldb();






        [HttpPost]
        public JsonResult registration(Student student)
        {
            string message = "";

            Student objstudent = new Student();

            try
            {
                Random r = new Random();
                int randNum = r.Next(1000000);
                string sixDigitNumber = randNum.ToString("D6");

                var profile = Request.Files;

                string imgname = string.Empty;
                string ImageName = string.Empty;

                //Following code will check that image is there 
                //If it will Upload or else it will use Default Image

                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var logo = System.Web.HttpContext.Current.Request.Files["file"];
                    if (logo.ContentLength > 0)
                    {
                        var profileName = Path.GetFileName(logo.FileName);
                        var ext = Path.GetExtension(logo.FileName);

                        ImageName = profileName;
                        var comPath = Server.MapPath("~/images1/") + ImageName;

                        logo.SaveAs(comPath);
                        imgname = student.Images = comPath;
                    }

                }
                else
                    student.Images = Server.MapPath("~/images1/") + "profile.jpg";

                message = 1.ToString();


                objstudent.Name = student.Name;
                objstudent.Gander = student.Gander;
                objstudent.Contact = student.Contact;
                objstudent.Email = student.Email;
                objstudent.Password = student.Password;
                objstudent.Address = student.Address;
                objstudent.Images = imgname;
                objstudent.CoursesId = student.CoursesId;
                objstudent.Dob = student.Dob;
                objstudent.Pincode = student.Pincode;
                objstudent.RegistrationDate = DateTime.Now;
                objstudent.RollNumber = Convert.ToInt32(sixDigitNumber);
                db.Students.Add(objstudent);
                int i = db.SaveChanges();
                if (i > 0)
                {
                    message = "successfully";
                }
                else
                {
                    message = "error";
                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }


            return Json(message, JsonRequestBehavior.AllowGet);
        }




        public JsonResult emailotpsend(Student student)
        {
            string message = "";



            try
            {
                var data = db.Students.Where(x => x.Email == student.Email).FirstOrDefault();
                if (data.Email == student.Email)
                {

                    string email = data.Email.ToString();
                    Random r = new Random();
                    int randNum = r.Next(1000000);
                    string sixDigitNumber = randNum.ToString("D6");

                    message = "registrationsuccessfullyadd";

                    EmailOtp objotp = new EmailOtp();
                    objotp.StudentId = data.Id;
                    objotp.Otp = sixDigitNumber;
                    objotp.Stime = DateTime.Now;
                    db.EmailOtps.Add(objotp);
                    db.SaveChanges();

                    Guid activationCode = Guid.NewGuid();
                    using (MailMessage mm = new MailMessage("bablumaurya8052@gmail.com", data.Email.ToString()))
                    {
                        mm.Subject = "Forgate Account Password ";

                        string body = "";

                        body = "<div><h3>Welcome" + data.Name + "</h3><br><h4>Verification code " + sixDigitNumber + "</h4></div>";

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
                    }

                }
                else
                {
                    message = "invalid";
                }

            }
            catch (Exception ex)
            {


            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult virifyemailotp(Student student)
        {
            string message = "";
            var data = db.EmailOtps.Where(x => x.Otp == student.Email).FirstOrDefault();
            if (data.Otp == student.Email)
            {

                message = data.StudentId.ToString();
            }
            else
            {
                message = "invalidotp";
            }


            return Json(message, JsonRequestBehavior.AllowGet);



        }

        public ActionResult virifyotp(Student student)
        {
            string message = "";
            try
            {
                var data = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
                var dataemail = db.EmailOtps.Where(x => x.StudentId == student.Id).FirstOrDefault();
                if(data!=null)
                {
                    data.Password = student.Password;
                    db.Entry(data).State = EntityState.Modified;
                    int i=db.SaveChanges();

                    db.Entry(dataemail).State = EntityState.Deleted;
                    db.SaveChanges();
                    if (i>0)
                    {
                        message = "updaterecords";
                    }
                    else
                    {
                        message = "notupdate";
                    }

                }

            }
           catch(Exception ex)
            {

            }
           
            return Json(message, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetCoursnameupdate()
        {
            var data = db.Courses.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Update()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Contact", "Home");
            }
            return View();
        }


        public ActionResult Search(int id)
        {
            var data = db.Students.Where(x => x.Id == id).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult updaterecords(Student student)
        {
            string message = "";

            Student objstudent = db.Students.Where(x => x.Id == student.Id).FirstOrDefault(); ;

            try
            {


                var profile = Request.Files;

                string imgname = string.Empty;
                string ImageName = string.Empty;

                //Following code will check that image is there 
                //If it will Upload or else it will use Default Image

                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var logo = System.Web.HttpContext.Current.Request.Files["file"];
                    if (logo.ContentLength > 0)
                    {
                        var profileName = Path.GetFileName(logo.FileName);
                        var ext = Path.GetExtension(logo.FileName);

                        ImageName = profileName;
                        var comPath = Server.MapPath("~/images1/") + ImageName;

                        logo.SaveAs(comPath);
                        imgname = student.Images = comPath;
                    }

                }
                else
                    student.Images = Server.MapPath("~/images1/") + "profile.jpg";

                message = 1.ToString();


                objstudent.Name = student.Name;
                objstudent.Gander = student.Gander;
                objstudent.Contact = student.Contact;
                objstudent.Email = student.Email;
                objstudent.Address = student.Address;

                objstudent.Dob = student.Dob;
                objstudent.Pincode = student.Pincode;
                db.Entry(objstudent).State = EntityState.Modified;
                int i = db.SaveChanges();
                if (i > 0)
                {
                    message = "successfullyupdate";
                }
                else
                {
                    message = "errorupdate";
                }
            }
            catch (Exception ex)
            {

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


       
        //public ActionResult changepassword(Student student)
        //{
        //    string message = "";

        //    try
        //    {
        //        var data = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
        //        data.Password = student.Password;
        //        db.Entry(data).State = EntityState.Modified;
        //        int i=db.SaveChanges();
        //        if(i>0)
        //        {
        //            message = "updaterecords";
        //        }
        //        else
        //        {
        //            message = "error";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        message = "exception";
        //    }



        //    return Json(message, JsonRequestBehavior.AllowGet);
        //}
    }
}