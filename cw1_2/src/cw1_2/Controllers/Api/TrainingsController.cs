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
    [Route("api/Trainings")]
    public class TrainingsController : Controller
    {
        private readonly MyDbContext _context;

        public TrainingsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public IEnumerable<Training> GetTrainings()
        {
            return _context.Trainings;
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraining([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Training training = await _context.Trainings.SingleOrDefaultAsync(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        // PUT: api/Trainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining([FromRoute] int id, [FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != training.Id)
            {
                return BadRequest();
            }

            _context.Entry(training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // POST: api/Trainings
        [HttpPost]
        public async Task<IActionResult> PostTraining([FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trainings.Add(training);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingExists(training.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTraining", new { id = training.Id }, training);
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Training training = await _context.Trainings.SingleOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();

            return Ok(training);
        }

        private bool TrainingExists(int id)
        {
            return _context.Trainings.Any(e => e.Id == id);
        }
    }
}