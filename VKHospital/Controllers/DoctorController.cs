using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VKHospital.Models;
using VKHospital.VwModel;

namespace VKHospital.Controllers
{
    public class DoctorController : Controller
    {
        VkHospitalDatabaseModel db = new VkHospitalDatabaseModel();
        // GET: Doctor
        public ActionResult DoctorMasterPage()
        {
            if (Session["DoctorUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                return View();
            }
        }

        //-----------------------Doctor Type Action Start---------------------------------------------------------------------------
        public ActionResult DoctorTypePages()
        {
            if (Session["AdminUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateAndUpdate(DoctorType doctorType)
        {
            string message = "";
            try
            {
                if (doctorType != null)
                {
                    if (doctorType.DoctorTypeID == 0)
                    {
                        DoctorType objdoctorType = new DoctorType();
                        objdoctorType.DoctorTypeName = doctorType.DoctorTypeName;
                        objdoctorType.CreateByDate = DateTime.Now;
                        objdoctorType.IsValid = true;
                        objdoctorType.CreatedByID = 1;
                        db.DoctorTypes.Add(objdoctorType);
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "doctortypeadd";
                        }
                        else
                        {
                            message = "notsavedoctortype";
                        }


                    }
                    else
                    {
                        var data = db.DoctorTypes.Where(x => x.DoctorTypeID == doctorType.DoctorTypeID).FirstOrDefault();
                        data.DoctorTypeName = doctorType.DoctorTypeName;
                        data.ModifyBYDate = DateTime.Now;
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
            catch (Exception ex)
            {

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Search(DoctorType doctorType)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var doctoytypedata = db.DoctorTypes.Where(x => x.DoctorTypeID == doctorType.DoctorTypeID).FirstOrDefault();

            return Json(doctoytypedata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewDoctorType()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<DoctorType> objdoctorTypes = new List<DoctorType>();

            objdoctorTypes = db.DoctorTypes.Where(x => x.IsValid == true).ToList();
            var data = new { data = objdoctorTypes };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult deletedrecords(DoctorType doctorType)
        {
            string message = "";

            try
            {
                if (doctorType != null)
                {
                    var data = db.DoctorTypes.Where(x => x.DoctorTypeID == doctorType.DoctorTypeID).FirstOrDefault();
                    data.IsValid = false;
                    data.DeleteByDate = DateTime.Now;
                    data.DeletedByID = 1;
                    db.Entry(data).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "delete";
                    }
                    else
                    {
                        message = "notdelete";
                    }


                }
            }
            catch (Exception ex)
            {

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //------------------------Doctor Type Action End-----------------------------------------------------------------------------------------------------

        //-----------------------Doctor  Action Start---------------------------------------------------------------------------
        public ActionResult DoctorPage()
        {
            if (Session["AdminUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult DoctorCreateAndUpdate(DoctorData doctorData)
        {
            string message = "";
            try
            {
                if (doctorData != null)
                {
                    if (doctorData.DoctorId == 0)
                    {
                        DoctorData objdoctorData = new DoctorData();
                        objdoctorData.DoctorName = doctorData.DoctorName;
                        objdoctorData.DoctorTypeID = doctorData.DoctorTypeID;
                        objdoctorData.IsValid = true;
                        objdoctorData.CreateByDate = DateTime.Now;
                        objdoctorData.CreatedByID = 1;
                        db.DoctorDatas.Add(objdoctorData);
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "add";
                        }
                        else
                        {
                            message = "notsave";
                        }


                    }
                    else
                    {
                        var data = db.DoctorDatas.Where(x => x.DoctorId == doctorData.DoctorId).FirstOrDefault();

                        data.DoctorName = doctorData.DoctorName;
                        data.DoctorTypeID = doctorData.DoctorTypeID;
                        data.ModifyBYDate = DateTime.Now;
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
            catch (Exception ex)
            {

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Searchdoctor(DoctorData doctorData)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var doctordata = db.DoctorDatas.Where(x => x.DoctorId == doctorData.DoctorId).FirstOrDefault();

            return Json(doctordata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Viewdoctor()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //  List<VwMoceldata> objdoctor = new List<VwMoceldata>();
            //var   objdoctor = db.DoctorDatas.Where(x => x.IsValid == true).ToList();
            var objdoctor = (from dd in db.DoctorDatas.Where(x => x.IsValid == true)
                             join dy in db.DoctorTypes on dd.DoctorTypeID equals dy.DoctorTypeID
                             orderby dy.DoctorTypeID
                             select new
                             {
                                 dd.DoctorId,
                                 dd.DoctorName,
                                 dd.DoctorTypeID,
                                 dy.DoctorTypeName
                             }).ToList();

            var data = new { data = objdoctor };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult deletedrecordsdocor(DoctorData doctorData)
        {
            string message = "";

            try
            {
                if (doctorData != null)
                {
                    var data = db.DoctorDatas.Where(x => x.DoctorId == doctorData.DoctorId).FirstOrDefault();
                    data.IsValid = false;
                    data.DeleteByDate = DateTime.Now;
                    data.DeletedByID = 1;
                    db.Entry(data).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "delete";
                    }
                    else
                    {
                        message = "notdelete";
                    }


                }
            }
            catch (Exception ex)
            {

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Doctordatatypedropdownlist()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var doctortypename = db.DoctorTypes.Where(x => x.IsValid == true).ToList();

            return Json(doctortypename, JsonRequestBehavior.AllowGet);
        }

        //------------------------Doctor  Action End-----------------------------------------------------------------------------------------------------

        //------------------------Sick  Action Start-----------------------------------------------------------------------------------------------------

        public ActionResult SickPage()
        {
            if (Session["AdminUsername"] == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult ViewSick()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //  List<VwMoceldata> objdoctor = new List<VwMoceldata>();
            //var   objdoctor = db.DoctorDatas.Where(x => x.IsValid == true).ToList();
            var objdoctor = (from sk in db.SickDatas.Where(x => x.IsValid == true)
                             join dy in db.DoctorTypes on sk.DoctorTypeID equals dy.DoctorTypeID
                             //orderby dy.DoctorTypeID
                             select new
                             {
                                 sk.SickTypeID,
                                 sk.SickTypeName,
                                 sk.DoctorTypeID,
                                 dy.DoctorTypeName

                             }).ToList();

            var data = new { data = objdoctor };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SickCreateandUpdate(SickData sickData)
        {
            string message = "";
            try
            {
                if(sickData!=null)
                {
                    if(sickData.SickTypeID==0)
                    {
                        SickData objsickData = new SickData();
                        objsickData.SickTypeName = sickData.SickTypeName;
                        objsickData.DoctorTypeID = sickData.DoctorTypeID;
                        objsickData.IsValid = true;
                        objsickData.CreateByDate = DateTime.Now;
                        objsickData.CreatedByID = 1;
                        db.SickDatas.Add(objsickData);
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "save";
                        }
                        else
                        {
                            message = "notesave";
                        }
                    }
                    {
                        var objsickData = db.SickDatas.Where(x => x.SickTypeID == sickData.SickTypeID).FirstOrDefault();
                        objsickData.SickTypeName = sickData.SickTypeName;
                        objsickData.DoctorTypeID = sickData.DoctorTypeID;
                        objsickData.IsValid = true;
                        objsickData.ModifyBYDate = DateTime.Now;
                        objsickData.ModifyByID = 1;
                        db.Entry(objsickData).State = EntityState.Modified;
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "update";
                        }
                        else
                        {
                            message = "noteupdate";
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchSick(SickData sickData)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var doctordata = db.SickDatas.Where(x => x.SickTypeID == sickData.SickTypeID).FirstOrDefault();

            return Json(doctordata, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult deletedrecordssick(SickData sickData)
        {
            string message = "";

            try
            {
                if (sickData != null)
                {
                    var data = db.SickDatas.Where(x => x.SickTypeID == sickData.SickTypeID).FirstOrDefault();
                    data.IsValid = false;
                    data.DeleteByDate = DateTime.Now;
                    data.DeletedByID = 1;
                    db.Entry(data).State = EntityState.Modified;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "delete";
                    }
                    else
                    {
                        message = "notdelete";
                    }


                }
            }
            catch (Exception ex)
            {

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }



        //------------------------Sick  Action End-----------------------------------------------------------------------------------------------------


    }
}