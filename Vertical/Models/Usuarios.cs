using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("Usuarios")]
public class Usuarios
{
    [Key] 
    public int Id { get; set; }
    
    [MaxLength(100)]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Description = "Login do usuário")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        "Números e caracteres especiais não são permitidos no nome.")]
    public string? Login { get; set; }
    
    [MaxLength(100)]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Description = "Nome do usuário")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        "Números e caracteres especiais não são permitidos no nome.")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [StringLength(10,MinimumLength=4)]
    [Display(Name = "Senha do Usuário")]
    public string? Senha { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Description = "Data de Registro")]
    [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
    public DateTime DataRegistro { get; set; }

    public int IdGrupo { get; set; }
    
    public Grupos? Grupos { get; set; }
}