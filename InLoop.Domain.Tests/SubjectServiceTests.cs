using AutoMapper;
using InLoop.DataLayer;
using InLoop.DataLayer.Profiles;
using InLoop.DataLayer.Repository;
using InLoop.Domain.Repository;
using InLoop.Domain.Services;
using InLoop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Tests
{
    public class SubjectServiceTests
    {
        private InLoopDbContext _context;
        private DbContextOptions<InLoopDbContext> _options;
        private IConfigurationProvider _config;
        private IInLoopTestRepository _repo;

        public SubjectServiceTests()
        {
            _options = MockDbContext.GetContextOptions();
            _context = new InLoopDbContext(_options);

            _config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LectureProfile());
                mc.AddProfile(new LectureTheatreProfile());
                mc.AddProfile(new StudentProfile());
                mc.AddProfile(new SubjectProfile());
            }).CreateMapper().ConfigurationProvider;

            _repo = new InLoopTestRepository(_context, _config);
            MockDbContext.Seed(_options);
        }

        [Test, Order(1)]
        public async Task Reading_Subjects()
        {
            var service = new SubjectService(_repo);
            var result = await service.GetSubjectsAsync();

            Assert.IsInstanceOf<List<Domain.ViewModels.Subject>>(result);
            Assert.AreEqual(result.Count, 5);

            var Subject1 = result.FirstOrDefault(l => l.Name == "Subject1");
            Assert.NotNull(Subject1);
            Assert.AreEqual(Subject1.Id, 1);

            var Subject2 = result.FirstOrDefault(l => l.Name == "Subject2");
            Assert.NotNull(Subject2);
            Assert.AreEqual(Subject2.Id, 2);

            var Subject3 = result.FirstOrDefault(l => l.Name == "Subject3");
            Assert.NotNull(Subject3);
            Assert.AreEqual(Subject3.Id, 3);

            var Subject4 = result.FirstOrDefault(l => l.Name == "Subject4");
            Assert.NotNull(Subject4);
            Assert.AreEqual(Subject4.Id, 4);

            var Subject5 = result.FirstOrDefault(l => l.Name == "Subject5");
            Assert.NotNull(Subject5);
            Assert.AreEqual(Subject5.Id, 5);
        }

        [Test, Order(2)]
        public async Task AddSubjectAsync()
        {
            Subject subject = new Subject()
            {
                Id = 6,
                Name = "Subject6"
            };

            var service = new SubjectService(_repo);
            await service.AddSubjectAsync(subject);

            var result = await service.GetSubjectsAsync();
            Assert.IsInstanceOf<List<Subject>>(result);
            Assert.AreEqual(result.Count, 6);

            var Student6 = result.FirstOrDefault(l => l.Name == "Subject6");
            Assert.NotNull(Student6);
            Assert.AreEqual(Student6.Id, 6);
        }

        [Test]
        public async Task Reading_Lecture_Scheduled_For_A_Subject()
        {
            var subjectId = 1;
            var service = new SubjectService(_repo);
            var result = await service.GetLecturesForSubjectAsync(subjectId);
            Assert.IsInstanceOf<List<Domain.ViewModels.Lecture>>(result);
            Assert.AreEqual(result.Count, 2);

            var Subject1_Lecture1 = result.FirstOrDefault(l => l.Id == 11);
            Assert.NotNull(Subject1_Lecture1);
            Assert.AreEqual(Subject1_Lecture1.Name, "Subject1_Lecture1");
            Assert.AreEqual(Subject1_Lecture1.LectureTheatre.Count, 1);
            Assert.AreEqual(Subject1_Lecture1.LectureTheatre[0].Id, 1);
            Assert.AreEqual(Subject1_Lecture1.LectureTheatre[0].Name, "LectureTheatre1");

            var Subject1_Lecture2 = result.FirstOrDefault(l => l.Id == 12);
            Assert.NotNull(Subject1_Lecture2);
            Assert.AreEqual(Subject1_Lecture2.Name, "Subject1_Lecture2");
            Assert.AreEqual(Subject1_Lecture2.LectureTheatre.Count, 1);
            Assert.AreEqual(Subject1_Lecture2.LectureTheatre[0].Id, 2);
            Assert.AreEqual(Subject1_Lecture2.LectureTheatre[0].Name, "LectureTheatre2");
        }

        [Test]
        public async Task Reading_Students_For_A_Subject()
        {
            var subjectId = 3;
            var service = new SubjectService(_repo);
            var result = await service.GetStudentsForSubjectAsync(subjectId);

            Assert.IsInstanceOf<List<Domain.ViewModels.Student>>(result);
            Assert.AreEqual(result.Count, 2);

            var Student1 = result.FirstOrDefault(l => l.Id == 1);
            Assert.NotNull(Student1);
            Assert.AreEqual(Student1.Name, "Student1");

            var Student2 = result.FirstOrDefault(l => l.Id == 2);
            Assert.NotNull(Student2);
            Assert.AreEqual(Student2.Name, "Student2");
        }
    }
}
