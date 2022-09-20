using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class DetailsModel : PageModel
    {
        private readonly IREntrenador _repoEntrenador;
        private readonly IREquipo _repoEquipo;

        [BindProperty]
        public Entrenador Entrenador {get;set;}
        public Equipo Equipo {get;set;}

        //Constructor

        public DetailsModel(IREntrenador repoEnt, IREquipo repoEqu)
        {
            this._repoEntrenador= repoEnt;
            this._repoEquipo= repoEqu;
        }
        public ActionResult OnGet(int id)
        {
            Entrenador= _repoEntrenador.BuscarEntrenador(id);
            Equipo= _repoEquipo.BuscarEquipo(Entrenador.EquipoId);

            if(Entrenador!=null && Equipo!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Entrenador no encontrado";
                return Page();
            }
        }
    }
}
