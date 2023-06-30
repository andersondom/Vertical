using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vertical.Models;

[Table("Grupos")]
public partial class Grupo
{
    public int Id { get; set; }

    [Display(Description = "Nome do grupo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(100)]
    [MinLength(5)]
    public string Nome { get; set; } = null!;

    [Display(Description = "Data de registro do grupo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataRegistro { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}