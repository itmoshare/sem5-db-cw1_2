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
    [Route("api/Positions")]
    public class PositionsController : Controller
    {
        private readonly MyDbContext _context;

        public PositionsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Positions
        [HttpGet]
        public IEnumerable<Position> GetPositions()
        {
            return _context.Positions;
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Position position = await _context.Positions.SingleOrDefaultAsync(m => m.Id == id);

            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

        // PUT: api/Positions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition([FromRoute] int id, [FromBody] Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != position.Id)
            {
                return BadRequest();
            }

            _context.Entry(position).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
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

        // POST: api/Positions
        [HttpPost]
        public async Task<IActionResult> PostPosition([FromBody] Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Positions.Add(position);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PositionExists(position.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPosition", new { id = position.Id }, position);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Position position = await _context.Positions.SingleOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();

            return Ok(position);
        }

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}