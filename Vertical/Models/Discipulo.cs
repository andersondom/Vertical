using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Vertical.Models;

[Table("Discipulos")]
public partial class Discipulo
{
    public int Id { get; set; }

    [Display(Description = "Nome do discípulo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(100)]
    [MinLength(5)]
    public string Nome { get; set; } = null!;

    public virtual ICollection<DiscipulosInstrumento> DiscipulosInstrumentos { get; set; } = new List<DiscipulosInstrumento>();
}