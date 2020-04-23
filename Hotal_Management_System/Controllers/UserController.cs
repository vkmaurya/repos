using Hotal_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace Hotal_Management_System.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        ModelDataBase db = new ModelDataBase();
        public ActionResult UserPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserView()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<User> user = new List<User>();


            user = db.Users.ToList<User>();
            int totalrows = user.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                user = user.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.Name.ToLower().Contains(searchvalue.ToLower()) || x.Countery.ToString().Contains(searchvalue.ToLower()) || x.City.ToString().Contains(searchvalue.ToLower()) || x.Address.ToString().Contains(searchvalue.ToLower()) || x.Email.ToString().Contains(searchvalue.ToLower())).ToList<User>();
            }
            int totalrawsafterfiltering = user.Count;
            //sorting
            user = user.OrderBy(SearchColumnName + " " + SortDirection).ToList<User>();

            //paging

            user = user.Skip(start).Take(length).ToList<User>();

            return Json(new { data = user, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAndUpdate(User user)
        {
            string message = "";

            try
            {
                if (user.Id != 0)
                {
                    var userdata = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                    userdata.Name = user.Name;
                    userdata.Countery = user.Countery;
                    userdata.City = user.City;
                    userdata.Address = user.Address;
                    userdata.Email = user.Email;
                    userdata.Dob = user.Dob;
                    db.Entry(userdata).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "update";
                    }
                    else
                    {
                        message = "notupdate";
                    }

                }
                else
                {
                    User objuser = new User();

                    objuser.Name = user.Name;
                    objuser.Countery = user.Countery;
                    objuser.City = user.City;
                    objuser.Address = user.Address;
                    objuser.Email = user.Email;
                    objuser.Password = user.Password;
                    objuser.Dob = user.Dob;
                    objuser.Role = false;
                    db.Users.Add(objuser);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "addsuccessfully";
                    }
                    else
                    {
                        message = "notadd";
                    }

                }
            }
            catch (Exception Ex)
            {
                message = "exception";
            }


            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(int id)
        {
            var data = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserDelete(int id)
        {
            string message = "";
            try
            {
                var data = db.Users.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(data).State = EntityState.Deleted;
                int i = db.SaveChanges();
                if(i>0)
                {
                    message = "delete";

                }
                else
                {
                    message = "notdelete";
                }
            }
            catch(Exception ex)
            {
                message = "excepetion";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}