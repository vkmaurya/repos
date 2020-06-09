using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoesitoryPattern.Models;

namespace RepoesitoryPattern.Repository
{
    public class RepositoryEmployee : Iemployee
    {

        private EmployeeModel employeeModel;

        public RepositoryEmployee(EmployeeModel employeeModel)
        {
            this.employeeModel = employeeModel;
        }

        public void DeleteEmpRecord(int employeeId)
        {
            Employee demp = employeeModel.Employees.Find(employeeId);
            employeeModel.Employees.Remove(demp);
            employeeModel.SaveChanges();


        }

        public Employee GetEmpById(int empId)
        {
            return employeeModel.Employees.Find(empId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeModel.Employees.ToList();
        }

        public void InsertEmployee(Employee employee)
        {
            employeeModel.Employees.Add(employee);
            employeeModel.SaveChanges();
        }

        public void UpdateEmpRecord(Employee employee)
        {
            employeeModel.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            employeeModel.SaveChanges();
        }
    }
}