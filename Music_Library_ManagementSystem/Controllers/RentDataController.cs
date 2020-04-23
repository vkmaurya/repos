using Music_Library_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace Music_Library_ManagementSystem.Controllers
{
    public class RentDataController : Controller
    {
        // GET: RentData
        
     

    Music_ModelDb db = new Music_ModelDb();

        public ActionResult Index()
        {
            var mediadata = db.RentDatas.ToList<RentData>();

            return View(mediadata);
        }


        [HttpPost]
        public ActionResult getmediaId(int[] Id)
        {

            List<Mediadata> obj = new List<Mediadata>();

            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = db.Mediadatas.Where(x => x.Id == i).SingleOrDefault();
                    if (data != null)
                    {
                        obj.Add(new Mediadata()
                        {
                            Id = data.Id,
                            AuthorName = data.AuthorName,


                            CategoryName = data.CategoryName,
                            CategoryNumber = data.CategoryNumber,
                            Title = data.Title,
                            Description = data.Description,
                            Price = data.Price
                        });


                    }

                }
            }
            else
            {

                TempData["Message"] = "please select checkbox.";
            }


            return Json(obj, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult hirerentmedia(int[] id, RentDatavm rentmediaVm)
        {
            try
            {
                var a = Convert.ToInt32(Session["customerid"]);
                //  var data = db.RentDatas.Where(x=>x.CustomerId==a).FirstOrDefault();
                CustomerRentData customerRentData = new CustomerRentData();
                int result = 0;
                RentData objrent = new RentData();

                for (var i = 0; i <= id.Length - 1; i++)
                {
                    customerRentData.CustomerId = Convert.ToInt32(Session["customerid"]);
                    customerRentData.MediaId = id[i];
                    result = id.Length;
                    db.CustomerRentDatas.Add(customerRentData);
                    db.SaveChanges();
                }



                


                    var updatemedia = (from u in db.RentDatas
                                       where u.CustomerId == a
                                       select u).FirstOrDefault();

                    if (updatemedia != null)
                    {

                        updatemedia.Startdate = DateTime.Now;
                        updatemedia.Enddate = rentmediaVm.Enddate;
                        updatemedia.Address = rentmediaVm.Address;
                        updatemedia.Contact = rentmediaVm.Contact;
                        updatemedia.MediaId = result.ToString();
                        updatemedia.TotalAmount = rentmediaVm.TotalAmount;
                        updatemedia.Startdate = DateTime.Now;
                        db.Entry(updatemedia).State = EntityState.Modified;
                        db.SaveChanges();

                }
                    else
                    {


                        objrent.CustomerId = Convert.ToInt32(Session["customerid"]);
                        objrent.CustomerName = Session["custmoername"].ToString();
                        objrent.Enddate = rentmediaVm.Enddate;
                        objrent.Address = rentmediaVm.Address;
                        objrent.Contact = rentmediaVm.Contact;
                        objrent.MediaId = result.ToString();
                        objrent.TotalAmount = rentmediaVm.TotalAmount;
                        objrent.Startdate = DateTime.Now;
                        db.RentDatas.Add(objrent);
                        db.SaveChanges();
                    }
                    //return RedirectToAction("HireMediaRent", "RentData");
                
            }
            catch (Exception ex)
            {

            }
            return Json(rentmediaVm, JsonRequestBehavior.AllowGet);

        }


        public ActionResult rentView()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetDatarent()
        {
            //server side parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string SearchColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string SortDirection = Request["order[0][dir]"];

            List<RentData> objcustomerrent = new List<RentData>();


            objcustomerrent = db.RentDatas.ToList<RentData>();
            int totalrows = objcustomerrent.Count;
            if (!string.IsNullOrEmpty(searchvalue))//filter
            {
                objcustomerrent = objcustomerrent.Where(x => x.Id.ToString().Contains(searchvalue.ToLower()) || x.CustomerId.ToString().Contains(searchvalue.ToLower()) || x.CustomerName.ToLower().Contains(searchvalue.ToLower()) || x.Contact.ToLower().Contains(searchvalue.ToLower()) || x.MediaId.ToLower().Contains(searchvalue.ToLower()) || x.TotalAmount.ToLower().Contains(searchvalue.ToLower()) || x.Address.ToLower().Contains(searchvalue.ToLower()) || x.Contact.ToLower().Contains(searchvalue.ToLower()) || x.Status.ToString().Contains(searchvalue.ToLower())).ToList<RentData>();
            }
            int totalrawsafterfiltering = objcustomerrent.Count;
            //sorting
            objcustomerrent = objcustomerrent.OrderBy(SearchColumnName + " " + SortDirection).ToList<RentData>();

            //paging

            objcustomerrent = objcustomerrent.Skip(start).Take(length).ToList<RentData>();

            return Json(new { data = objcustomerrent, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrawsafterfiltering }, JsonRequestBehavior.AllowGet);



        }




        public ActionResult Deleterent(int id)
        {
            try
            {
                var mediaid = db.RentDatas.Where(x => x.CustomerId == id).FirstOrDefault();
                var customerrentdata = db.CustomerRentDatas.Where(x => x.CustomerId == id).FirstOrDefault();
                if (mediaid != null)
                {
                    var recorddelete = EntityState.Deleted;

                    db.Entry(mediaid).State = recorddelete;
                    db.SaveChanges();
                    db.Entry(customerrentdata).State = recorddelete;

                    db.SaveChanges();

                }

            }

            catch (Exception ex)
            {
                return Content("some problem");
            }
            return RedirectToAction("Index");

        }



        //-----------------------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult CustomerRentDetails(int id)
        {

            List<Customer> customer = db.Customers.ToList();
            List<Mediadata> mediadata = db.Mediadatas.ToList();
            List<CustomerRentData> customerRentData = db.CustomerRentDatas.ToList();
            List<RentData> rentData = db.RentDatas.ToList();


            //var MediaRecordsVm = (from temp in
            //                   (from crd in customerRentData
            //                    join cus in customer on crd.CustomerId equals cus.Id
            //                    join md in mediadata on crd.MediaId equals md.Id

            //                    select crd)
            //                      join rd in rentData on temp.CustomerId equals rd.CustomerId
            //                      select temp).ToList();




            return View();
        }





        public ActionResult customerRentDetails()
        {

            return View();
        }

        public ActionResult SearchCustomerDetails(RentData rent)
        {


            //try
            //{

            var data = (from Customer in db.Customers
                        join CustomerRentData in db.CustomerRentDatas on Customer.Id equals CustomerRentData.CustomerId

                        join Mediadata in db.Mediadatas on CustomerRentData.MediaId equals Mediadata.Id

                        where Customer.Id == rent.CustomerId


                        select new { CustomerId = Customer.Id, customername = Customer.Name, MediaId = Mediadata.Id, authorName = Mediadata.AuthorName, categoryName = Mediadata.CategoryName, categoryNumber = Mediadata.CategoryNumber, description = Mediadata.Description, price = Mediadata.Price, title = Mediadata.Title }).ToList();


            //}
            //catch(Exception ex)
            //{

            //}
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public ActionResult MediaOrderCancle(CustomerRentData customerRentData)

        {
            try
            {
                var ordermediacancli = db.CustomerRentDatas.Where(x => x.MediaId == customerRentData.MediaId).FirstOrDefault();

                if (ordermediacancli != null)
                {

                    db.Entry(ordermediacancli).State = EntityState.Deleted;

                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {

            }

            return View();
        }
    }



}









