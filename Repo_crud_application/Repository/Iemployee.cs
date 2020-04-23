using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo_crud_application.Models;
namespace Repo_crud_application.Repository
{
    interface Iemployee
    {
        void InsertEmpRecords(Employee emp);
        IEnumerable<Employee> getEmployee();

        void UpdateRecords(Employee emp);
        void DeleteEmpRecords(int empid);
        Employee GetEmployee(int empid);
        
    }
}
