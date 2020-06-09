namespace MusicLibrary.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicLibraryModelDB : DbContext
    {
        public MusicLibraryModelDB()
            : base("name=MusicLibraryModelDB1")
        {
        }

        public virtual DbSet<AddMedia> AddMedias { get; set; }
        public virtual DbSet<BookingMedia> BookingMedias { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<MediaBooking> MediaBookings { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<MemberShip> MemberShips { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAndMediaBooking> UserAndMediaBookings { get; set; }
        public virtual DbSet<UserMemberShip> UserMemberShips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddMedia>()
                .Property(e => e.Rent)
                .IsUnicode(false);

            modelBuilder.Entity<AddMedia>()
                .Property(e => e.Dscription)
                .IsUnicode(false);

            modelBuilder.Entity<AddMedia>()
                .Property(e => e.Images)
                .IsUnicode(false);

            modelBuilder.Entity<BookingMedia>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<BookingMedia>()
                .Property(e => e.Amount)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.SongName)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.SingerName)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.Composer)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.Labale)
                .IsUnicode(false);

            modelBuilder.Entity<MediaBooking>()
                .Property(e => e.Duration)
                .IsUnicode(false);

            modelBuilder.Entity<MediaType>()
                .Property(e => e.MediaTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<MemberShip>()
                .Property(e => e.MemberShipName)
                .IsUnicode(false);

            modelBuilder.Entity<MemberShip>()
                .Property(e => e.MemberShipDuration)
                .IsUnicode(false);

            modelBuilder.Entity<MemberShip>()
                .Property(e => e.MemberShipDescription)
                .IsUnicode(false);

            modelBuilder.Entity<MemberShip>()
                .Property(e => e.MemberShipStatus)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserContact)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPasword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Userstatus)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserRoll)
                .IsUnicode(false);

            modelBuilder.Entity<UserAndMediaBooking>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<UserMemberShip>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
