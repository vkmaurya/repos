namespace webApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string custname { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }
    }
}
