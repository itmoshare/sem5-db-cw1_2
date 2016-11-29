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
    [Route("api/Safes")]
    public class SafesController : Controller
    {
        private readonly MyDbContext _context;

        public SafesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Safes
        [HttpGet]
        public IEnumerable<Safe> GetSafes()
        {
            return _context.Safes;
        }

        // GET: api/Safes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSafe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Safe safe = await _context.Safes.SingleOrDefaultAsync(m => m.Id == id);

            if (safe == null)
            {
                return NotFound();
            }

            return Ok(safe);
        }

        // PUT: api/Safes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSafe([FromRoute] int id, [FromBody] Safe safe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != safe.Id)
            {
                return BadRequest();
            }

            _context.Entry(safe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SafeExists(id))
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

        // POST: api/Safes
        [HttpPost]
        public async Task<IActionResult> PostSafe([FromBody] Safe safe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Safes.Add(safe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SafeExists(safe.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSafe", new { id = safe.Id }, safe);
        }

        // DELETE: api/Safes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSafe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Safe safe = await _context.Safes.SingleOrDefaultAsync(m => m.Id == id);
            if (safe == null)
            {
                return NotFound();
            }

            _context.Safes.Remove(safe);
            await _context.SaveChangesAsync();

            return Ok(safe);
        }

        private bool SafeExists(int id)
        {
            return _context.Safes.Any(e => e.Id == id);
        }
    }
}