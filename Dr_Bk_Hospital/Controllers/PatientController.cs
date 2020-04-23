using Dr_Bk_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
namespace Dr_Bk_Hospital.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        DbModel db = new DbModel();

        public ActionResult GetPatientData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPatientRecords()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<PatientData> mediaobject = new List<PatientData>();


            mediaobject = db.PatientDatas.ToList<PatientData>();
            int totalrows = mediaobject.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                mediaobject = mediaobject.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.Name.ToString().Contains(searchvalue.ToLower()) || x.Dob.ToLower().Contains(searchvalue.ToLower()) || x.Contact.ToLower().Contains(searchvalue.ToLower()) || x.Email.ToString().Contains(searchvalue.ToLower()) || x.Address.ToString().Contains(searchvalue.ToLower()) || x.Ssno.ToString().Contains(searchvalue.ToLower()) || x.Roll.ToString().Contains(searchvalue.ToLower())).ToList<PatientData>();
            }
            int totalrawsafterfiltering = mediaobject.Count;
            //sorting
            mediaobject = mediaobject.OrderBy(SearchColumnName + " " + SortDirection).ToList<PatientData>();

            //paging

            mediaobject = mediaobject.Skip(start).Take(length).ToList<PatientData>();

            return Json(new { data = mediaobject, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult createpage()
        {
            return View();
        }



        public JsonResult Registration(PatientData objpatientData)
        {
            string message = "";

            try
            {

                db.PatientDatas.Add(new PatientData
                {
                    Name = objpatientData.Name,
                    Dob = objpatientData.Dob,
                    Contact = objpatientData.Contact,
                    Email = objpatientData.Email,
                    Address = objpatientData.Address,
                    Password = objpatientData.Password,
                    CreatedByDate = DateTime.Now.ToString()



                });

                var result = db.SaveChanges();

                if(result>0)
                {
                    message = "registrationsuccessfully";
                }
                else
                {
                    message = "someproblem";
                }
            }


            catch (Exception ex)
            {

            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }


        public JsonResult deleterecords(PatientData patientData)
        {
            string message = "";
            var data = db.PatientDatas.Where(x => x.Id == patientData.Id).FirstOrDefault();
            if (data != null)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                int i = db.SaveChanges();
                if (i > 0)
                {
                    message = "RecordsDelete";
                }
                else
                {
                    message = "Recordsnotdelete";
                }
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}
