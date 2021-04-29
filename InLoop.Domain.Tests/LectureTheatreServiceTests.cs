using AutoMapper;
using InLoop.DataLayer;
using InLoop.DataLayer.Profiles;
using InLoop.DataLayer.Repository;
using InLoop.Domain.Repository;
using InLoop.Domain.Services;
using InLoop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLoop.Domain.Tests
{
    public class LectureTheatreServiceTests
    {
        private InLoopDbContext _context;
        private DbContextOptions<InLoopDbContext> _options;
        private IConfigurationProvider _config;
        private IInLoopTestRepository _repo;

        public LectureTheatreServiceTests()
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
        public async Task Reading_Lecture_Theatres()
        {
            var service = new LectureTheatreService(_repo);
            var result = await service.GetLectureTheatresAsync();

            Assert.IsInstanceOf<List<LectureTheatre>>(result);
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

        [Test, Order(2)]
        public async Task AddLectureTheatreAsync()
        {
            LectureTheatre lectureTheatre = new LectureTheatre()
            {
                Id = 6,
                Name = "LectureTheatre6",
                Capacity = 100
            };

            var service = new LectureTheatreService(_repo);
            await service.AddLectureTheatreAsync(lectureTheatre);

            var result = await service.GetLectureTheatresAsync();
            Assert.IsInstanceOf<List<LectureTheatre>>(result);
            Assert.AreEqual(result.Count, 6);

            var LectureTheatre6 = result.FirstOrDefault(l => l.Name == "LectureTheatre6");
            Assert.NotNull(LectureTheatre6);
            Assert.AreEqual(LectureTheatre6.Id, 6);
        }
    }
}