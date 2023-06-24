using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertical.Context;
using Vertical.Models;

namespace Vertical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly VerticalDbContext _context;

    public UsuariosController(VerticalDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuarios>>?> GetUsuarios()
    {
        if (_context.Usuarios != null) return await _context.Usuarios.ToListAsync();
        return null;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuarios>?> GetUsuario(int id)
    {
        if (_context.Usuarios != null)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
        
            return usuario;
        }

        return null;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuarios usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }

        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (!UsuarioExists(id))
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
    public async Task<ActionResult<Usuarios>> PostUsuario(Usuarios usuario)
    {
        if (_context.Usuarios != null) _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuarios", new { id = usuario.Id }, usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        if (_context.Usuarios != null)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios != null && _context.Usuarios.Any(e => e.Id == id);
    }
}