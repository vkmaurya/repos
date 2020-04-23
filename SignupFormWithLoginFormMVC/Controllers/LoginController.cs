using SignupFormWithLoginFormMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignupFormWithLoginFormMVC;


namespace SignupFormWithLoginFormMVC.Controllers
{
   
    public class LoginController : Controller
    {
        SignupLoginformEntities db = new SignupLoginformEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Table table)
        {
            var data = db.Tables.Where(x => x.username == table.username && x.password == table.password).FirstOrDefault<Table>();

            if(User !=null)
            {
                Session["UserId"] = table.Id.ToString();
                Session["Username"] = table.username.ToString();
                TempData["loginsuccessmessage"] = "Login Successfully !!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["loginfaieldsmessage"] = "Login Faields !!";
                return View();
            }
       
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Table table)
        {
            if(ModelState.IsValid==true)
            {
                db.Tables.Add(table);
              int i= db.SaveChanges();
                if(i>0)
                {
                    ViewBag.InsertMessage = "Registration Successfully !!'";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "Registration Faields !!'";
                }
            }
            return View();
        }
    }
}









