namespace Hotal_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int ID { get; set; }

        public int? AccomodationID { get; set; }

        public DateTime? FromDate { get; set; }

        public int? Duration { get; set; }
    }
}
