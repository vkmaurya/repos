namespace CAMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? CreatedById { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? ModifyById { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? DeletedById { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public bool? IsValid { get; set; }
    }
}
