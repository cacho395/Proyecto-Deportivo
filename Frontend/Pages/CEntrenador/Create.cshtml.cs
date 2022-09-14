using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IREntrenador _repoEntrenador;

        [BindProperty] //propiedad vinculada con el form html
        public Entrenador Entrenador { get; set; }

        //Metodos
        //Constructor
        public CreateModel(IREntrenador repoEntrenador)
        {
            this._repoEntrenador= repoEntrenador;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            bool funciono= _repoEntrenador.CrearEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Este Entrenador ya se encuentra creado";
                return Page();
            }
        }
    }
}
