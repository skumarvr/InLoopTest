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
    public class StudentServiceTests
    {
        private InLoopDbContext _context;
        private DbContextOptions<InLoopDbContext> _options;
        private IConfigurationProvider _config;
        private IInLoopTestRepository _repo;

        public StudentServiceTests()
        {
            _options = MockDbContext.GetContextOptions();
            _context = new InLoopDbContext(_options);

            _config = new MapperConfiguration(mc => {
                mc.AddProfile(new LectureProfile());
                mc.AddProfile(new LectureTheatreProfile());
                mc.AddProfile(new StudentProfile());
                mc.AddProfile(new SubjectProfile());
            }).CreateMapper().ConfigurationProvider;

            _repo = new InLoopTestRepository(_context, _config);
            MockDbContext.Seed(_options);
        }

        [Test, Order(1)]
        public async Task Reading_Students()
        {
            var service = new StudentService(_repo);
            var result = await service.GetStudentsAsync();

            Assert.IsInstanceOf<List<Domain.ViewModels.Student>>(result);
            Assert.AreEqual(result.Count, 5);

            var Student1 = result.FirstOrDefault(l => l.Id == 1);
            Assert.NotNull(Student1);
            Assert.AreEqual(Student1.Name, "Student1");

            var Student2 = result.FirstOrDefault(l => l.Id == 2);
            Assert.NotNull(Student2);
            Assert.AreEqual(Student2.Name, "Student2");

            var Student3 = result.FirstOrDefault(l => l.Id == 3);
            Assert.NotNull(Student3);
            Assert.AreEqual(Student3.Name, "Student3");

            var Student4 = result.FirstOrDefault(l => l.Id == 4);
            Assert.NotNull(Student4);
            Assert.AreEqual(Student4.Name, "Student4");

            var Student5 = result.FirstOrDefault(l => l.Id == 5);
            Assert.NotNull(Student5);
            Assert.AreEqual(Student5.Name, "Student5");
        }

        [Test, Order(2)]
        public async Task AddStudentAsync()
        {
            Student student = new Student()
            {
                Id = 6,
                Name = "Student6"
            };

            var service = new StudentService(_repo);
            await service.AddStudentAsync(student);

            var result = await service.GetStudentsAsync();
            Assert.IsInstanceOf<List<Student>>(result);
            Assert.AreEqual(result.Count, 6);

            var Student6 = result.FirstOrDefault(l => l.Name == "Student6");
            Assert.NotNull(Student6);
            Assert.AreEqual(Student6.Id, 6);
        }

        [Test]
        public async Task Reading_Enrollments_For_A_Student()
        {
            var studentId = 1;
            var service = new StudentService(_repo);
            var result = await service.GetEnrolmentsForStudentAsync(studentId);

            Assert.IsInstanceOf<List<Domain.ViewModels.Subject>>(result);
            Assert.AreEqual(result.Count, 3);

            var Subject1 = result.FirstOrDefault(l => l.Id == 1);
            Assert.NotNull(Subject1);
            Assert.AreEqual(Subject1.Name, "Subject1");

            var Subject2 = result.FirstOrDefault(l => l.Id == 2);
            Assert.NotNull(Subject2);
            Assert.AreEqual(Subject1.Name, "Subject1");

            var Subject3 = result.FirstOrDefault(l => l.Id == 3);
            Assert.NotNull(Subject3);
            Assert.AreEqual(Subject1.Name, "Subject1");
        }
    }
}
