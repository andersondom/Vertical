using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("Instrumentos")]
public partial class Instrumento
{
    public int Id { get; set; }

    [Display(Description = "Nome do instrumento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(100)]
    [MinLength(5)]
    public string Nome { get; set; } = null!;

    public virtual ICollection<DiscipulosInstrumento> DiscipulosInstrumentos { get; set; } = new List<DiscipulosInstrumento>();
}