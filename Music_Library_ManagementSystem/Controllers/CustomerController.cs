using Music_Library_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Music_Library_ManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        Music_ModelDb db = new Music_ModelDb();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomerRecords()
        {
            //var data = db.Customers.ToList<Customer>();
            return View();
        }


        [HttpPost]
        public ActionResult GetData()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<Customer> customer = new List<Customer>();


            customer = db.Customers.ToList<Customer>();
            int totalrows = customer.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                customer = customer.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.Name.ToLower().Contains(searchvalue.ToLower()) || x.Dob.ToString().Contains(searchvalue.ToLower()) || x.Gender.ToLower().Contains(searchvalue.ToLower()) || x.Contact.ToLower().Contains(searchvalue.ToLower()) || x.Email.ToLower().Contains(searchvalue.ToLower()) || x.Address.ToLower().Contains(searchvalue.ToLower()) || x.Membership.ToLower().Contains(searchvalue.ToLower()) || x.Password.ToLower().Contains(searchvalue.ToLower()) || x.CreatedBy_Id.ToString().Contains(searchvalue.ToLower()) || x.CreatedBy_Date.ToString().Contains(searchvalue.ToLower()) || x.ModifyBy_Id.ToString().Contains(searchvalue.ToLower()) || x.ModifyBy_Date.ToString().Contains(searchvalue.ToLower()) || x.DeletedBy_Id.ToString().Contains(searchvalue.ToLower()) || x.DeletedBy_Id.ToString().Contains(searchvalue.ToLower()) || x.IsValid.ToString().Contains(searchvalue.ToLower())).ToList<Customer>();
            }
            int totalrawsafterfiltering = customer.Count;
            //sorting
            customer = customer.OrderBy(SearchColumnName + " " + SortDirection).ToList<Customer>();

            //paging

            customer = customer.Skip(start).Take(length).ToList<Customer>();

            return Json(new { data = customer, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);



        }


        //---------------------------------------------------------------------------------
        public ActionResult typeCustomer()
        {
            var typecusstmoer = db.Customers.ToList<Customer>();


            return Json(typecusstmoer, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public ActionResult AddCustomerRecords(Customer customer)
        {
            string message= ""; 

            if (ModelState.IsValid)
            {
                db.Customers.Add(new Customer
                {
                    Name = customer.Name,
                    Gender = customer.Gender,
                    Dob = customer.Dob,
                    Email = customer.Email,
                    Contact = customer.Contact,

                    Password = customer.Password,
                    Address = customer.Address,
                    Membership = customer.Membership,
                    CreatedBy_Date = DateTime.Now,
                    Roll = "User"
                });

                var result = db.SaveChanges();
              
                if (result > 0)
                {

                    message = "Registrationsuccessfully";

                }
                else
                {
                    message = "Registrationfieldpleasetryagen";
                }

            }
         
            return Json(message,JsonRequestBehavior.AllowGet);
        }

        //--------------------------------user data  search  -------------------------------------------

        [HttpPost]
        public ActionResult UserSearchdata(int Id)

        {

            var data = db.Customers.Where(x => x.Id == Id).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult customerupdaterecords(Customer customerupdate)
        {
            try
            {
                var updatecustomer = (from u in db.Customers
                                      where u.Id == customerupdate.Id
                                      select u).FirstOrDefault();
                updatecustomer.Name = customerupdate.Name;
                updatecustomer.Dob = customerupdate.Dob;
                updatecustomer.Gender = customerupdate.Gender;
                updatecustomer.Contact = customerupdate.Contact;
                updatecustomer.Email = customerupdate.Email;
                updatecustomer.Address = customerupdate.Address;
                updatecustomer.Membership = customerupdate.Membership;
                //updatecustomer.Password = customerupdate.Password;
                updatecustomer.ModifyBy_Id = Convert.ToInt32(Session["adminid"].ToString());
                updatecustomer.ModifyBy_Date = DateTime.Now;

                db.Entry(updatecustomer).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public ActionResult Deletemedicustomer(int id)
        {
            string message = "";

            try
            {
                var customerid = db.Customers.Where(x => x.Id == id).FirstOrDefault();
                var custimerrentdata = db.CustomerRentDatas.Where(x =>x.CustomerId==id).FirstOrDefault();
                var rentdata = db.RentDatas.Where(x => x.CustomerId == id).FirstOrDefault();
                if (customerid != null)
                {
                    if(customerid.Roll!="Admin")
                    {  var delete= EntityState.Deleted;

                        db.Entry(customerid).State = delete;
                        db.SaveChanges();
                        db.Entry(custimerrentdata).State = delete;
                        db.SaveChanges();
                        db.Entry(rentdata).State = delete;
                        db.SaveChanges();

                        message = "DeleteRecords";
                    }
                   else
                    {
                        message = "thisisAdmin";
                    }

                }
            }

            catch (Exception ex)
            {
                return Content("some problem");
            }
            return Json(message,JsonRequestBehavior.AllowGet);

        }



        //------------------------------------------------------------------



       
    }
}