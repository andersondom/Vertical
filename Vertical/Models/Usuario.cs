using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("Usuarios")]
public partial class Usuario
{
    public int Id { get; set; }

    [Display(Description = "Login do usuário")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(100)]
    [MinLength(5)]
    public string Login { get; set; } = null!;

    [Display(Description = "Nome do usuário")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(100)]
    [MinLength(5)]
    public string Nome { get; set; } = null!;

    [Display(Description = "Senha do usuário")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [MaxLength(10)]
    [MinLength(5)]
    public string Senha { get; set; } = null!;

    [Display(Description = "Data de registro do usuário")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataRegistro { get; set; }
    
    public int IdGrupo { get; set; }

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;
}