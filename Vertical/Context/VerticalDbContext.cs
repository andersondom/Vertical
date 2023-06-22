using Microsoft.EntityFrameworkCore;
using Vertical.Models;

namespace Vertical.Context;

public class VerticalDbContext : DbContext
{
    public VerticalDbContext(DbContextOptions<VerticalDbContext> options) : base(options)
    {
    }

    public DbSet<Discipulos>? Discipulos { get; set; }
    public DbSet<Instrumentos>? Instrumentos { get; set; }
    public DbSet<DiscipulosInstrumentos>? DiscipulosInstrumentos { get; set; }
}