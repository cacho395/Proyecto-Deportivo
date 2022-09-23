using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CInscribirEq
{
    public class CreateModel : PageModel
    {
        private readonly IRTorneoEquipo _repoTorEqu;
        private readonly IRTorneo _repoTor;
        private readonly IREquipo _repoEqu;

        [BindProperty]
        public TorneoEquipo TorneoEquipo {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}


        public CreateModel(IRTorneoEquipo repoTorEqu, IRTorneo repoTor, IREquipo repoEqu)
        {
            this._repoTorEqu= repoTorEqu;
            this._repoTor= repoTor;
            this._repoEqu= repoEqu;
        }
        public ActionResult OnGet()
        {
            Torneos= _repoTor.ListarTorneos();
            Equipos= _repoEqu.ListarEquipos();
            if(Torneos != null && Equipos != null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]= "No hay torneo o equipos para esta inscripción";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoTorEqu.CrearTorneoEquipo(TorneoEquipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Torneos= _repoTor.ListarTorneos();
                Equipos= _repoEqu.ListarEquipos();
                ViewData["Error"]="El equipo ya está registrado en este torneo";
                return Page();
            }
        }
    }
}
