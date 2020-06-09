namespace SakhirHotalManageSystem.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            HotalBookings = new HashSet<HotalBooking>();
        }

        public int CustomerId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerGander { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        [StringLength(50)]
        public string CustomerContact { get; set; }

        [StringLength(50)]
        public string CustomerPassword { get; set; }

        public DateTime? CreatedByDate { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? ModifyByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? DeletedByDate { get; set; }

        public int? DeletedByID { get; set; }

        public bool? IsValid { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotalBooking> HotalBookings { get; set; }
    }
}
