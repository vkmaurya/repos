namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddMedia")]
    public partial class AddMedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddMedia()
        {
            MediaBookings = new HashSet<MediaBooking>();
            UserAndMediaBookings = new HashSet<UserAndMediaBooking>();
        }

        public int AddMediaID { get; set; }

        public int? MediaTypeID { get; set; }

        public int? MediaID { get; set; }

        [StringLength(50)]
        public string Rent { get; set; }

        [StringLength(50)]
        public string Dscription { get; set; }

        public string Images { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeltedByID { get; set; }

        public bool? IsValid { get; set; }

        public virtual Media Medium { get; set; }

        public virtual MediaType MediaType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediaBooking> MediaBookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAndMediaBooking> UserAndMediaBookings { get; set; }
    }
}
