namespace VKHospital.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatientSelectSickData")]
    public partial class PatientSelectSickData
    {
        [Key]
        public int PatientSelectSickID { get; set; }

        public int? PatientID { get; set; }

        public int? DoctorID { get; set; }

        public int? SickID { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? CreateByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? ModifyBYDate { get; set; }

        public int? DeletedByID { get; set; }

        public DateTime? DeleteByDate { get; set; }

        [JsonIgnore]
        public virtual DoctorData DoctorData { get; set; }
        [JsonIgnore]
        public virtual PatientData PatientData { get; set; }
        [JsonIgnore]
        public virtual SickData SickData { get; set; }
    }
}
