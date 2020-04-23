namespace vikash_Hospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modeldb : DbContext
    {
        public Modeldb()
            : base("name=Modeldb4")
        {
        }

        public virtual DbSet<PatientData> PatientDatas { get; set; }
        public virtual DbSet<Problame> Problames { get; set; }

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

            modelBuilder.Entity<Problame>()
                .Property(e => e.PatientSsno)
                .IsFixedLength();

            modelBuilder.Entity<Problame>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
