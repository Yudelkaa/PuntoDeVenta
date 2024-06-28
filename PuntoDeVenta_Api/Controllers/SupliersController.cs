using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta_Api.Data;
using Shared.Models;

namespace PuntoDeVenta_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupliersController : ControllerBase
    {
        private readonly Context _context;

        public SupliersController(Context context)
        {
            _context = context;
        }

        // GET: api/Supliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suplier>>> GetSupliers()
        {
            return await _context.Supliers.ToListAsync();
        }

        // GET: api/Supliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suplier>> GetSuplier(int id)
        {
            var suplier = await _context.Supliers.FindAsync(id);

            if (suplier == null)
            {
                return NotFound();
            }

            return suplier;
        }

        // PUT: api/Supliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuplier(int id, Suplier suplier)
        {
            if (id != suplier.SuplierId)
            {
                return BadRequest();
            }

            _context.Entry(suplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuplierExists(id))
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

        // POST: api/Supliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suplier>> PostSuplier(Suplier suplier)
        {
            _context.Supliers.Add(suplier);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuplierExists(suplier.SuplierId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuplier", new { id = suplier.SuplierId }, suplier);
        }

        // DELETE: api/Supliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuplier(int id)
        {
            var suplier = await _context.Supliers.FindAsync(id);
            if (suplier == null)
            {
                return NotFound();
            }

            _context.Supliers.Remove(suplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuplierExists(int id)
        {
            return _context.Supliers.Any(e => e.SuplierId == id);
        }
    }
}
