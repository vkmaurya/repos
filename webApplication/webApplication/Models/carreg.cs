namespace webApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("carreg")]
    public partial class carreg
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string carno { get; set; }

        [StringLength(50)]
        public string make { get; set; }

        [StringLength(50)]
        public string model { get; set; }

        [StringLength(50)]
        public string availbale { get; set; }
    }
}
