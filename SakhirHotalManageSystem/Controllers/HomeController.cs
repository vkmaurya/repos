using SakhirHotalManageSystem.Models;
using SakhirHotalManageSystem.VwModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class HomeController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();
        public ActionResult Index()
        {
            HomeVwModel homeVwModel = new HomeVwModel();
            db.Configuration.ProxyCreationEnabled = false;

            homeVwModel.AccommodationTypes = db.AccommodationTypes.Where(x=>x.IsValid==true).ToList();

           return View(homeVwModel);

        }

        public ActionResult About()
        {
          

            return View();
        }



        public ActionResult Contact()
        {
           

            return View();
        }




        public ActionResult roomssuites()
        {
            return View();
        }




        public ActionResult diningbar()
        {
            return View();
        }




        public ActionResult aminities()
        {
            return View();
        }



        public ActionResult blog()
        {
            return View();
        }


     


    }
}