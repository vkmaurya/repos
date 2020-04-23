namespace Music_Library_ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerRentData")]
    public partial class CustomerRentData
    {
        public int Id { get; set; }

        public int? MediaId { get; set; }

        public int? CustomerId { get; set; }
    }
}
