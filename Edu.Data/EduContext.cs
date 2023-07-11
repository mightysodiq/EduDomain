using EduDomain;
using Microsoft.EntityFrameworkCore;

namespace Edu.Data
{
    public class EduContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentAddress>  studentAddresses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentAddress>(a => a.StudentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}