using AutoMapper;
using AutoMapper.QueryableExtensions;
using InLoop.Domain.Repository;
using InLoop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.DataLayer.Repository
{
    public class InLoopTestRepository : IInLoopTestRepository, IDisposable
    {
        private readonly InLoopDbContext _context;
        private readonly IConfigurationProvider _mapperConfig;

        public InLoopTestRepository(InLoopDbContext context, IConfigurationProvider config)
        {
            _context = context;
            _mapperConfig = config;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Student>> GetStudentsAsync(CancellationToken ct = default)
        {
            return await _context.Students
                                .ProjectTo<Student>(_mapperConfig)
                                .ToListAsync();
        }

        public async Task AddStudentAsync(Student student, CancellationToken ct = default)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetSubjectsAsync(CancellationToken ct = default)
        {
            return await _context.Subjects
                                .ProjectTo<Subject>(_mapperConfig)
                                .ToListAsync();
        }

        public async Task AddSubjectAsync(Subject subject, CancellationToken ct = default)
        {
            _context.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LectureTheatre>> GetLectureTheatresAsync(CancellationToken ct = default)
        {
            return await _context.LectureTheatres
                                .ProjectTo<LectureTheatre>(_mapperConfig)
                                .ToListAsync();
        }

        public async Task AddLectureTheatreAsync(LectureTheatre lectureTheatre, CancellationToken ct = default)
        {
            _context.Add(lectureTheatre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lecture>> GetLecturesForSubjectAsync(int subjectId, CancellationToken ct = default)
        {
            var lectures = await _context.Subjects
                                        .Where(s => s.SubjectId == subjectId)
                                        .SelectMany(s => s.LectureSchedules.Select(ls => ls.Lecture))
                                          .Distinct()
                                          .Include(l => l.LectureSchedules)
                                          .ThenInclude(ls => ls.LectureTheatre)
                                        .ProjectTo<Lecture>(_mapperConfig)
                                        .ToListAsync();

            return lectures;
        }

        public async Task<List<Subject>> GetEnrolmentsForStudentAsync(int studentId, CancellationToken ct = default)
        {
            List<Subject> subjects = await _context.Enrollments
                                                    .Where(e => e.StudentId == studentId)
                                                    .Select(s => s.Subject)
                                                    .ProjectTo<Subject>(_mapperConfig)
                                                    .ToListAsync();
            return subjects;                            
        }

        public async Task<List<Student>> GetStudentsForSubjectAsync(int subjectId, CancellationToken ct = default)
        {
            List<Student> students = await _context.Enrollments
                                                    .Where(e => e.SubjectId == subjectId)
                                                    .Select(s => s.Student)
                                                    .ProjectTo<Student>(_mapperConfig)
                                                    .ToListAsync();
            return students;
        }
    }
}
