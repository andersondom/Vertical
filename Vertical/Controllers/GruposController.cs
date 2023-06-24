using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Context;
using Vertical.Models;

namespace Vertical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GruposController : ControllerBase
{
    private readonly VerticalDbContext _context;

    public GruposController(VerticalDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grupos>>?> GetGrupos()
    {
        if (_context.Grupos != null) return await _context.Grupos.ToListAsync();
        return null;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Grupos>?> GetGrupo(int id)
    {
        if (_context.Grupos != null)
        {
            var client = await _context.Grupos.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        return null;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGrupos(int id, Grupos grupo)
    {
        if (id != grupo.Id)
        {
            return BadRequest();
        }

        _context.Entry(grupo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (!GruposExists(id))
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
    public async Task<ActionResult<Grupos>> PostClient(Grupos grupo)
    {
        if (_context.Grupos != null) _context.Grupos.Add(grupo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGrupos", new { id = grupo.Id }, grupo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrupo(int id)
    {
        if (_context.Grupos != null)
        {
            var grupo = await _context.Grupos.FindAsync(id);
        
            if (_context.Grupos != null)
            {
                if (grupo == null)
                {
                    return NotFound();
                }
            }

            if (_context.Grupos != null)
                if (grupo != null)
                    _context.Grupos.Remove(grupo);
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GruposExists(int id)
    {
        return _context.Grupos != null && _context.Grupos.Any(e => e.Id == id);
    }
}