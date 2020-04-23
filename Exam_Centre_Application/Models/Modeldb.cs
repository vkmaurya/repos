namespace Exam_Centre_Application.Models
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

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<EmailOtp> EmailOtps { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.CouresesName)
                .IsUnicode(false);

            modelBuilder.Entity<EmailOtp>()
                .Property(e => e.Otp)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Question1)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Opa)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Opb)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Opc)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Opd)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Ope)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Gander)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Images)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CoursesId)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Pincode)
                .IsUnicode(false);
        }
    }
}
