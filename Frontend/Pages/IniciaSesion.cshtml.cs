using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class IniciaSesionModel : PageModel
    {
        private readonly IRLogin _repoLog;

        [BindProperty]
        public Login Login {get;set;}

        public IniciaSesionModel(IRLogin repoLog)
        {
            this._repoLog= repoLog;
        }
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoLog.Validar(Login);
            if(funciono)
            {
                return RedirectToPage("/Inicio");
            }
            else
            {
                ViewData["Error"]="Error validando, verifique su usuario y/o password";
                return Page();
            }
        }
    }
}
