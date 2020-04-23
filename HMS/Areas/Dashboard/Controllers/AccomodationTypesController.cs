using HMS.Areas.ViewModels;
using HMS.Entities;
using HMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        // GET: Dashboard/AccomodationTypes
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing()
        {
            AccomodationTypesListingModels model = new AccomodationTypesListingModels();

            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            return PartialView("_Listing", model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            if (ID.HasValue)
            {//we are trying to edit or records
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID.Value);
                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("_Action", model);
        }


        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0)//we are trying to edit records
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesService.UpdateAccomodationType(accomodationType);
            }
            else// we are trying to create records
            {
                AccomodationType accomodationType = new AccomodationType();
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                 result = accomodationTypesService.SaveAccomodationType(accomodationType);
            }


            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, message = "Unable to add AccomodationType" };
            }

            return json;
        }


        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();
            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID);
            model.ID = accomodationType.ID;
         

            return PartialView("_Delete", model);
        }


    }
}