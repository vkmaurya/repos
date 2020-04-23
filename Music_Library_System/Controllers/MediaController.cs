using Music_Library_System.DALRepository;
using Music_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_System.Controllers
{
    public class MediaController : Controller
    {
        MusicModel1Db database = new MusicModel1Db();


        private IAllRepository<Mediadata> db;

        public MediaController()
        {
            db = new AllRepository<Mediadata>();
        }
        // GET: Media
        public ActionResult Index()
        {
            return View(db.GetModel());
        }

        // GET: Media/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        [HttpPost]
        public ActionResult Create(Mediadata objectmedia)
        {
            try
            {
                // TODO: Add insert logic here


                db.InsertModel(objectmedia);
                db.Save();


                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Edit/5
        public ActionResult Editsearchmediabyid(int id)
        {
            Mediadata user = db.GetModelById(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // POST: Media/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Mediadata mediaobj)
        {
            try
            {
                if (id != null)
                {
                    db.UpdateModel(mediaobj);
                    db.Save();

                }
                // return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Media/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Mediadata user)
        {
            try
            {
                Mediadata media = db.GetModelById(id);
                db.DeleteModel(id);
                db.Save();
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult dropdownlist()
        {
            var data = db.GetModel();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}
