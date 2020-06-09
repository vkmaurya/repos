namespace SakhirHotalManageSystem.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotalBooking")]
    public partial class HotalBooking
    {
        [Key]
        public int BookingID { get; set; }

        public int? CustomerId { get; set; }

        public int? AccommodationID { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public int? Duration { get; set; }

        public int? NoOfAdults { get; set; }

        public int? NoOfChildren { get; set; }

        [StringLength(50)]
        public string GuestName { get; set; }

        [StringLength(50)]
        public string BookingEmail { get; set; }

        [StringLength(50)]
        public string AddMesageNotes { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        [JsonIgnore]
        public virtual Accommodation Accommodation { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
