using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Models;

namespace Vertical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstrumentosController : ControllerBase
{
    private readonly AppDbContext _context;

    public InstrumentosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Instrumento>>?> GetInstrumentos()
    {
        if (_context.Instrumentos != null) return await _context.Instrumentos.ToListAsync();
        return null;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Instrumento>?> GetInstrumento(int id)
    {
        if (_context.Instrumentos != null)
        {
            var instrumento = await _context.Instrumentos.FindAsync(id);

            if (instrumento == null)
            {
                return NotFound();
            }

            return instrumento;
        }

        return null;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutInstrumentos(int id, Instrumento instrumento)
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
        catch (Exception ex)
        {
            if (!InstrumentosExists(id))
            {
                return NotFound();
            }
            else
            {
                throw new Exception(ex.Message);
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Instrumento>> PostInstrumentos(Instrumento instrumento)
    {
        _context.Instrumentos?.Add(instrumento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInstrumento", new { id = instrumento.Id }, instrumento);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInstrumento(int id)
    {
        if (_context.Instrumentos != null)
        {
            var instrumento = await _context.Instrumentos.FindAsync(id);
        
            if (_context.Instrumentos != null)
            {
                if (instrumento == null)
                {
                    return NotFound();
                }
            }

            if (_context.Instrumentos != null)
                if (instrumento != null)
                    _context.Instrumentos.Remove(instrumento);
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InstrumentosExists(int id)
    {
        return _context.Instrumentos != null && _context.Instrumentos.Any(e => e.Id == id);
    }
}