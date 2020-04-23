namespace Student_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string CourseName { get; set; }

        public int? CreatedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedByData { get; set; }

        public int? ModifyById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyByData { get; set; }

        public int? DeleteById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteByData { get; set; }

        public bool? IsValid { get; set; }
    }
}
