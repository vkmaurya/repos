namespace Exam_Centre_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public int Id { get; set; }

        [Column("Question")]
        [StringLength(50)]
        public string Question1 { get; set; }

        [StringLength(50)]
        public string Opa { get; set; }

        [StringLength(50)]
        public string Opb { get; set; }

        [StringLength(50)]
        public string Opc { get; set; }

        [StringLength(50)]
        public string Opd { get; set; }

        [StringLength(50)]
        public string Ope { get; set; }
    }
}
