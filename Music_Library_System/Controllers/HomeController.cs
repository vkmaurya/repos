using Music_Library_System.DALRepository;
using Music_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_System.Controllers
{
    public class HomeController : Controller
    {
        MusicModel1Db bdmodel = new MusicModel1Db();

        private IAllRepository<Mediadata> db;

        public HomeController()
        {
            db = new AllRepository<Mediadata>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Media()
        {
            return View(db.GetModel());
        }




        [HttpPost]
        public ActionResult getmediaId(int[] Id)
        {

            List<Mediadata> obj = new List<Mediadata>();

            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = bdmodel.Mediadatas.Where(x => x.Id == i).SingleOrDefault();
                    if (data != null)
                    {
                        obj.Add(new Mediadata()
                        {
                            Id = data.Id,
                            AuthorName = data.AuthorName,


                            CategoryName = data.CategoryName,
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



        //public ActionResult rentmedia(List<mediaCustomVm> objrent)
        //{
        //    try
        //    {
        //        List<RentData> objvm = new List<RentData>();

        //        foreach (var i in objrent)
        //        {
        //            bdmodel.RentDatas.Add(i);
        //            bdmodel.SaveChanges();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View(objrent);

        //}



        public ActionResult hirerentmedia(int[] id,mediaCustomVm objrent)
        {
            try
            {
                
                UserRentData userRentData = new UserRentData();
                RentData objrent1 = new RentData();

                for(var i=0;i<=id.Length;i++)
                {
                    userRentData.UserId = objrent.UserId;
                    userRentData.MediaId= id[i];
                    bdmodel.UserRentDatas.Add(userRentData);
                    bdmodel.SaveChanges();
                }


                objrent1.UserId = objrent.UserId;
                objrent1.UserName = objrent.UserName;
                objrent1.MediaId = objrent.MediaId;
                objrent1.TotalAmount = objrent.TotalAmount;

                objrent1.Address = objrent.Address;
                objrent1.Contact = objrent.Contact;
                objrent1.Startdate = DateTime.Now;
                bdmodel.RentDatas.Add(objrent1);
                bdmodel.SaveChanges();




            }
            catch (Exception ex)
            {

            }
            return View(objrent);

        }


        public ActionResult UserRegistrationform()
        {
            return View();
        }


    }
}