using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        SakhirDbModel db = new SakhirDbModel();
        
        public ActionResult RolesPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewRoles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var objAccommodation = db.Roles.Where(x => x.IsValid == true).ToList();
            var data = new { data = objAccommodation };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //----------------Roles Add and update--------------------------------

        public ActionResult Rolesaddandupdate(Role role)
        {
            string message = "";
            try
            {
                if (role != null)
                {
                    if (role.RolesId == 0)
                    {
                        Role objrol = new Role();
                        objrol.RolesName = role.RolesName;
                        objrol.CreatedByDate = DateTime.Now;
                        objrol.CreatedByID = 1;
                        objrol.IsValid = true;
                        db.Roles.Add(objrol);
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
                        var data = db.Roles.Where(x => x.RolesId == role.RolesId).FirstOrDefault();
                        if (data != null)
                        {
                            data.RolesName = role.RolesName;
                            data.ModifyByDate = DateTime.Now;
                            data.ModifyByID = 1;
                            db.Entry(data).State = EntityState.Modified;
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
        public ActionResult SearchRolesid(Role role)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Roles.Where(x => x.RolesId == role.RolesId).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DeletedRoles(Role role)
        {
            string message = "";
            try
            {
                var data = db.Roles.Where(x => x.RolesId == role.RolesId).FirstOrDefault();
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


        //-------------------------dropdownlist--------------------------------------------

        [HttpGet]
        public ActionResult ViewRolesDropdownlist()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var objAccommodation = db.Roles.Where(x => x.IsValid == true).ToList();

            return Json(objAccommodation, JsonRequestBehavior.AllowGet);
        }
    }
}