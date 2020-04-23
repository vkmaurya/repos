namespace ASP_MVC_CRUD_Application_Ajax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AjaxApplication")]
    public partial class AjaxApplication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Contact { get; set; }

        [StringLength(10)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Email { get; set; }
    }
}
