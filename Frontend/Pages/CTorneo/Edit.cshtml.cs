using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneo
{
    public class EditModel : PageModel
    {
        private readonly IRTorneo _repoTorneo;
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty]
        public Torneo Torneo {get;set;}
        public IEnumerable<Municipio> Municipios {get;set;}

        public EditModel(IRTorneo repoTor, IRMunicipio repoMun)
        {
            this._repoTorneo= repoTor;
            this._repoMunicipio= repoMun;
        }
        public ActionResult OnGet(int id)
        {
            Torneo= _repoTorneo.BuscarTorneo(id);
            Municipios=_repoMunicipio.ListarMunicipio();
            return Page();

        }

        public ActionResult OnPost()
        {
            bool funciono= _repoTorneo.ActualizarTorneo(Torneo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No es posible Editar este registro";
                return Page();
            }
        }
    }
}
