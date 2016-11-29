using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkManager.Data;
using cw1_2.Models;

namespace cw1_2.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/TrainingPrograms")]
    public class TrainingProgramsController : Controller
    {
        private readonly MyDbContext _context;

        public TrainingProgramsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingPrograms
        [HttpGet]
        public IEnumerable<TrainingProgram> GetTrainingPrograms()
        {
            return _context.TrainingPrograms;
        }

        // GET: api/TrainingPrograms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrainingProgram trainingProgram = await _context.TrainingPrograms.SingleOrDefaultAsync(m => m.Id == id);

            if (trainingProgram == null)
            {
                return NotFound();
            }

            return Ok(trainingProgram);
        }

        // PUT: api/TrainingPrograms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingProgram([FromRoute] int id, [FromBody] TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingProgramExists(id))
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

        // POST: api/TrainingPrograms
        [HttpPost]
        public async Task<IActionResult> PostTrainingProgram([FromBody] TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingPrograms.Add(trainingProgram);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingProgramExists(trainingProgram.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainingProgram", new { id = trainingProgram.Id }, trainingProgram);
        }

        // DELETE: api/TrainingPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrainingProgram trainingProgram = await _context.TrainingPrograms.SingleOrDefaultAsync(m => m.Id == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }

            _context.TrainingPrograms.Remove(trainingProgram);
            await _context.SaveChangesAsync();

            return Ok(trainingProgram);
        }

        private bool TrainingProgramExists(int id)
        {
            return _context.TrainingPrograms.Any(e => e.Id == id);
        }
    }
}