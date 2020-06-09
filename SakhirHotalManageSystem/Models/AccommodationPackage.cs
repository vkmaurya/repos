namespace SakhirHotalManageSystem.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccommodationPackage")]
    public partial class AccommodationPackage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccommodationPackage()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        public int AccommodationPackageID { get; set; }

        public int? AccommodationTypeID { get; set; }

        [StringLength(50)]
        public string AccommodationPackageName { get; set; }

        [StringLength(50)]
        public string NoOfRoom { get; set; }

        [StringLength(50)]
        public string FeePerNight { get; set; }

        public string AccommodationPackageImage { get; set; }

        [StringLength(50)]
        public string AccommodationPackageDescription { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accommodation> Accommodations { get; set; }

        [JsonIgnore]
        public virtual AccommodationType AccommodationType { get; set; }
    }
}
