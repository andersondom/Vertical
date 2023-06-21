using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Vertical.Models;

[Table("Discipulos_Instrumentos")]
public class Discipulos_Instrumentos
{
    public int Id { get; set; }
    
    [ForeignKey("Discipulos")]
    public int IdDiscipulo { get; set; }
    
    [ForeignKey("Instrumentos")]
    public int IdInstrumento { get; set; }
}