namespace ASP_MVC_CRUD_Application_Ajax.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<AjaxApplication> AjaxApplications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AjaxApplication>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<AjaxApplication>()
                .Property(e => e.Contact)
                .IsFixedLength();

            modelBuilder.Entity<AjaxApplication>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<AjaxApplication>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
