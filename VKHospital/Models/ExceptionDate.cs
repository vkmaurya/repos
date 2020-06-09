namespace VKHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionDate")]
    public partial class ExceptionDate
    {
        [Key]
        public int ExceptionID { get; set; }

        [StringLength(50)]
        public string ExceptionType { get; set; }

        [StringLength(50)]
        public string ExceptionName { get; set; }

        public DateTime? ExceptionDateTime { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? CreateByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? ModifyBYDate { get; set; }

        public int? DeletedByID { get; set; }

        public DateTime? DeleteByDate { get; set; }
    }
}
