using AutoMapper;
using InLoop.DataLayer.Profiles;
using InLoop.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLoop.DataLayer.Tests
{
    public class InLoopTestRepositoryTests
    {
        private DbContextOptions<InLoopDbContext> ContextOptions;
        private IConfigurationProvider MapperConfiguration;
        private InLoopDbContext DbContext;

        [OneTimeSetUp]
        public void Init()
        {
            ContextOptions = MockDbContext.GetContextOptions();
            MockDbContext.Seed(ContextOptions);
            MapperConfiguration = new MapperConfiguration(mc => {
                mc.AddProfile(new LectureProfile());
                mc.AddProfile(new LectureTheatreProfile());
                mc.AddProfile(new StudentProfile());
                mc.AddProfile(new SubjectProfile());
            }).CreateMapper().ConfigurationProvider;
            DbContext = new InLoopDbContext(ContextOptions);
        }

        [Test]
        public async Task Reading_Students()
        {
            var repo = new InLoopTestRepository(DbContext, MapperConfiguration);
            var result = await repo.GetStudentsAsync();

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

        [Test]
        public async Task Reading_Subjects()
        {
            var repo = new InLoopTestRepository(DbContext, MapperConfiguration);
            var result = await repo.GetSubjectsAsync();

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

        [Test]
        public async Task Reading_Lecture_Theatres()
        {
            var repo = new InLoopTestRepository(DbContext, MapperConfiguration);
            var result = await repo.GetLectureTheatresAsync();

            Assert.IsInstanceOf<List<Domain.ViewModels.LectureTheatre>>(result);
            Assert.AreEqual(result.Count, 5);

            var LectureTheatre1 = result.FirstOrDefault(l => l.Name == "LectureTheatre1");
            Assert.NotNull(LectureTheatre1);
            Assert.AreEqual(LectureTheatre1.Id, 1);

            var LectureTheatre2 = result.FirstOrDefault(l => l.Name == "LectureTheatre2");
            Assert.NotNull(LectureTheatre2);
            Assert.AreEqual(LectureTheatre2.Id, 2);

            var LectureTheatre3 = result.FirstOrDefault(l => l.Name == "LectureTheatre3");
            Assert.NotNull(LectureTheatre3);
            Assert.AreEqual(LectureTheatre3.Id, 3);

            var LectureTheatre4 = result.FirstOrDefault(l => l.Name == "LectureTheatre4");
            Assert.NotNull(LectureTheatre4);
            Assert.AreEqual(LectureTheatre4.Id, 4);

            var LectureTheatre5 = result.FirstOrDefault(l => l.Name == "LectureTheatre5");
            Assert.NotNull(LectureTheatre5);
            Assert.AreEqual(LectureTheatre5.Id, 5);
        }

        [Test]
        public async Task Reading_Lecture_Scheduled_For_A_Subject()
        {
            var repo = new InLoopTestRepository(DbContext, MapperConfiguration);
            var subjectId = 1;
            var result = await repo.GetLecturesForSubjectAsync(subjectId);

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
            Assert.AreEqual(Subject1_Lecture2.LectureTheatre.Count,1);
            Assert.AreEqual(Subject1_Lecture2.LectureTheatre[0].Id, 2);
            Assert.AreEqual(Subject1_Lecture2.LectureTheatre[0].Name, "LectureTheatre2");
        }

        [Test]
        public async Task Reading_Enrollments_For_A_Student()
        {
            var repo = new InLoopTestRepository(DbContext, MapperConfiguration);
            var studentId = 1;
            var result = await repo.GetEnrolmentsForStudentAsync(studentId);

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

        [Test]
        public async Task Reading_Students_For_A_Subject()
        {
            var repo = new InLoopTestRepository(DbContext, MapperConfiguration);
            var subjectId = 3;
            var result = await repo.GetStudentsForSubjectAsync(subjectId);

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