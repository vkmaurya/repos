using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentals.Models
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public string carid { get; set; }
        public string custid { get; set; }
        public string fee { get; set; }
        public Nullable<System.DateTime> sdate { get; set; }
        public Nullable<System.DateTime> edate { get; set; }

        public string available { get; set; }
    }
}