using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Context;
using Vertical.Models;

namespace Vertical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstrumentoController : ControllerBase
{
    private readonly AppDbContext _context;

    public InstrumentoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Instrumento
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Instrumento>>> GetInstrumentos()
    {
        if (_context.Instrumentos == null)
        {
            return NotFound();
        }
        return await _context.Instrumentos.ToListAsync();
    }

    // GET: api/Instrumento/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Instrumento>> GetInstrumento(int id)
    {
        if (_context.Instrumentos == null)
        {
            return NotFound();
        }
        var instrumento = await _context.Instrumentos.FindAsync(id);

        if (instrumento == null)
        {
            return NotFound();
        }

        return instrumento;
    }

    // PUT: api/Instrumento/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInstrumento(int id, Instrumento instrumento)
    {
        if (id != instrumento.Id)
        {
            return BadRequest();
        }

        _context.Entry(instrumento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InstrumentoExists(id))
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

    // POST: api/Instrumento
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Instrumento>> PostInstrumento(Instrumento instrumento)
    {
        if (_context.Instrumentos == null)
        {
            return Problem("Entity set 'AppDbContext.Instrumentos'  is null.");
        }
        _context.Instrumentos.Add(instrumento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInstrumento", new { id = instrumento.Id }, instrumento);
    }

    // DELETE: api/Instrumento/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInstrumento(int id)
    {
        if (_context.Instrumentos == null)
        {
            return NotFound();
        }
        var instrumento = await _context.Instrumentos.FindAsync(id);
        if (instrumento == null)
        {
            return NotFound();
        }

        _context.Instrumentos.Remove(instrumento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InstrumentoExists(int id)
    {
        return (_context.Instrumentos?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}