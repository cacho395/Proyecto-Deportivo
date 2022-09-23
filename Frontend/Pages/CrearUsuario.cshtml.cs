using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class CrearUsuarioModel : PageModel
    {
        private readonly IRLogin _repoLog;

        [BindProperty]
        public Login Login {get;set;}

        public CrearUsuarioModel(IRLogin repoLog)
        {
            this._repoLog= repoLog;
        }
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoLog.CrearLogin(Login);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El usuario: " + Login.Usuario + "ya se encuentra registrado";
                return Page();
            }
        }
    }
}
