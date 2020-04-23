namespace Music_Library_ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RentData")]
    public partial class RentData
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string MediaId { get; set; }

        [StringLength(50)]
        public string TotalAmount { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        public DateTime? Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public int? Createdby_Id { get; set; }

        public DateTime? Createdby_Date { get; set; }

        public int? Modifiedby_Id { get; set; }

        public DateTime? Modifiedby_Date { get; set; }

        public int? Deleteby_Id { get; set; }

        public DateTime? Deleteby_Date { get; set; }

        public bool? Status { get; set; }
    }
}
