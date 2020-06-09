using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class LoginController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult CustomerLogin(Customer customer)
        {
            string message = "";

            try
            {
                if (customer != null)
                {

                    byte[] EncrtDateByte = new byte[customer.CustomerPassword.Length];
                    EncrtDateByte = System.Text.Encoding.UTF8.GetBytes(customer.CustomerPassword);
                    string EncrypetedData = Convert.ToBase64String(EncrtDateByte);

                    var CustomerCredentioal = db.Customers.Where(x => x.CustomerEmail == customer.CustomerEmail && x.CustomerPassword == EncrypetedData).FirstOrDefault();
                    if (CustomerCredentioal != null)
                    {


                        if (CustomerCredentioal.CustomerEmail == customer.CustomerEmail && CustomerCredentioal.CustomerPassword == EncrypetedData)
                        {
                            Session["customeruserName"] = CustomerCredentioal.CustomerName.ToString();
                            message = "ligin";
                        }
                    }
                    else
                    {
                        message = "invalid";
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