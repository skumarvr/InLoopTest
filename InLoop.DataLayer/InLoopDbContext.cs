using InLoop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InLoop.DataLayer
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
    // https://docs.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations

    public class InLoopDbContext : DbContext
    {
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<LectureSchedule> LectureSchedule { get; set; }
        public DbSet<LectureTheatre> LectureTheatre { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO : Move 
            options.UseSqlite(@"Data Source=.\Database\InLoop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(e => e.HasNoKey());
        }
    }

}
