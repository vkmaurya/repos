namespace webApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<carreg> carregs { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<rentail> rentails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<carreg>()
                .Property(e => e.carno)
                .IsUnicode(false);

            modelBuilder.Entity<carreg>()
                .Property(e => e.make)
                .IsUnicode(false);

            modelBuilder.Entity<carreg>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<carreg>()
                .Property(e => e.availbale)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.custname)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<rentail>()
                .Property(e => e.carid)
                .IsUnicode(false);

            modelBuilder.Entity<rentail>()
                .Property(e => e.custid)
                .IsUnicode(false);

            modelBuilder.Entity<rentail>()
                .Property(e => e.edate)
                .IsFixedLength();
        }
    }
}
