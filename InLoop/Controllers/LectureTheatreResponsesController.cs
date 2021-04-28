using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InLoop.Data;
using InLoop.ViewModels;

namespace InLoop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureTheatreResponsesController : ControllerBase
    {
        private readonly InLoopContext _context;

        public LectureTheatreResponsesController(InLoopContext context)
        {
            _context = context;
        }

        // GET: api/LectureTheatreResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LectureTheatreResponse>>> GetLectureTheatreResponse()
        {
            return await _context.LectureTheatreResponse.ToListAsync();
        }

        // GET: api/LectureTheatreResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LectureTheatreResponse>> GetLectureTheatreResponse(int id)
        {
            var lectureTheatreResponse = await _context.LectureTheatreResponse.FindAsync(id);

            if (lectureTheatreResponse == null)
            {
                return NotFound();
            }

            return lectureTheatreResponse;
        }

        // PUT: api/LectureTheatreResponses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLectureTheatreResponse(int id, LectureTheatreResponse lectureTheatreResponse)
        {
            if (id != lectureTheatreResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(lectureTheatreResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureTheatreResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LectureTheatreResponses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LectureTheatreResponse>> PostLectureTheatreResponse(LectureTheatreResponse lectureTheatreResponse)
        {
            _context.LectureTheatreResponse.Add(lectureTheatreResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLectureTheatreResponse", new { id = lectureTheatreResponse.Id }, lectureTheatreResponse);
        }

        // DELETE: api/LectureTheatreResponses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LectureTheatreResponse>> DeleteLectureTheatreResponse(int id)
        {
            var lectureTheatreResponse = await _context.LectureTheatreResponse.FindAsync(id);
            if (lectureTheatreResponse == null)
            {
                return NotFound();
            }

            _context.LectureTheatreResponse.Remove(lectureTheatreResponse);
            await _context.SaveChangesAsync();

            return lectureTheatreResponse;
        }

        private bool LectureTheatreResponseExists(int id)
        {
            return _context.LectureTheatreResponse.Any(e => e.Id == id);
        }
    }
}
