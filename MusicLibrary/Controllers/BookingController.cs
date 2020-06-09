using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class BookingController : Controller
    {
        MusicLibraryModelDB db = new MusicLibraryModelDB();
        // GET: Booking
        public ActionResult CheckDateAvailable(UserAndMediaBooking userAndMediaBooking)
        {
            string message = "";
            try
            {
                if(userAndMediaBooking!=null)
                {
                    var data = db.UserAndMediaBookings.Where(x => x.IsValid == true && x.AddMediaID == userAndMediaBooking.AddMediaID && x.CreatedByDate == userAndMediaBooking.CreatedByDate).FirstOrDefault();

                    if(data==null)
                    {
                        message = "avalibale";
                    }
                    else
                    {
                        message = "notavalibale";
                    }

                }
            }
            catch (Exception ex)
            {
                message = "Exception";
            }
            return Json(message,JsonRequestBehavior.AllowGet);
        }
    }
}