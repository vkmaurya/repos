namespace CustomerAmountManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string Day { get; set; }

        public int? CreatedById { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyById { get; set; }

        public int? DeletedById { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public bool? IsValid { get; set; }
    }
}
