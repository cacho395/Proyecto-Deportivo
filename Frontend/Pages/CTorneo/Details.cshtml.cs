using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneo
{
    public class DetailsModel : PageModel
    {
        private readonly IRTorneo _repoTorneo;
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty]
        public Torneo Torneo {get;set;}
        public Municipio Municipio {get;set;}

        public DetailsModel (IRTorneo repoTor, IRMunicipio repoMun)
        {
            this._repoTorneo= repoTor;
            this._repoMunicipio=repoMun;
        }

        public ActionResult OnGet(int id)
        {
            Torneo= _repoTorneo.BuscarTorneo(id);
            Municipio= _repoMunicipio.BuscarMunicipio(Torneo.MunicipioId);

            if(Torneo!=null && Municipio!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Torneo no encontrado";
                return Page();
            }

        }
    }
}
