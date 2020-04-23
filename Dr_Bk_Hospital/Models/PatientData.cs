namespace Dr_Bk_Hospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatientData")]
    public partial class PatientData
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ssno { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Dob { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Roll { get; set; }

        [StringLength(50)]
        public string CreatedById { get; set; }

        [StringLength(50)]
        public string CreatedByDate { get; set; }

        [StringLength(50)]
        public string ModifyById { get; set; }

        [StringLength(50)]
        public string ModifyByDate { get; set; }

        [StringLength(50)]
        public string DeleteById { get; set; }

        [StringLength(50)]
        public string DeleteByDate { get; set; }

        public bool? IsValid { get; set; }
    }
}
