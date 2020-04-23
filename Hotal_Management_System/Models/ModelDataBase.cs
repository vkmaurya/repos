namespace Hotal_Management_System.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDataBase : DbContext
    {
        public ModelDataBase()
            : base("name=ModelDataBase")
        {
        }

        public virtual DbSet<Accomo> Accomoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Accomodationdata> Accomodationdatas { get; set; }
        public virtual DbSet<AccomodationPackage> AccomodationPackages { get; set; }
        public virtual DbSet<AccomodationType> AccomodationTypes { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accomo>()
                .Property(e => e.AccomodationName)
                .IsUnicode(false);

            modelBuilder.Entity<Accomo>()
                .Property(e => e.AccomodationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Countery)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Accomodationdata>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Accomodationdata>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AccomodationPackage>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
