namespace musiclibrary2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicModeldb : DbContext
    {
        public MusicModeldb()
            : base("name=MusicModeldb")
        {
        }

        public virtual DbSet<RentData> RentDatas { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }
        public virtual DbSet<Mediadata> Mediadatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentData>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<RentData>()
                .Property(e => e.CategoryNumber)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Pincode)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Roll)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Categorynumber)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Mediadata>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
