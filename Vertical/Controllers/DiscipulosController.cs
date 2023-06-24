using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Context;
using Vertical.Models;

namespace Vertical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscipulosController : ControllerBase
{
    private readonly VerticalDbContext _context;

    public DiscipulosController(VerticalDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Discipulos>>?> GetDiscipulos()
    {
        if (_context.Discipulos != null) return await _context.Discipulos.ToListAsync();
        return null;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Discipulos>?> GetDiscipulo(int id)
    {
        if (_context.Discipulos != null)
        {
            var discipulo = await _context.Discipulos.FindAsync(id);

            if (discipulo == null)
            {
                return NotFound();
            }

            return discipulo;
        }

        return null;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDiscipulos(int id, Discipulos discipulo)
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
        catch (Exception ex)
        {
            if (!DiscipulosExists(id))
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
    public async Task<ActionResult<Discipulos>> PostDiscipulo(Discipulos discipulo)
    {
        if (_context.Discipulos != null) _context.Discipulos.Add(discipulo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDiscipulo", new { id = discipulo.Id }, discipulo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiscipulo(int id)
    {
        if (_context.Discipulos != null)
        {
            var discipulo = await _context.Discipulos.FindAsync(id);
        
            if (_context.Discipulos != null)
            {
                if (discipulo == null)
                {
                    return NotFound();
                }
            }

            if (_context.Discipulos != null)
                if (discipulo != null)
                    _context.Discipulos.Remove(discipulo);
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DiscipulosExists(int id)
    {
        return _context.Discipulos != null && _context.Discipulos.Any(e => e.Id == id);
    }
}