namespace Hotal_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Accomo")]
    public partial class Accomo
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AccomodationName { get; set; }

        [StringLength(50)]
        public string AccomodationDescription { get; set; }

        public int? AccomodationPackageId { get; set; }
    }
}
