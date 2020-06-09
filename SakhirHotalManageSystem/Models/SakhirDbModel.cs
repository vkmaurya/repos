namespace SakhirHotalManageSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SakhirDbModel : DbContext
    {
        public SakhirDbModel()
            : base("name=SakhirDbModel")
        {
        }

        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<AccommodationPackage> AccommodationPackages { get; set; }
        public virtual DbSet<AccommodationType> AccommodationTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<HotalBooking> HotalBookings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accommodation>()
                .Property(e => e.AccommodationName)
                .IsUnicode(false);

            modelBuilder.Entity<Accommodation>()
                .Property(e => e.AccommodationImage)
                .IsUnicode(false);

            modelBuilder.Entity<Accommodation>()
                .Property(e => e.AccommodationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationPackage>()
                .Property(e => e.AccommodationPackageName)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationPackage>()
                .Property(e => e.NoOfRoom)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationPackage>()
                .Property(e => e.FeePerNight)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationPackage>()
                .Property(e => e.AccommodationPackageImage)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationPackage>()
                .Property(e => e.AccommodationPackageDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationPackage>()
                .HasMany(e => e.Accommodations)
                .WithOptional(e => e.AccommodationPackage)
                .HasForeignKey(e => e.AccomodationPackageID);

            modelBuilder.Entity<AccommodationType>()
                .Property(e => e.AccommodationTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationType>()
                .Property(e => e.AccommodationTypeImage)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationType>()
                .Property(e => e.AccommodationTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationType>()
                .HasMany(e => e.AccommodationPackages)
                .WithOptional(e => e.AccommodationType)
                .HasForeignKey(e => e.AccommodationTypeID);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerGander)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerContact)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerPassword)
                .IsUnicode(false);

            modelBuilder.Entity<HotalBooking>()
                .Property(e => e.GuestName)
                .IsUnicode(false);

            modelBuilder.Entity<HotalBooking>()
                .Property(e => e.BookingEmail)
                .IsUnicode(false);

            modelBuilder.Entity<HotalBooking>()
                .Property(e => e.AddMesageNotes)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RolesName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.UserRolesID);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gander)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserContact)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserAdharNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserAddress)
                .IsUnicode(false);
        }
    }
}
