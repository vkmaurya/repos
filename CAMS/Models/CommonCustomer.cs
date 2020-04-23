namespace CAMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommonCustomer")]
    public partial class CommonCustomer
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string TotalAmount { get; set; }

        public int? CreatedById { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? ModifyById { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? DeletedById { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public bool? IsValid { get; set; }
    }
}
