using InLoop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace InLoop.DataLayer
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
    // https://docs.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations

    public class InLoopDbContext : DbContext
    {
        public InLoopDbContext(DbContextOptions<InLoopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureSchedule> LectureSchedules { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Enrollment>(e => e.HasNoKey());
            modelBuilder.Entity<Enrollment>()
                        .HasKey(x => new { x.StudentId, x.SubjectId });
        }
    }
}
