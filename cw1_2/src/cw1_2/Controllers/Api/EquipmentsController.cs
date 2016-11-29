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
    [Route("api/Equipments")]
    public class EquipmentsController : Controller
    {
        private readonly MyDbContext _context;

        public EquipmentsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipments
        [HttpGet]
        public IEnumerable<Equipment> GetEquipments()
        {
            return _context.Equipments;
        }

        // GET: api/Equipments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Equipment equipment = await _context.Equipments.SingleOrDefaultAsync(m => m.Id == id);

            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        // PUT: api/Equipments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment([FromRoute] int id, [FromBody] Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipments
        [HttpPost]
        public async Task<IActionResult> PostEquipment([FromBody] Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Equipments.Add(equipment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentExists(equipment.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }

        // DELETE: api/Equipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Equipment equipment = await _context.Equipments.SingleOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

            return Ok(equipment);
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipments.Any(e => e.Id == id);
        }
    }
}