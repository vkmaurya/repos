namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediaBooking")]
    public partial class MediaBooking
    {
        public int MediaBookingID { get; set; }

        public int? UserID { get; set; }

        public int? AddMediaID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Duration { get; set; }

        public double? Amount { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        public virtual AddMedia AddMedia { get; set; }

        public virtual User User { get; set; }
    }
}
