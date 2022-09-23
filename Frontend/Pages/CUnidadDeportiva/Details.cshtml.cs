using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
    public class DetailsModel : PageModel
    {
        private readonly IRUnidadDeportiva _repoUnD;
        private readonly IRTorneo _repoTorneo;

        [BindProperty]
        public UnidadDeportiva UnidadDeportiva {get;set;}
        public Torneo Torneo {get;set;}

        public DetailsModel(IRUnidadDeportiva repoUnd, IRTorneo repoTor)
        {
            this._repoUnD= repoUnd;
            this._repoTorneo= repoTor;
        }
        public ActionResult OnGet(int id)
        {
            UnidadDeportiva=_repoUnD.BuscarUnidadDeportiva(id);
            Torneo=_repoTorneo.BuscarTorneo(UnidadDeportiva.TorneoId);
            return Page(); 

            if(UnidadDeportiva!=null && Torneo!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Unidad Deportiva no encontrada";
                return Page();
            }
        }
    }
}
