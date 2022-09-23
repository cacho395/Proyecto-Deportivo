using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages;

public class InicioModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public InicioModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        //return RedirectToPage("./IniciaSesion");
    }
}

