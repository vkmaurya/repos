namespace Music_Library_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRentData")]
    public partial class UserRentData
    {
        public int Id { get; set; }

        public int? MediaId { get; set; }

        public int? UserId { get; set; }
    }
}
