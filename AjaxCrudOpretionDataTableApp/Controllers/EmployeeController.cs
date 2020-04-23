using AjaxCrudOpretionDataTableApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxCrudOpretionDataTableApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        DbModel db = new DbModel();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            List<Employee> emp =db.Employees.ToList<Employee>();

            return Json(new {data=emp},JsonRequestBehavior.AllowGet);
        }
    }
}