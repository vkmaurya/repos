namespace webApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rentail")]
    public partial class rentail
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string carid { get; set; }

        [StringLength(50)]
        public string custid { get; set; }

        public int? fee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? sdate { get; set; }

        [StringLength(10)]
        public string edate { get; set; }
    }
}
