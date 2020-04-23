namespace Music_Library_ManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Music_ModelDb : DbContext
    {
        public Music_ModelDb()
            : base("name=Music_ModelDb")
        {
        }

        public virtual DbSet<CustomerRentData> CustomerRentDatas { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Mediadata> Mediadatas { get; set; }
        public virtual DbSet<RentData> RentDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Membership)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Roll)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.CategoryNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Price)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.TotalAmount)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.Contact)
                .IsUnicode(false);
        }
    }
}
