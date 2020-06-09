using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoesitoryPattern.Models;
using RepoesitoryPattern.Repository;

namespace RepoesitoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private Iemployee emp;

        public EmployeeController()
        {
            this.emp = new RepositoryEmployee(new EmployeeModel());
        }
        // GET: Employee
        public ActionResult Index()
        {
            var emplist = emp.GetEmployees().ToList();

            return View(emplist);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var getemp = emp.GetEmpById(id);
            var objemp = new Employee();
            objemp.Id = getemp.Id;
            objemp.Name = getemp.Name;
            objemp.Salary = getemp.Salary;
            objemp.Email = getemp.Email;
            return View(objemp);
        }

        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Employee employee)
        {
            try
            {
                var addemp = new Employee();
                // TODO: Add insert logic here
                addemp.Name = employee.Name;
                addemp.Email = employee.Email;
                addemp.Salary = employee.Salary;
                emp.InsertEmployee(addemp);

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

            var getemp = emp.GetEmpById(id);
            var objemp = new Employee();
            objemp.Id = getemp.Id;
            objemp.Name = getemp.Name;
            objemp.Salary = getemp.Salary;
            objemp.Email = getemp.Email;
            return View(objemp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                emp.UpdateEmpRecord(employee);


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
            var demp = emp.GetEmpById(id);
            return View(demp);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                emp.DeleteEmpRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
