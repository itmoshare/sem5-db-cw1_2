using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkManager.Data;
using cw1_2.Model;

namespace cw1_2.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/TrainningClientRelations")]
    public class TrainningClientRelationsController : Controller
    {
        private readonly MyDbContext _context;

        public TrainningClientRelationsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainningClientRelations
        [HttpGet]
        public IEnumerable<TrainningClientRelation> GetTrainningClientRelation()
        {
            return _context.TrainningClientRelation;
        }

        // GET: api/TrainningClientRelations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainningClientRelation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrainningClientRelation trainningClientRelation = await _context.TrainningClientRelation.SingleOrDefaultAsync(m => m.Id == id);

            if (trainningClientRelation == null)
            {
                return NotFound();
            }

            return Ok(trainningClientRelation);
        }

        // PUT: api/TrainningClientRelations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainningClientRelation([FromRoute] int id, [FromBody] TrainningClientRelation trainningClientRelation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainningClientRelation.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainningClientRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainningClientRelationExists(id))
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

        // POST: api/TrainningClientRelations
        [HttpPost]
        public async Task<IActionResult> PostTrainningClientRelation([FromBody] TrainningClientRelation trainningClientRelation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainningClientRelation.Add(trainningClientRelation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainningClientRelationExists(trainningClientRelation.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainningClientRelation", new { id = trainningClientRelation.Id }, trainningClientRelation);
        }

        // DELETE: api/TrainningClientRelations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainningClientRelation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrainningClientRelation trainningClientRelation = await _context.TrainningClientRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (trainningClientRelation == null)
            {
                return NotFound();
            }

            _context.TrainningClientRelation.Remove(trainningClientRelation);
            await _context.SaveChangesAsync();

            return Ok(trainningClientRelation);
        }

        private bool TrainningClientRelationExists(int id)
        {
            return _context.TrainningClientRelation.Any(e => e.Id == id);
        }
    }
}