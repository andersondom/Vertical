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
    public class DiscipuloController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiscipuloController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Disicpulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discipulo>>> GetDiscipulos()
        {
          if (_context.Discipulos == null)
          {
              return NotFound();
          }
          return await _context.Discipulos.ToListAsync();
        }

        // GET: api/Disicpulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discipulo>> GetDiscipulo(int id)
        {
          if (_context.Discipulos == null)
          {
              return NotFound();
          }
          var discipulo = await _context.Discipulos.FindAsync(id);

          if (discipulo == null)
          {
              return NotFound();
          }

          return discipulo;
        }

        // PUT: api/Disicpulo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscipulo(int id, Discipulo discipulo)
        {
            if (id != discipulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(discipulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscipuloExists(id))
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

        // POST: api/Disicpulo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discipulo>> PostDiscipulo(Discipulo discipulo)
        {
          if (_context.Discipulos == null)
          {
              return Problem("Entity set 'AppDbContext.Discipulos'  is null.");
          }
          _context.Discipulos.Add(discipulo);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetDiscipulo", new { id = discipulo.Id }, discipulo);
        }

        // DELETE: api/Disicpulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipulo(int id)
        {
            if (_context.Discipulos == null)
            {
                return NotFound();
            }
            var discipulo = await _context.Discipulos.FindAsync(id);
            if (discipulo == null)
            {
                return NotFound();
            }

            _context.Discipulos.Remove(discipulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscipuloExists(int id)
        {
            return (_context.Discipulos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
