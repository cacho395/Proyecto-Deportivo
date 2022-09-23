using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CInscribirEq
{
    public class DeleteModel : PageModel
    {
        private readonly IRTorneoEquipo _repoTorEqu;
        private readonly IRTorneo _repoTor;
        private readonly IREquipo _repoEqu;

        [BindProperty]
        public TorneoEquipo TorneoEquipo {get;set;}
        public Torneo Torneo {get;set;}
        public Equipo Equipo {get;set;}


        public DeleteModel(IRTorneoEquipo repoTorEqu, IRTorneo repoTor, IREquipo repoEqu)
        {
            this._repoTorEqu= repoTorEqu;
            this._repoTor= repoTor;
            this._repoEqu= repoEqu;
        }
        public ActionResult OnGet(int idT, int idE)
        {
            TorneoEquipo= _repoTorEqu.BuscarTorneoEquipo(idT, idE);
            Torneo= _repoTor.BuscarTorneo(TorneoEquipo.TorneoId);
            Equipo=  _repoEqu.BuscarEquipo(TorneoEquipo.EquipoId);

            if(TorneoEquipo !=null && Torneo !=null && Equipo !=null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Torneo o Equipo no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoTorEqu.EliminarTorneoEquipo(TorneoEquipo.TorneoId, TorneoEquipo.EquipoId);
            if(eliminado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No es posible eliminar este registro";
                return Page();
            }
        }
    }
}
