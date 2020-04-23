using Music_Library_System.DALRepository;
using Music_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_System.Controllers
{
    public class RentDataController : Controller
    {
        // GET: RentData

        private IAllRepository<RentData> db;

        public RentDataController()
        {
            db = new AllRepository<RentData>();
        }

        public ActionResult Index()
        {
            return View(db.GetModel());
        }




        // GET: RentData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentData/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RentData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RentData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RentData objRent)
        {
            try
            {
                
                db.DeleteModel(id);
                    db.Save();


                return View();
            }
            catch
            {
                return View();
            }
        }




    }
}
