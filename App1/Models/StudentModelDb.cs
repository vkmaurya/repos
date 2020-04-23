namespace App1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentModelDb : DbContext
    {
        public StudentModelDb()
            : base("name=StudentModelDb")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
