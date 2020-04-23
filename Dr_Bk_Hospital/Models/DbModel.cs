namespace Dr_Bk_Hospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<PatientData> PatientDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientData>()
                .Property(e => e.Ssno)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Dob)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Roll)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.CreatedById)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.CreatedByDate)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.ModifyById)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.ModifyByDate)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.DeleteById)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.DeleteByDate)
                .IsUnicode(false);
        }
    }
}
