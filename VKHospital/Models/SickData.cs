namespace VKHospital.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SickData")]
    public partial class SickData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SickData()
        {
            PatientSelectSickDatas = new HashSet<PatientSelectSickData>();
        }

        [Key]
        public int SickTypeID { get; set; }

        [StringLength(50)]
        public string SickTypeName { get; set; }

        public int? DoctorTypeID { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? CreateByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? ModifyBYDate { get; set; }

        public int? DeletedByID { get; set; }

        public DateTime? DeleteByDate { get; set; }

        [JsonIgnore]
        public virtual DoctorType DoctorType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<PatientSelectSickData> PatientSelectSickDatas { get; set; }
    }
}
