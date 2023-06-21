using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("Instrumentos")]
public class Instrumentos
{
    public int Id { get; set; }
    
    
    [MaxLength(100)]
    [Required]
    public string? Nome { get; set; }
}