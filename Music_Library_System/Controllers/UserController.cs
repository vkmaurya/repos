using Music_Library_System.DALRepository;
using Music_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Library_System.Controllers
{
    public class UserController : Controller
    {
        // MusicModel1Db db = new MusicModel1Db();
        // GET: User
        private IAllRepository<UserData> db;

        public UserController()
        {
            db = new AllRepository<UserData>();
        }

        public ActionResult Index()
        {

            return View(db.GetModel());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserData collection)
        {
            try
            {
                //    if (ModelState.IsValid)
                //    {


                db.InsertModel(collection);
                db.Save();
                //}

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edituserdata(int id)
        {
            UserData user = db.GetModelById(id);
            return Json(user, JsonRequestBehavior.AllowGet);

        }




        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, UserData objectuser)
        {
            try
            {
               // UserData userdata = db.GetModelById(objectuser.Id);
                // TODO: Add update logic here
                if (id != null)
                {
                   //if(userdata.Roll !="Admin")
                   //{
                        db.UpdateModel(objectuser);
                        db.Save();
                   // }
                   //else
                   // {
                   //     return Content("<script>'this is Admin please try agen'</script>");
                   // }

                }
                 //return RedirectToAction("Index");
                return View(objectuser);
            }
            catch
            {
                return View(objectuser);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {


            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserData user)
        {
            try
            {
                UserData userdata = db.GetModelById(id);
                if (userdata.Roll != "Admin")
                {
                    db.DeleteModel(id);
                    db.Save();

                }
                else
                {
                    return Content("<script>'this is admin please try agen'</script>");

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
