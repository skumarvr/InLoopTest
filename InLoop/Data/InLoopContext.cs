using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InLoop.ViewModels;

namespace InLoop.Data
{
    public class InLoopContext : DbContext
    {
        public InLoopContext (DbContextOptions<InLoopContext> options)
            : base(options)
        {
        }

        public DbSet<InLoop.ViewModels.LectureResponse> LectureResponse { get; set; }

        public DbSet<InLoop.ViewModels.LectureTheatreResponse> LectureTheatreResponse { get; set; }

        public DbSet<InLoop.ViewModels.SubjectResponse> SubjectResponse { get; set; }

        public DbSet<InLoop.ViewModels.Student> Student { get; set; }
    }
}
