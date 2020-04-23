namespace Exam_Centre_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailOtp")]
    public partial class EmailOtp
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }

        [StringLength(50)]
        public string Otp { get; set; }

        public DateTime? Stime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
