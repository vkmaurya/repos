namespace EntityCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

      [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Office { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? Salary { get; set; }
    }
}
