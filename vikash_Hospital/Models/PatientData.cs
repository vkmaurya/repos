namespace vikash_Hospital.Models
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

        public int? CreatedById { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? ModifyById { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? DeleteById { get; set; }

        public DateTime? DeleteByDate { get; set; }

        public bool? IsValid { get; set; }
    }
}
