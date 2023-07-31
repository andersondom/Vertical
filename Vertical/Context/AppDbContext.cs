using Microsoft.EntityFrameworkCore;
using Vertical.Models;

namespace Vertical.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Discipulo>? Discipulos { get; set; }

    public virtual DbSet<DiscipulosInstrumento>? DiscipulosInstrumentos { get; set; }

    public virtual DbSet<Grupo>? Grupos { get; set; }

    public virtual DbSet<Instrumento>? Instrumentos { get; set; }

    public virtual DbSet<Usuario>? Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=domingos\\SQLEXPRESS;Database=vertical;User Id=sa;Password=anderhand;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discipulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DiscipulosPK");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DiscipulosInstrumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DiscipulosInstrumentosPk");

            entity.HasOne(d => d.Discipulo).WithMany(p => p.DiscipulosInstrumentos)
                .HasForeignKey(d => d.IdDiscipulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DiscipulosInstrumentosDiscipulosFK");

            entity.HasOne(d => d.Instrumento).WithMany(p => p.DiscipulosInstrumentos)
                .HasForeignKey(d => d.IdInstrumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DiscipulosInstrumentosInstrumentosFK");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("GruposPK");

            entity.Property(e => e.DataRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Instrumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("InstrumentosPK");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UsuariosPK");

            entity.Property(e => e.DataRegistro).HasColumnType("datetime");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Grupo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UsuariosGruposFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}