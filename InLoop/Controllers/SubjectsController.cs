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
        /// <summary>
        /// Reading subjects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _service.GetSubjectsAsync();
        }

        // POST: api/Subjects
        /// <summary>
        /// Creating subject
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            await _service.AddSubjectAsync(subject);

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // POST: api/Subjects/{id}/Lectures
        /// <summary>
        /// Reading lectures on a schedule as sub-resources of a subject, 
        /// where the lecture theatre is identified as a property of the lecture
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/Lectures")]
        public async Task<List<Lecture>> GetLecturesForSubject(int id)
        {
            return await _service.GetLecturesForSubjectAsync(id);
        }

        // POST: api/Subjects/{id}/Students
        /// <summary>
        /// Reading students as a collection sub-resource of a subject, 
        /// returning the list of students enrolled in the subject.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/Students")]
        public async Task<List<Student>> GetStudentsForSubject(int id)
        {
            return await _service.GetStudentsForSubjectAsync(id);
        }
    }
}
