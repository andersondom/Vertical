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
    public async Task<ActionResult<IEnumerable<Grupos>>> GetGrupos()
    {
        return await _context.Grupos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Grupos>> GetGrupo(int id)
    {
        var client = await _context.Grupos.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
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
        _context.Grupos.Add(grupo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGrupos", new { id = grupo.Id }, grupo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrupo(int id)
    {
        var grupo = await _context.Grupos.FindAsync(id);
        
        if (_context.Grupos != null)
        {
            if (grupo == null)
            {
                return NotFound();
            }
        }

        _context.Grupos.Remove(grupo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GruposExists(int id)
    {
        return _context.Grupos.Any(e => e.Id == id);
    }
}