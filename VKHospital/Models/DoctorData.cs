namespace VKHospital.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoctorData")]
    public partial class DoctorData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorData()
        {
            AppointmentDatas = new HashSet<AppointmentData>();
            PatientSelectSickDatas = new HashSet<PatientSelectSickData>();
        }

        [Key]
        public int DoctorId { get; set; }

        [StringLength(50)]
        public string DoctorName { get; set; }

        public int? DoctorTypeID { get; set; }

        [StringLength(1)]
        public string DoctorTypeName { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? CreateByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? ModifyBYDate { get; set; }

        public int? DeletedByID { get; set; }

        public DateTime? DeleteByDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<AppointmentData> AppointmentDatas { get; set; }

        [JsonIgnore]
        public virtual DoctorType DoctorType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<PatientSelectSickData> PatientSelectSickDatas { get; set; }
    }
}
