using System.ComponentModel.DataAnnotations;

namespace ChatGPT;

public class IndexViewModel
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo Instrumento é obrigatório.")]
    public string Instrumento { get; set; }

    public string Experiencia { get; set; }
}