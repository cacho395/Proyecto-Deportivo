using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IREscenario _repoScenario;
        private readonly IRUnidadDeportiva _repoUnd;

        [BindProperty] //propiedad vinculada con el form html
        public Escenario Escenario { get; set; }
        public IEnumerable<UnidadDeportiva> UnidadDeportivas {get;set;}

        //Metodos
        //Constructor
        public CreateModel(IREscenario repoEscenario, IRUnidadDeportiva repoUnd)
        {
            this._repoScenario= repoEscenario;
            this._repoUnd= repoUnd;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            UnidadDeportivas=_repoUnd.ListarUnidadDeportivas();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoScenario.CrearEscenario(Escenario);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                UnidadDeportivas=_repoUnd.ListarUnidadDeportivas();
                ViewData["Error"]= "Este Escenario ya se encuentra creado";
                return Page();
            }
        }

    }
}
