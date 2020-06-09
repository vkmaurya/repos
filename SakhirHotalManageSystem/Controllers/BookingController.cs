using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakhirHotalManageSystem.Controllers
{
    public class BookingController : Controller
    {
        SakhirDbModel db = new SakhirDbModel();

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookingHotal(HotalBooking hotalBooking)
        {
            string message = "";
            try
            {
                if (hotalBooking != null)
                {
                    HotalBooking objhotalbooking = new HotalBooking();
                    objhotalbooking.AccommodationID = hotalBooking.AccommodationID;
                    objhotalbooking.CustomerId = 1;
                    objhotalbooking.BookingDate = DateTime.Now;
                    objhotalbooking.CheckInDate = hotalBooking.CheckInDate;
                    objhotalbooking.Duration = hotalBooking.Duration;
                    objhotalbooking.NoOfAdults = hotalBooking.NoOfAdults;
                    objhotalbooking.NoOfChildren = hotalBooking.NoOfChildren;
                    objhotalbooking.GuestName = hotalBooking.GuestName;
                    objhotalbooking.BookingEmail = hotalBooking.BookingEmail;
                    objhotalbooking.AddMesageNotes = hotalBooking.AddMesageNotes;
                    objhotalbooking.IsValid = null;
                    objhotalbooking.CreatedByDate = DateTime.Now;

                    db.HotalBookings.Add(objhotalbooking);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        message = "submit";
                    }
                    else
                    {
                        message = "notsubmit";
                    }

                }



            }
            catch (Exception ex)
            {
                message = "exception";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //-------------------------------------View Hotal Booking-----------------------------------------------------------

        public ActionResult HotaleBookingTablePage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewBookingList()
        {

            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.HotalBookings.Where(x => x.IsValid == null).ToList();
            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public ActionResult ViewHotalBookingRecords(HotalBooking hotalBooking)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from booking in db.HotalBookings.Where(x => x.BookingID == hotalBooking.BookingID && x.IsValid == null)
                       join accommodation in db.Accommodations
                       on booking.AccommodationID equals accommodation.AccommodationID
                       join customer in db.Customers
                       on booking.CustomerId equals customer.CustomerId

                       join accommodationpackage in db.AccommodationPackages on
                       accommodation.AccomodationPackageID equals accommodationpackage.AccommodationPackageID

                       join accommodationtype in db.AccommodationTypes on

                       accommodationpackage.AccommodationTypeID equals accommodationtype.AccommodatioTypeID

                       select new
                       {
                           booking.BookingID,
                           booking.CustomerId,
                           booking.AccommodationID,
                           booking.BookingDate,
                           booking.CheckInDate,
                           booking.CheckOutDate,
                           booking.Duration,
                           booking.NoOfAdults,
                           booking.NoOfChildren,
                           booking.GuestName,
                           booking.BookingEmail,
                           booking.AddMesageNotes,
                           customer.CustomerContact,
                           accommodation.AccommodationName,
                           customer.CustomerName,
                           accommodationpackage.AccommodationPackageName,
                           accommodationpackage.FeePerNight,
                           accommodationpackage.NoOfRoom,
                           accommodationtype.AccommodationTypeName,

                       }).FirstOrDefault();


            return Json(obj, JsonRequestBehavior.AllowGet);
        }



        public ActionResult BookingCheckIn(HotalBooking hotalBooking)
        {
            string message = "";

            try
            {
                if(hotalBooking!=null)
                {

                    var data = db.HotalBookings.Where(x => x.BookingID == hotalBooking.BookingID).FirstOrDefault();
                    if(data!=null)
                    {
                        data.IsValid = false;
                        db.Entry(data).State = EntityState.Modified;

                        int i = db.SaveChanges();
                        if(i>0)
                        {
                            message = "checkIn";
                        }
                        else
                        {
                            message = "notcheckin";
                        }
                    }

                }
            }
            catch(Exception ex)
            {

                message = "exception";
            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }


        //-----------------------------------------------booking checkIN-------------------------------------------------------------------

        public ActionResult ViewBookingListPage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewBookingListCheckIn()
        {

            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.HotalBookings.Where(x => x.IsValid == false).ToList();
            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult ViewHotalBookingRecordsCheckList(HotalBooking hotalBooking)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from booking in db.HotalBookings.Where(x => x.BookingID == hotalBooking.BookingID && x.IsValid == false)
                       join accommodation in db.Accommodations
                       on booking.AccommodationID equals accommodation.AccommodationID
                       join customer in db.Customers
                       on booking.CustomerId equals customer.CustomerId

                       join accommodationpackage in db.AccommodationPackages on
                       accommodation.AccomodationPackageID equals accommodationpackage.AccommodationPackageID

                       join accommodationtype in db.AccommodationTypes on

                       accommodationpackage.AccommodationTypeID equals accommodationtype.AccommodatioTypeID

                       select new
                       {
                           booking.BookingID,
                           booking.CustomerId,
                           booking.AccommodationID,
                           booking.BookingDate,
                           booking.CheckInDate,
                           booking.CheckOutDate,
                           booking.Duration,
                           booking.NoOfAdults,
                           booking.NoOfChildren,
                           booking.GuestName,
                           booking.BookingEmail,
                           booking.AddMesageNotes,
                           customer.CustomerContact,
                           accommodation.AccommodationName,
                           customer.CustomerName,
                           accommodationpackage.AccommodationPackageName,
                           accommodationpackage.FeePerNight,
                           accommodationpackage.NoOfRoom,
                           accommodationtype.AccommodationTypeName,

                       }).FirstOrDefault();


            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public ActionResult BookingCheckOut(HotalBooking hotalBooking)
        {
            string message = "";

            try
            {
                if (hotalBooking != null)
                {

                    var data = db.HotalBookings.Where(x => x.BookingID == hotalBooking.BookingID).FirstOrDefault();
                    if (data != null)
                    {
                        data.IsValid = true;
                        data.CheckOutDate = DateTime.Now;
                        db.Entry(data).State = EntityState.Modified;

                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            message = "checkOut";
                        }
                        else
                        {
                            message = "notcheckOut";
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

        //-----------------------------------------------booking checkOut-------------------------------------------------------------------

        public ActionResult ViewBookingCheckOutPage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewBookingListCheckOu()
        {

            db.Configuration.ProxyCreationEnabled = false;

            var obj = db.HotalBookings.Where(x => x.IsValid == true).ToList();
            var data = new { data = obj };

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult ViewHotalBookingRecordsChecoutkList(HotalBooking hotalBooking)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var obj = (from booking in db.HotalBookings.Where(x => x.BookingID == hotalBooking.BookingID && x.IsValid == true)
                       join accommodation in db.Accommodations
                       on booking.AccommodationID equals accommodation.AccommodationID
                       join customer in db.Customers
                       on booking.CustomerId equals customer.CustomerId

                       join accommodationpackage in db.AccommodationPackages on
                       accommodation.AccomodationPackageID equals accommodationpackage.AccommodationPackageID

                       join accommodationtype in db.AccommodationTypes on

                       accommodationpackage.AccommodationTypeID equals accommodationtype.AccommodatioTypeID

                       select new
                       {
                           booking.BookingID,
                           booking.CustomerId,
                           booking.AccommodationID,
                           booking.BookingDate,
                           booking.CheckInDate,
                           booking.CheckOutDate,
                           booking.Duration,
                           booking.NoOfAdults,
                           booking.NoOfChildren,
                           booking.GuestName,
                           booking.BookingEmail,
                           booking.AddMesageNotes,
                           customer.CustomerContact,
                           accommodation.AccommodationName,
                           customer.CustomerName,
                           accommodationpackage.AccommodationPackageName,
                           accommodationpackage.FeePerNight,
                           accommodationpackage.NoOfRoom,
                           accommodationtype.AccommodationTypeName,

                       }).FirstOrDefault();


            return Json(obj, JsonRequestBehavior.AllowGet);
        }



    }
}