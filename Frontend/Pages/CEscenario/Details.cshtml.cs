using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class DetailsModel : PageModel
    {
        private readonly IREscenario _repoEsc;
        private readonly IRUnidadDeportiva _repoUnD;

        [BindProperty]
        public Escenario Escenario {get;set;}
        public UnidadDeportiva UnidadDeportiva {get;set;}

        public DetailsModel(IREscenario repoEsc, IRUnidadDeportiva repoUnD)
        {
            this._repoEsc= repoEsc;
            this._repoUnD= repoUnD;
        }
        public ActionResult OnGet(int id)
        {
            Escenario=_repoEsc.BuscarEscenario(id);
            UnidadDeportiva=_repoUnD.BuscarUnidadDeportiva(Escenario.UnidadDeportivaId);
            return Page(); 

            if(Escenario!=null && UnidadDeportiva!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Escenario no encontrado";
                return Page();
            }
        
        }
    }
}
