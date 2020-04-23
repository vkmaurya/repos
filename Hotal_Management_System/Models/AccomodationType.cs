namespace Hotal_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccomodationType")]
    public partial class AccomodationType
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedById { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyById { get; set; }

        public DateTime? DeleteByDate { get; set; }

        public int? DeleteById { get; set; }

        public bool? IsValid { get; set; }
    }
}
