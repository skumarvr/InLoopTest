using InLoop.Domain.Repository;
using InLoop.Domain.Services;
using InLoop.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InLoop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(IInLoopTestRepository repo)
        {
            _service = new StudentService(repo);
        }

        // GET: api/Students
        /// <summary>
        /// Reading students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _service.GetStudentsAsync();
        }

        // POST: api/Students
        /// <summary>
        /// Creating student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _service.AddStudentAsync(student);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // GET: api/Students/{id}/enrollments
        /// <summary>
        /// Reading enrolments as a collection sub-resource of a student resource, returning the list of enrolments
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/Enrollments")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetEnrollmentsForStudent(int id)
        {
            return await _service.GetEnrolmentsForStudentAsync(id);
        }
    }
}
