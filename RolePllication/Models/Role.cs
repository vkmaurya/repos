namespace RolePllication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [Key]
        public int RId { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string Rolename { get; set; }

        public virtual User User { get; set; }
    }
}
