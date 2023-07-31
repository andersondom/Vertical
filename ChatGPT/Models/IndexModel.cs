using System.ComponentModel.DataAnnotations;

namespace ChatGPT;

public class IndexModel
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [Display(Description = "Nome do Instrumentista")]
    public string Nome { get; set; }

    [Display(Description = "Email do Instrumentista")]
    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
    public string Email { get; set; }

    [Display(Description = "Telefone do Instrumentista")]
    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public string Telefone { get; set; }

    [Display(Description = "Instrumento do Instrumentista")]
    [Required(ErrorMessage = "O campo Instrumento é obrigatório.")]
    public string Instrumento { get; set; }

    [Display(Description = "Experiência do Instrumentista")]
    public string Experiencia { get; set; }
}