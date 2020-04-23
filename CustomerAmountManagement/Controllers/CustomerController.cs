using CustomerAmountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace CustomerAmountManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        DBModel db = new DBModel();
            public ActionResult GetCustomerdate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetCustomer()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<Customer> user = new List<Customer>();

            using (DBModel db = new DBModel())
            {
                user = db.Customers.Where(x=>x.IsValid==true).ToList<Customer>();
                int totalrows = user.Count;
                if (!string.IsNullOrEmpty(searchvalue))//filter
                {
                    user = user.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.Name.ToLower().Contains(searchvalue.ToLower()) || x.Contact.ToLower().Contains(searchvalue.ToLower()) || x.Email.ToLower().Contains(searchvalue.ToLower()) || x.Address.ToLower().Contains(searchvalue.ToLower()) || x.Dob.ToString().Contains(searchvalue.ToLower())).ToList<Customer>();
                }
                int totalrawsafterfiltering = user.Count;
                //sorting
                user = user.OrderBy(SearchColumnName + " " + SortDirection).ToList<Customer>();

                //paging

                user = user.Skip(start).Take(length).ToList<Customer>();

                return Json(new { data = user, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            using (DBModel db = new DBModel())
            {
                Customer updateduser = (from u in db.Customers
                                          where u.Id == customer.Id
                                        select u).FirstOrDefault();
                updateduser.IsValid = false;
              

                db.Entry(updateduser).State = EntityState.Modified;
                db.SaveChanges();
            }

            return View();
        }
    }

    }
}