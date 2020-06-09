using SakhirHotalManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SakhirHotalManageSystem.VwModel
{
    public class AccommodationViewModel
    {

        public AccommodationType AccommodationType { get; set; }
        public List<AccommodationPackage> AccommodationPackages { get; set; }
        public List<Accommodation> Accommodations { get; set; }

    }
}