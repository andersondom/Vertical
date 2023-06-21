using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("Discipulos")]
public class Discipulos
{
    public int Id { get; set; }


    [MaxLength(100)]
    [Required]
    public string? Nome { get; set; }
}