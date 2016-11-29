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
    [Route("api/SafeReservations")]
    public class SafeReservationsController : Controller
    {
        private readonly MyDbContext _context;

        public SafeReservationsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/SafeReservations
        [HttpGet]
        public IEnumerable<SafeReservation> GetSafesReservations()
        {
            return _context.SafesReservations;
        }

        // GET: api/SafeReservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSafeReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SafeReservation safeReservation = await _context.SafesReservations.SingleOrDefaultAsync(m => m.Id == id);

            if (safeReservation == null)
            {
                return NotFound();
            }

            return Ok(safeReservation);
        }

        // PUT: api/SafeReservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSafeReservation([FromRoute] int id, [FromBody] SafeReservation safeReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != safeReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(safeReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SafeReservationExists(id))
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

        // POST: api/SafeReservations
        [HttpPost]
        public async Task<IActionResult> PostSafeReservation([FromBody] SafeReservation safeReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SafesReservations.Add(safeReservation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SafeReservationExists(safeReservation.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSafeReservation", new { id = safeReservation.Id }, safeReservation);
        }

        // DELETE: api/SafeReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSafeReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SafeReservation safeReservation = await _context.SafesReservations.SingleOrDefaultAsync(m => m.Id == id);
            if (safeReservation == null)
            {
                return NotFound();
            }

            _context.SafesReservations.Remove(safeReservation);
            await _context.SaveChangesAsync();

            return Ok(safeReservation);
        }

        private bool SafeReservationExists(int id)
        {
            return _context.SafesReservations.Any(e => e.Id == id);
        }
    }
}