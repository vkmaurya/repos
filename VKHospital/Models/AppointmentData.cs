namespace VKHospital.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppointmentData")]
    public partial class AppointmentData
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateTime? AppointmentDateStart { get; set; }

        
        public DateTime? AppointmentDateEnd { get; set; }

        public int? DoctorID { get; set; }

        public int? PatientID { get; set; }

        public bool? AppointmentStatus { get; set; }

       
        public string AppointmentPatientSession { get; set; }

        public DateTime? AppointmentBookingDate { get; set; }

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
    }
}
