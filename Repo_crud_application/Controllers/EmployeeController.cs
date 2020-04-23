using Repo_crud_application.Models;
using Repo_crud_application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repo_crud_application.Controllers
{
    public class EmployeeController : Controller
    {
        private Iemployee iemp;
        public EmployeeController()
        {
            this.iemp = new RepositoryEmpoyee(new EmployeeModel());
        }
        // GET: Employee
        public ActionResult Index()
        {
            var emplist = iemp.getEmployee().ToList();
            return View(emplist);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var getemp = iemp.GetEmployee(id);
            var empdisplay = new Employee();
            empdisplay.Id = getemp.Id;
            empdisplay.Name = getemp.Name;
            empdisplay.Email = getemp.Email;
            empdisplay.Salary = getemp.Salary;
            return View(empdisplay);
        }


        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,Employee empinser)
        {
            try
            {
                // TODO: Add insert logic here
                var addemp = new Employee();
                addemp.Name = empinser.Name;
                addemp.Email = empinser.Email;
                addemp.Salary = empinser.Salary;
                iemp.InsertEmpRecords(addemp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var getemp = iemp.GetEmployee(id);
            var empdisplay = new Employee();
            empdisplay.Id = getemp.Id;
            empdisplay.Name = getemp.Name;
            empdisplay.Email = getemp.Email;
            empdisplay.Salary = getemp.Salary;
            return View(empdisplay);

         
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee empupdate, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                iemp.UpdateRecords(empupdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var empdel = iemp.GetEmployee(id);
            return View(empdel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                iemp.DeleteEmpRecords(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
