namespace VKHospital.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailData")]
    public partial class EmailData
    {
        [Key]
        public int EmailID { get; set; }

        [StringLength(50)]
        public string EmailOTP { get; set; }

        public DateTime? EmailTime { get; set; }

        public int? PatientID { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? CreateByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? ModifyBYDate { get; set; }

        public int? DeletedByID { get; set; }

        public DateTime? DeleteByDate { get; set; }

        [JsonIgnore]
        public virtual PatientData PatientData { get; set; }
    }
}
