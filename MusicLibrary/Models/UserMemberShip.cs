namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserMemberShip")]
    public partial class UserMemberShip
    {
        [Key]
        public int MemberShipPlaneID { get; set; }

        public int? UserID { get; set; }

        public int? MemberShipID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? UserMemberGetDate { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifybyID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public virtual MemberShip MemberShip { get; set; }

        public virtual User User { get; set; }
    }
}
