using InLoop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InLoop.DataLayer
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
    // https://docs.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations

    public class InLoopDbContext : DbContext
    {
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureSchedule> LectureSchedules { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=.\Database\InLoop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(e => e.HasNoKey()); 
        }
    }

}
