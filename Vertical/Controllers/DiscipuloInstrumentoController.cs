using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Context;
using Vertical.Models;

namespace Vertical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscipuloInstrumentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiscipuloInstrumentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DiscipuloInstrumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscipulosInstrumento>>> GetDiscipulosInstrumentos()
        {
            return await _context.DiscipulosInstrumentos.ToListAsync();
        }

        // GET: api/DiscipuloInstrumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscipulosInstrumento>> GetDiscipulosInstrumento(int id)
        {
            var discipulosInstrumento = await _context.DiscipulosInstrumentos.FindAsync(id);

            if (discipulosInstrumento == null)
            {
                return NotFound();
            }

            return discipulosInstrumento;
        }

        // PUT: api/DiscipuloInstrumento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscipulosInstrumento(int id, DiscipulosInstrumento discipulosInstrumento)
        {
            if (id != discipulosInstrumento.Id)
            {
                return BadRequest();
            }

            _context.Entry(discipulosInstrumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscipulosInstrumentoExists(id))
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

        // POST: api/DiscipuloInstrumento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiscipulosInstrumento>> PostDiscipulosInstrumento(DiscipulosInstrumento discipulosInstrumento)
        {
            _context.DiscipulosInstrumentos.Add(discipulosInstrumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscipulosInstrumento", new { id = discipulosInstrumento.Id }, discipulosInstrumento);
        }

        // DELETE: api/DiscipuloInstrumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipulosInstrumento(int id)
        {
            var discipulosInstrumento = await _context.DiscipulosInstrumentos.FindAsync(id);
            if (discipulosInstrumento == null)
            {
                return NotFound();
            }

            _context.DiscipulosInstrumentos.Remove(discipulosInstrumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscipulosInstrumentoExists(int id)
        {
            return _context.DiscipulosInstrumentos.Any(e => e.Id == id);
        }
    }
}
