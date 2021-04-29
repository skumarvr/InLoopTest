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
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectService _service;

        public SubjectsController(IInLoopTestRepository repo)
        {
            _service = new SubjectService(repo);
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _service.GetSubjectsAsync();
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            await _service.AddSubjectAsync(subject);

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // POST: api/Subjects/{id}/Lectures
        [HttpGet]
        [Route("{id}/Lectures")]
        public async Task<List<Lecture>> GetLecturesForSubject(int id)
        {
            return await _service.GetLecturesForSubjectAsync(id);
        }

        // POST: api/Subjects/{id}/Students
        [HttpGet]
        [Route("{id}/Students")]
        public async Task<List<Student>> GetStudentsForSubject(int id)
        {
            return await _service.GetStudentsForSubjectAsync(id);
        }
    }
}
