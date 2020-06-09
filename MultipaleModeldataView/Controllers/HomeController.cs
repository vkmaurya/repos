using MultipaleModeldataView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipaleModeldataView.Controllers
{
    public class HomeController : Controller
    {
        Modeldb db = new Modeldb();
        public ActionResult Index()
        {
            var std = GetStudent();
            var cur = getCourse();

            VmModel vm = new VmModel();

            vm.students = std;
            vm.courses = cur;
            return View(vm);
        }



        public List<Student> GetStudent()
        {
            return db.Students.ToList();
        }

        public List<Course> getCourse()
        {
            return db.Courses.ToList();
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
    }
}