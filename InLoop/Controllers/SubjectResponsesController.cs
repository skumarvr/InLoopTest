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
    public class SubjectResponsesController : ControllerBase
    {
        private readonly InLoopContext _context;

        public SubjectResponsesController(InLoopContext context)
        {
            _context = context;
        }

        // GET: api/SubjectResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponse>>> GetSubjectResponse()
        {
            return await _context.SubjectResponse.ToListAsync();
        }

        // GET: api/SubjectResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectResponse>> GetSubjectResponse(int id)
        {
            var subjectResponse = await _context.SubjectResponse.FindAsync(id);

            if (subjectResponse == null)
            {
                return NotFound();
            }

            return subjectResponse;
        }

        // PUT: api/SubjectResponses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectResponse(int id, SubjectResponse subjectResponse)
        {
            if (id != subjectResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectResponseExists(id))
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

        // POST: api/SubjectResponses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubjectResponse>> PostSubjectResponse(SubjectResponse subjectResponse)
        {
            _context.SubjectResponse.Add(subjectResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectResponse", new { id = subjectResponse.Id }, subjectResponse);
        }

        // DELETE: api/SubjectResponses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubjectResponse>> DeleteSubjectResponse(int id)
        {
            var subjectResponse = await _context.SubjectResponse.FindAsync(id);
            if (subjectResponse == null)
            {
                return NotFound();
            }

            _context.SubjectResponse.Remove(subjectResponse);
            await _context.SaveChangesAsync();

            return subjectResponse;
        }

        private bool SubjectResponseExists(int id)
        {
            return _context.SubjectResponse.Any(e => e.Id == id);
        }
    }
}
