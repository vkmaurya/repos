namespace vikash_Hospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Problame")]
    public partial class Problame
    {
        public int Id { get; set; }

        public int? DoctorId { get; set; }

        [StringLength(10)]
        public string PatientSsno { get; set; }

        public int? ProblameId { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsValid { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
