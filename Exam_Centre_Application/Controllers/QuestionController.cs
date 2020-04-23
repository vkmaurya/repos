using Exam_Centre_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace Exam_Centre_Application.Controllers
{
    public class QuestionController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: Question
        public ActionResult QuestionPage()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View();
        }


        [HttpPost]
        public ActionResult QuestionCreate(Question question)
        {
            string message = "";

            try
            {
                Question objquestion = new Question();

                objquestion.Question1 = question.Question1;
                objquestion.Opa = question.Opa;
                objquestion.Opb = question.Opb;
                objquestion.Opc = question.Opc;
                objquestion.Opd = question.Opd;
                objquestion.Ope = question.Ope;
                db.Questions.Add(objquestion);
                int i = db.SaveChanges();

                if (i > 0)
                {
                    message = "add";
                }
                else
                {
                    message = "error";
                }


            }
            catch (Exception ex)
            {
                message = "exception";
            }



            return
                Json(message, JsonRequestBehavior.AllowGet);
        }



        public ActionResult GetRecords()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var customerData = (from questionlist in db.Questions
                                    select questionlist);

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Question1 == searchValue);
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult Search(int id)
        {
            var data = db.Questions.Where(x => x.Id == id).FirstOrDefault();

            return Json(data,JsonRequestBehavior.AllowGet);
        }


        public ActionResult update(Question question)
        {
            string message = "";

            try
            {
                var data = db.Questions.Where(x => x.Id == question.Id).FirstOrDefault();

                data.Question1 = question.Question1;
                data.Opa = question.Opa;
                data.Opb = question.Opb;
                data.Opc = question.Opc;
                data.Opd = question.Opd;
                data.Ope = question.Ope;
                db.Entry(data).State = EntityState.Modified;
                int i=db.SaveChanges();
                if(i>0)
                {
                    message = "update";
                }
                else
                {
                    message = "error";
                }
            }
            catch(Exception ex)
            {
                message = "excepetion";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult delete(int id)
        {
            string message = "";

            var data = db.Questions.Where(x => x.Id == id).FirstOrDefault();

            db.Entry(data).State = EntityState.Deleted;
            int i=db.SaveChanges();
            if(i>0)
            {
                message = "delete";
            }
            else
            {
                message = "error";
            }

            return Json(message, JsonRequestBehavior.AllowGet);

        }
    }

}