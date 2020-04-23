namespace Student_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CoursesDetail
    {
        public int Id { get; set; }

        public int? CourseId { get; set; }

        [StringLength(50)]
        public string CoursePrice { get; set; }

        [StringLength(50)]
        public string CourseDuration { get; set; }

        public int? CreatedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedByData { get; set; }

        public int? ModifyById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyByData { get; set; }

        public int? DeleteById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteByData { get; set; }

        [StringLength(10)]
        public string IsValid { get; set; }
    }
}
