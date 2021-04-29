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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _service.GetStudentsAsync();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _service.AddStudentAsync(student);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // GET: api/Students/{id}/enrollmentss
        [HttpGet]
        [Route("{id}/Enrollments")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetEnrollmentsForStudent(int id)
        {
            return await _service.GetEnrolmentsForStudentAsync(id);
        }
    }
}
