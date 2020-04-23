namespace Music_Library_ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mediadata")]
    public partial class Mediadata
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string CategoryNumber { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        public string Image { get; set; }

        public int? Createdby_Id { get; set; }

        public DateTime? Createdby_Date { get; set; }

        public int? Modifiedby_Id { get; set; }

        public DateTime? Modifiedby_Data { get; set; }

        public int? Deletedby_Id { get; set; }

        public DateTime? Deletedby_Date { get; set; }

        public bool? Media_Status { get; set; }
    }
}
