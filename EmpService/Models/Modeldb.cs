namespace EmpService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modeldb : DbContext
    {
        public Modeldb()
            : base("name=Modeldb")
        {
        }

        public virtual DbSet<WebApiSwlServer> WebApiSwlServers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApiSwlServer>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<WebApiSwlServer>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<WebApiSwlServer>()
                .Property(e => e.address)
                .IsUnicode(false);
        }
    }
}
