namespace SakhirHotalManageSystem.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Gander { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        [StringLength(50)]
        public string UserContact { get; set; }

        [StringLength(50)]
        public string UserAdharNumber { get; set; }

        [StringLength(50)]
        public string UserPassword { get; set; }

        [StringLength(50)]
        public string UserAddress { get; set; }

        public int? UserRolesID { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
