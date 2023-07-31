using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatGPT.Pages.Inicial;

public class IndexModel : PageModel
{
    [BindProperty]
    public IndexViewModel Instrumentista { get; set; } = null!;

    public void OnGet()
    {
        Instrumentista = new IndexViewModel();
    }

    public IActionResult OnPostCadastrar()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Aqui você pode processar o cadastro do instrumentista, salvá-lo no banco de dados, enviar um e-mail, etc.
        // Exemplo de código para processar o cadastro:
        // dbContext.Instrumentistas.Add(Instrumentista);
        // dbContext.SaveChanges();

        return RedirectToPage("CadastroSucesso");
    }
}