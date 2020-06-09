namespace SakhirHotalManageSystem.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Accommodation")]
    public partial class Accommodation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accommodation()
        {
            HotalBookings = new HashSet<HotalBooking>();
        }

        public int AccommodationID { get; set; }

        public int? AccomodationPackageID { get; set; }

        [StringLength(50)]
        public string AccommodationName { get; set; }

        public string AccommodationImage { get; set; }

        [StringLength(50)]
        public string AccommodationDescription { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        [JsonIgnore]
        public virtual AccommodationPackage AccommodationPackage { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotalBooking> HotalBookings { get; set; }
    }
}
