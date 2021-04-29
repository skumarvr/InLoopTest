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
    public class LectureTheatresController : ControllerBase
    {
        private readonly LectureTheatreService _service;

        public LectureTheatresController(IInLoopTestRepository repo)
        {
            _service = new LectureTheatreService(repo);
        }

        // GET: api/LectureTheatres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LectureTheatre>>> GetLectureTheatres()
        {
            return await _service.GetLectureTheatresAsync();
        }

        // POST: api/LectureTheatre
        [HttpPost]
        public async Task<ActionResult<LectureTheatre>> PostLectureTheatreResponse(LectureTheatre lectureTheatre)
        {
            await _service.AddLectureTheatreAsync(lectureTheatre);
            return CreatedAtAction("GetLectureTheatres", new { id = lectureTheatre.Id }, lectureTheatre);
        }
    }
}
