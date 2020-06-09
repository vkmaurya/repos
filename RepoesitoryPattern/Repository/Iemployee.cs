using RepoesitoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoesitoryPattern.Repository
{
    interface Iemployee
    {
        void InsertEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        void UpdateEmpRecord(Employee employee);
        void DeleteEmpRecord(int employeeId);
        Employee GetEmpById(int empId);
    }
}
