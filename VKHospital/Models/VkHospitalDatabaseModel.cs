namespace VKHospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VkHospitalDatabaseModel : DbContext
    {
        public VkHospitalDatabaseModel()
            : base("name=VkHospitalDatabaseModel")
        {
        }

        public virtual DbSet<AppointmentData> AppointmentDatas { get; set; }
        public virtual DbSet<DoctorData> DoctorDatas { get; set; }
        public virtual DbSet<DoctorType> DoctorTypes { get; set; }
        public virtual DbSet<EmailData> EmailDatas { get; set; }
        public virtual DbSet<ExceptionDate> ExceptionDates { get; set; }
        public virtual DbSet<PatientData> PatientDatas { get; set; }
        public virtual DbSet<PatientSelectSickData> PatientSelectSickDatas { get; set; }
        public virtual DbSet<SickData> SickDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentData>()
                .Property(e => e.AppointmentPatientSession)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorData>()
                .Property(e => e.DoctorName)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorData>()
                .Property(e => e.DoctorTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorType>()
                .Property(e => e.DoctorTypeName)
                .IsFixedLength();

            modelBuilder.Entity<EmailData>()
                .Property(e => e.EmailOTP)
                .IsUnicode(false);

            modelBuilder.Entity<ExceptionDate>()
                .Property(e => e.ExceptionType)
                .IsUnicode(false);

            modelBuilder.Entity<ExceptionDate>()
                .Property(e => e.ExceptionName)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.PatientName)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.SSNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Gander)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<PatientData>()
                .Property(e => e.Roll)
                .IsUnicode(false);

            modelBuilder.Entity<SickData>()
                .Property(e => e.SickTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<SickData>()
                .HasMany(e => e.PatientSelectSickDatas)
                .WithOptional(e => e.SickData)
                .HasForeignKey(e => e.SickID);
        }
    }
}
