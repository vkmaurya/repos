namespace VKHospital.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoctorType")]
    public partial class DoctorType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorType()
        {
            DoctorDatas = new HashSet<DoctorData>();
            SickDatas = new HashSet<SickData>();
        }

        public int DoctorTypeID { get; set; }

        [StringLength(10)]
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
        public virtual ICollection<DoctorData> DoctorDatas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<SickData> SickDatas { get; set; }
    }
}
