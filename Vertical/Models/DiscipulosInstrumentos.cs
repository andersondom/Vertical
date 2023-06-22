using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("DiscipulosInstrumentos")]
public class DiscipulosInstrumentos
{
    public int Id { get; set; }

    [ForeignKey("Discipulos")] public int IdDiscipulo { get; set; }

    [ForeignKey("Instrumentos")] public int IdInstrumento { get; set; }
}