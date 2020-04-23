namespace Exam_Centre_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Cours
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string CouresesName { get; set; }
    }
}
