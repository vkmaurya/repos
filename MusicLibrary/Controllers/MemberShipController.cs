using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class MemberShipController : Controller
    {
        MusicLibraryModelDB db = new MusicLibraryModelDB();

        // GET: MemberShip


        [Authorize]
        public ActionResult MemberShipPage()
        {
            if (Session["AdminEmail"] == null)
            {
                return RedirectToAction("UserLoginPage", "Login");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult ViewMemberShipList()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.MemberShips.Where(x => x.IsValid == true).ToList();

            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateMemberShip(MemberShip memberShip)
        {
            string message = "";

            try
            {
                if (memberShip != null)
                {
                    if (memberShip.MemberShipID == 0)
                    {
                        MemberShip objmembership = new MemberShip();

                        objmembership.MemberShipName = memberShip.MemberShipName;
                        objmembership.MemberShipDuration = memberShip.MemberShipDuration;
                        objmembership.MemberShipAmount = memberShip.MemberShipAmount;
                        objmembership.MemberShipDescription = memberShip.MemberShipDescription;

                        objmembership.IsValid = true;
                        objmembership.CreatedByDate = DateTime.Now;
                        objmembership.CreatedByID = Convert.ToInt32(Session["AdminId"]);
                        db.MemberShips.Add(objmembership);
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
                        var data = db.MemberShips.Where(x => x.MemberShipID == memberShip.MemberShipID).FirstOrDefault();
                        if (data != null)
                        {
                            data.MemberShipName = memberShip.MemberShipName;
                            data.MemberShipDuration = memberShip.MemberShipDuration;
                            data.MemberShipAmount = memberShip.MemberShipAmount;
                            data.MemberShipDescription = memberShip.MemberShipDescription;

                            data.ModifyByDate = DateTime.Now;
                            data.ModifyByID = Convert.ToInt32(Session["AdminId"]);
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


        public ActionResult SearchMemberShipRecords(MemberShip memberShip)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.MemberShips.Where(x => x.MemberShipID == memberShip.MemberShipID).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeletedMemberShip(MemberShip memberShip)
        {
            string message = "";
            try
            {
                if (memberShip != null)
                {
                    var data = db.MemberShips.Where(x => x.MemberShipID == memberShip.MemberShipID).FirstOrDefault();
                    if (data != null)
                    {
                        data.IsValid = false;
                        db.Entry(data).State = EntityState.Modified;
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "deleted";
                        }
                        else
                        {
                            message = "notdeleted";
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

        //------------------------------------------------------------------------

        [Authorize]
        public ActionResult MemberPage()
        {
            if (Session["UserEmail"] == null)
            {
                return RedirectToAction("UserLoginPage", "Login");
            }
            else
            {
                return View();
            }
        }


        public ActionResult ViewFrontPageMembership()
        {
            db.Configuration.ProxyCreationEnabled = false;

           var data= db.MemberShips.Where(x=>x.IsValid==true).ToList();

            return Json(data,JsonRequestBehavior.AllowGet);
        }


        //--------------------------------------------------------------------------------

        public ActionResult CreateUserMembership(UserMemberShip userMemberShip)
        {
            string message = "";

            try
            {
                if(userMemberShip!=null)
                {

                    UserMemberShip objmembership = new UserMemberShip();

                    objmembership.MemberShipID = userMemberShip.MemberShipID;
                    objmembership.UserID = Convert.ToInt32(Session["UserId"]);
                    objmembership.UserMemberGetDate = DateTime.Now;
                    objmembership.IsValid = true;
                    objmembership.CreatedByDate = DateTime.Now;
                    objmembership.CreatedByID =Convert.ToInt32(Session["UserId"]);
                    db.UserMemberShips.Add(objmembership);
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

    }
}