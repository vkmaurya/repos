using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repo_crud_application.Models;

namespace Repo_crud_application.Repository
{

    public class RepositoryEmpoyee : Iemployee
    {
        
        private EmployeeModel employeeModel;

        public RepositoryEmpoyee(EmployeeModel employeeModel)
        {
            this.employeeModel = employeeModel;
        }

        public void DeleteEmpRecords(int empid)
        {
            Employee delemp = employeeModel.Employees.Find(empid);
            employeeModel.Employees.Remove(delemp);
            employeeModel.SaveChanges();
        }

        public IEnumerable<Employee> getEmployee()
        {
            return employeeModel.Employees.ToList();
        }

        public Employee GetEmployee(int empid)
        {

            return employeeModel.Employees.Find(empid);

        }

        public void InsertEmpRecords(Employee emp)
        {
            employeeModel.Employees.Add(emp);
            employeeModel.SaveChanges();
        }

        public void UpdateRecords(Employee emp)
        {
            employeeModel.Entry(emp).State=System.Data.Entity.EntityState.Modified;
            employeeModel.SaveChanges();
        }
    }
}