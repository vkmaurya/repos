namespace Music_Library_ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Membership { get; set; }

        [StringLength(50)]
        public string Roll { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedBy_Id { get; set; }

        public DateTime? CreatedBy_Date { get; set; }

        public int? ModifyBy_Id { get; set; }

        public DateTime? ModifyBy_Date { get; set; }

        public int? DeletedBy_Id { get; set; }

        public DateTime? DeletedBy_Date { get; set; }
    }
}
