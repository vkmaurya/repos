namespace Student_Management_System.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modeldb : DbContext
    {
        public Modeldb()
            : base("name=Modeldb3")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CoursesDetail> CoursesDetails { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<CoursesDetail>()
                .Property(e => e.CoursePrice)
                .IsUnicode(false);

            modelBuilder.Entity<CoursesDetail>()
                .Property(e => e.CourseDuration)
                .IsUnicode(false);

            modelBuilder.Entity<CoursesDetail>()
                .Property(e => e.IsValid)
                .IsFixedLength();

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
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Collage)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Amount)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Duration)
                .IsUnicode(false);
        }
    }
}
