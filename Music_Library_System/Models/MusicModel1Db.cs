namespace Music_Library_System.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicModel1Db : DbContext
    {
        public MusicModel1Db()
            : base("name=MusicModel1Db")
        {
        }

        public virtual DbSet<UserRentData> UserRentDatas { get; set; }
        public virtual DbSet<Mediadata> Mediadatas { get; set; }
        public virtual DbSet<RentData> RentDatas { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<RentData>()
                .Property(e => e.UserName)
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
        }
    }
}
