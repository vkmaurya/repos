namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberShip")]
    public partial class MemberShip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberShip()
        {
            UserMemberShips = new HashSet<UserMemberShip>();
        }

        public int MemberShipID { get; set; }

        [StringLength(50)]
        public string MemberShipName { get; set; }

        [StringLength(50)]
        public string MemberShipDuration { get; set; }

        public int? MemberShipAmount { get; set; }

        [StringLength(50)]
        public string MemberShipDescription { get; set; }

        [StringLength(50)]
        public string MemberShipStatus { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMemberShip> UserMemberShips { get; set; }
    }
}
