using InLoop.DataLayer;
using InLoop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InLoop.DataLayer.Tests
{
    public class MockDbContext
    {
        public static DbContextOptions<InLoopDbContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<InLoopDbContext>()
                            .UseInMemoryDatabase("TestDatabase")
                            .Options;
        }
        
        public static void Seed(DbContextOptions<InLoopDbContext> ContextOptions)
        {
            using (var context = new InLoopDbContext(ContextOptions))
            {
                if (context.Enrollments.Any()
                    && context.Lectures.Any()
                    && context.LectureSchedules.Any()
                    && context.LectureTheatres.Any()
                    && context.Students.Any()
                    && context.Subjects.Any())
                {
                    return;
                }

                var students = LoadJson<Student>(@".\SampleData\Students.json");
                context.Students.AddRange(students);
                context.SaveChanges();

                var subjects = LoadJson<Subject>(@".\SampleData\Subjects.json");
                context.Subjects.AddRange(subjects);
                context.SaveChanges();

                var lectureTheatres = LoadJson<LectureTheatre>(@".\SampleData\LectureTheatres.json");
                context.LectureTheatres.AddRange(lectureTheatres);
                context.SaveChanges();

                var lectures = LoadJson<Lecture>(@".\SampleData\Lectures.json");
                context.Lectures.AddRange(lectures);
                context.SaveChanges();

                var lectureSchedules = LoadJson<LectureSchedule>(@".\SampleData\LectureSchedules.json");
                context.LectureSchedules.AddRange(lectureSchedules);
                context.SaveChanges();

                var enrollments = LoadJson<Enrollment>(@".\SampleData\Enrollments.json");
                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }

        private static List<T> LoadJson<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }
    }
}
