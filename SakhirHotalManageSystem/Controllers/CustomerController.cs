using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class CustomerController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();
        // GET: Customer
        public ActionResult RegistrationPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CustomerRegistration(Customer customer)
        {
            string message = "";

            try
            {
                if (customer != null)
                {
                    var data = db.Customers.Where(x => x.CustomerEmail == customer.CustomerEmail || x.CustomerContact == customer.CustomerContact).FirstOrDefault();

                    if (data != null)
                    {
                        if (data.CustomerEmail == customer.CustomerEmail)
                        {
                            message = "alreadyaddemail";
                        }
                        else if (data.CustomerContact ==customer.CustomerContact)
                        {
                            message = "alreadyaddcontact";
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (customer.CustomerId == 0)
                        {
                            Customer objcustomer = new Customer();
                            byte[] EncrtDateByte = new byte[customer.CustomerPassword.Length];
                            EncrtDateByte = System.Text.Encoding.UTF8.GetBytes(customer.CustomerPassword);
                            string EncrypetedData = Convert.ToBase64String(EncrtDateByte);

                            objcustomer.CustomerName = customer.CustomerName;
                            objcustomer.CustomerGander = customer.CustomerGander;
                            objcustomer.CustomerEmail = customer.CustomerEmail;
                            objcustomer.CustomerContact = customer.CustomerContact;
                            objcustomer.CustomerPassword = EncrypetedData;
                            objcustomer.CreatedByDate = DateTime.Now;
                            objcustomer.IsValid = true;
                            db.Customers.Add(objcustomer);
                            int i = db.SaveChanges();
                            if (i > 0)
                            {
                                message = "submit";

                            }
                            else
                            {
                                message = "notsubmit";
                            }


                        }
                        else
                        {

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                message = "exception";

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}