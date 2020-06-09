using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class UserController : Controller
    {

        SakhirDbModel db = new SakhirDbModel();


        // GET: User

        public ActionResult UserPage()
        {
            return View();
        }

        public ActionResult RoleUserPage()
        {
            return View();
        }



        [HttpGet]
        public ActionResult ViewUserListAll()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var userview = db.Users.Where(x => x.IsValid == true && x.Role == null).ToList();

            var data = new { data = userview };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //----------------Accommodation Add and update--------------------------------

        public ActionResult Useraddandupdate(User user)
        {
            string message = "";
            try
            {
                if (user != null)
                {
                    if (user.UserID == 0)
                    {
                        User objuser = new User();
                        objuser.UserName = user.UserName;
                        objuser.UserEmail = user.UserEmail;
                        objuser.UserContact = user.UserContact;
                        objuser.Gander = user.Gander;
                        objuser.DOB = user.DOB;
                        objuser.UserAdharNumber = user.UserAdharNumber;
                        objuser.UserAddress = user.UserAddress;
                        objuser.UserPassword = user.UserPassword;
                        objuser.CreatedByDate = DateTime.Now;
                        objuser.CreatedByID = 1;
                        objuser.IsValid = true;
                        db.Users.Add(objuser);
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "save";
                        }
                        else
                        {
                            message = "notsave";
                        }

                    }
                    else
                    {
                        var objuser = db.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
                        if (objuser != null)
                        {
                            objuser.UserName = user.UserName;
                            objuser.UserEmail = user.UserEmail;
                            objuser.UserContact = user.UserContact;
                            objuser.Gander = user.Gander;
                            objuser.DOB = user.DOB;
                            objuser.UserAdharNumber = user.UserAdharNumber;
                            objuser.UserAddress = user.UserAddress;
                            objuser.UserPassword = user.UserPassword;
                            objuser.ModifyByDate = DateTime.Now;
                            objuser.ModifyByID = 1;
                            db.Entry(objuser).State = EntityState.Modified;
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

                    }
                }

            }
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Searchuseridrecords(User user)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Deleteduser(User user)
        {
            string message = "";
            try
            {
                var data = db.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
                if (data != null)
                {
                    data.IsValid = false;
                    data.DeletedByDate = DateTime.Now;
                    data.DeletedByID = 1;
                    db.Entry(data).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "deleted";
                    }
                    else
                    {
                        message = "notdelete";
                    }

                }
            }
            catch (Exception ex)
            {
                message = "exception";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult ViewUserDetails(User user)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var userview = db.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();

            //var data = new { data = userview };
            return Json(userview, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RoleAssignUser(User user)
        {
            string message = "";

            try
            {
                var data = db.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
               if(data!=null)
                {
                    data.UserRolesID = user.UserRolesID;
                    db.Entry(data).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if(i>0)
                    {
                        message = "save";
                    }
                    else
                    {
                        message = "notsave";
                    }
                }
            }
            catch(Exception ex)
            {
                message = "exception";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

//-------------------Roles-----------------------------------------------------------
        [HttpGet]
        public ActionResult ViewUserListAllRoledefine()
        {
            db.Configuration.ProxyCreationEnabled = false;


            var userview = (from US in db.Users.Where(x => x.IsValid == true)
                            join RL in db.Roles on US.UserRolesID equals RL.RolesId
                            orderby US.UserRolesID
                            select new
                            {
                                US.UserID,
                                US.UserName,
                                US.UserEmail,
                                US.UserContact,
                                US.UserAddress,
                                US.UserPassword,
                                US.UserAdharNumber,
                                US.UserRolesID,
                                US.DOB,
                                US.Gander,
                                RL.RolesId,
                                RL.RolesName

                            }).ToList();

            var data = new { data = userview };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult ViewUserDetailsRole(User user)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var userview = (from US in db.Users.Where(x => x.IsValid == true && x.UserID==user.UserID)
                            join RL in db.Roles on US.UserRolesID equals RL.RolesId
                            orderby US.UserRolesID
                            select new
                            {
                                US.UserID,
                                US.UserName,
                                US.UserEmail,
                                US.UserContact,
                                US.UserAddress,
                                US.UserPassword,
                                US.UserAdharNumber,
                                US.UserRolesID,
                                US.CreatedByDate,
                                US.DOB,
                                US.Gander,
                                RL.RolesId,
                                RL.RolesName

                            }).FirstOrDefault() ;

            //var data = new { data = userview };
            return Json(userview, JsonRequestBehavior.AllowGet);
        }



    }
}