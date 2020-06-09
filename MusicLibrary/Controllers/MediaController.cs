
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class MediaController : Controller
    {
        MusicLibraryModelDB db = new MusicLibraryModelDB();
        // GET: Media
        [Authorize]
        public ActionResult PageMediaType()
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
        public ActionResult ViewMediaTypeList()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.MediaTypes.Where(x => x.IsValid == true).ToList();

            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateMediaType(MediaType mediaType)
        {
            string message = "";

            try
            {
                if (mediaType != null)
                {
                    if (mediaType.MediaTypeID == 0)
                    {
                        MediaType objmediaType = new MediaType();
                        objmediaType.MediaTypeName = mediaType.MediaTypeName;
                        objmediaType.IsValid = true;
                        objmediaType.CreatedByDate = DateTime.Now;
                        objmediaType.CreatedByID = Convert.ToInt32(Session["AdminId"]);
                        db.MediaTypes.Add(objmediaType);
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
                        var data = db.MediaTypes.Where(x => x.MediaTypeID == mediaType.MediaTypeID).FirstOrDefault();
                        if (data != null)
                        {
                            data.MediaTypeName = mediaType.MediaTypeName;
                            data.ModifyByDate = DateTime.Now;
                            data.ModifyByID = Convert.ToInt32(Session["AdminId"]);
                            db.Entry(data).State = EntityState.Modified;
                            int i = db.SaveChanges();
                            if(i>0)
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


        public ActionResult SearchMediaTypeRecords(MediaType mediaType)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.MediaTypes.Where(x => x.MediaTypeID == mediaType.MediaTypeID).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeletedMediaType(MediaType mediaType)
        {
            string message = "";
            try
            {
                if(mediaType!=null)
                {
                    var data = db.MediaTypes.Where(x => x.MediaTypeID == mediaType.MediaTypeID).FirstOrDefault();
                    if(data!=null)
                    {
                        data.IsValid = false;
                        db.Entry(data).State = EntityState.Modified;
                        int i = db.SaveChanges();
                        if(i>0)
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
            catch(Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Mediatypedropdownlist()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var data = db.MediaTypes.Where(x => x.IsValid == true).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewMediatyoesearch()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.MediaTypes.Where(x => x.IsValid == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //---------------Media--------------------------------

        [Authorize]
        public ActionResult MediaPage()
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
        public ActionResult ViewMediaList()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.Medias.Where(x => x.IsValid == true).ToList();

            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateMedia(Media media)
        {
            string message = "";

            try
            {
                if (media != null)
                {
                    if (media.MediaID == 0)
                    {
                        Media objmedia = new Media();
                        objmedia.SongName = media.SongName;

                        objmedia.SingerName = media.SingerName;
                        objmedia.AuthorName = media.AuthorName;
                        objmedia.Composer = media.Composer;
                        objmedia.Labale = media.Labale;

                        objmedia.IsValid = true;
                        objmedia.CreatedByDate = DateTime.Now;
                        objmedia.CreatedByID = Convert.ToInt32(Session["AdminId"]);
                        db.Medias.Add(objmedia);
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
                        var data = db.Medias.Where(x => x.MediaID == media.MediaID).FirstOrDefault();
                        if (data != null)
                        {
                            data.SongName = media.SongName;
                            data.SingerName = media.SingerName;
                            data.AuthorName = media.AuthorName;
                            data.Composer = media.Composer;
                            data.Labale = media.Labale;

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


        public ActionResult SearchMediaRecords(Media media)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Medias.Where(x => x.MediaID == media.MediaID).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeletedMedia(Media media)
        {
            string message = "";
            try
            {
                if (media != null)
                {
                    var data = db.Medias.Where(x => x.MediaID == media.MediaID).FirstOrDefault();
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


        public  ActionResult Mediadropdownlist()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Medias.Where(x => x.IsValid == true).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //-----------------------------Add--Media----------------------------------------------------
        [Authorize]
        public ActionResult AddMediaPage()
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
        public ActionResult ViewAddMediaList()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from addmedia in db.AddMedias.Where(x=>x.IsValid==true)
                     join media in db.Medias on addmedia.MediaID equals media.MediaID 
                     join mediatype in db.MediaTypes on addmedia.MediaTypeID equals mediatype.MediaTypeID
                     orderby addmedia.MediaID
                     select new
                     {
                        addmedia.AddMediaID,
                        addmedia.MediaID,
                        addmedia.MediaType,
                        addmedia.Rent,
                        addmedia.Dscription,
                         media.SongName,
                         media.SingerName,
                         media.AuthorName,
                         media.Composer,
                         media.Labale,
                         mediatype.MediaTypeName
                     }).ToList();

            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateAddMedia(AddMedia addMedia)
        {
            string message = "";

            try
            {
                if (addMedia != null)
                {
                    if (addMedia.AddMediaID == 0)
                    {
                        AddMedia objaddmedia = new AddMedia();
                        objaddmedia.MediaTypeID = addMedia.MediaTypeID;
                        objaddmedia.MediaID = addMedia.MediaID;
                        objaddmedia.Rent = addMedia.Rent;
                        objaddmedia.Dscription = addMedia.Dscription;
                        objaddmedia.IsValid = true;
                        objaddmedia.CreatedByDate = DateTime.Now;
                        objaddmedia.CreatedByID = Convert.ToInt32(Session["AdminId"]);
                        db.AddMedias.Add(objaddmedia);
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
                        var data = db.AddMedias.Where(x => x.AddMediaID == addMedia.AddMediaID).FirstOrDefault();
                        if (data != null)
                        {
                            data.MediaTypeID = addMedia.MediaTypeID;
                            data.MediaID = addMedia.MediaID;
                            data.Rent = addMedia.Rent;
                            data.Dscription = addMedia.Dscription;
                          

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


        public ActionResult SearchAddMediaRecords(AddMedia addMedia)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.AddMedias.Where(x => x.AddMediaID == addMedia.AddMediaID).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeletedAddMedia(AddMedia addMedia)
        {
            string message = "";
            try
            {
                if (addMedia != null)
                {
                    var data = db.AddMedias.Where(x => x.AddMediaID == addMedia.AddMediaID).FirstOrDefault();
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

        [HttpPost]
        public ActionResult ViewMediatypeAllmedia(AddMedia objaddmedia)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from addmedia in db.AddMedias.Where(x =>x.MediaTypeID== objaddmedia.MediaTypeID && x.IsValid == true)
                       join media in db.Medias on addmedia.MediaID equals media.MediaID
                       join mediatype in db.MediaTypes on addmedia.MediaTypeID equals mediatype.MediaTypeID
                       orderby addmedia.MediaID
                       select new
                       {
                           addmedia.AddMediaID,
                           addmedia.MediaID,
                           addmedia.MediaType,
                           addmedia.Rent,
                           addmedia.Dscription,
                           media.SongName,
                           media.SingerName,
                           media.AuthorName,
                           media.Composer,
                           media.Labale,
                           mediatype.MediaTypeName
                       }).ToList();

           

            return Json(obj, JsonRequestBehavior.AllowGet);

        }


    }
}