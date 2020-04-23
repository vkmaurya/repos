namespace Exam_Centre_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Gander { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public string Images { get; set; }

        [StringLength(50)]
        public string CoursesId { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(50)]
        public string Pincode { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public bool? IsValid { get; set; }

        public int? RollNumber { get; set; }
    }
}
