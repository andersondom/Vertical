using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Context;
using Vertical.Models;

namespace Vertical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstrumentosController : ControllerBase
{
    private readonly VerticalDbContext _context;

    public InstrumentosController(VerticalDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Instrumentos>>> GetInstrumentos()
    {
        return await _context.Instrumentos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Instrumentos>> GetInstrumento(int id)
    {
        var instrumento = await _context.Instrumentos.FindAsync(id);

        if (instrumento == null)
        {
            return NotFound();
        }

        return instrumento;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutInstrumentos(int id, Instrumentos instrumento)
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
    public async Task<ActionResult<Instrumentos>> PostInstrumentos(Instrumentos instrumento)
    {
        _context.Instrumentos.Add(instrumento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInstrumento", new { id = instrumento.Id }, instrumento);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInstrumento(int id)
    {
        var instrumento = await _context.Instrumentos.FindAsync(id);
        
        if (_context.Instrumentos != null)
        {
            if (instrumento == null)
            {
                return NotFound();
            }
        }

        _context.Instrumentos.Remove(instrumento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InstrumentosExists(int id)
    {
        return _context.Instrumentos.Any(e => e.Id == id);
    }
}