using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Areas.ViewModels;

namespace HMS.Areas.ViewModels
{
    public class AccomodationTypesListingModels
    {
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
    }

    public class AccomodationTypeActionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}