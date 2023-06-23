using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertical.Models;

[Table("Grupos")]
public class Grupos
{
    [Key] 
    public int Id { get; set; }
    
    [MaxLength(100)]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Description = "Nome do Grupo")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        "Números e caracteres especiais não são permitidos no nome.")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Description = "Data de Registro")]
    [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
    public DateTime DataRegistro { get; set; }

    public ICollection<Usuarios> Usuarios { get; }
}