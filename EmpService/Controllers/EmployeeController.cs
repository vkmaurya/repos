using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpService.Models;

namespace EmpService.Controllers
{
    public class EmployeeController : ApiController
    {
        Modeldb db = new Modeldb();

        public  IEnumerable<WebApiSwlServer> Get()
        {

            return db.WebApiSwlServers.ToList();
        }

        public WebApiSwlServer Get(int id)
        {

            return db.WebApiSwlServers.Where(x=>x.id==id).FirstOrDefault();
        }
    }
}
