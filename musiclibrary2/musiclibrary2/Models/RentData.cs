namespace musiclibrary2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RentData")]
    public partial class RentData
    {
        [Key]
        public int RentId { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string CategoryNumber { get; set; }

        public int? Price { get; set; }

        public int? Createdby_Id { get; set; }

        public DateTime? Createdby_Date { get; set; }

        public int? Modifiedby_Id { get; set; }

        public DateTime? Modifiedby_Date { get; set; }

        public int? Deleteby_Id { get; set; }

        public DateTime? Deleteby_Date { get; set; }

        public bool? Status { get; set; }

        public DateTime? RentDate { get; set; }
    }
}
