using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class DeleteModel : PageModel
    {
        private readonly IREntrenador _repoEntrenador;
        private readonly IREquipo _repoEquipo;

        [BindProperty]
        public Entrenador Entrenador {get;set;}
        public Equipo Equipo {get;set;}

        //Constructor

        public DeleteModel(IREntrenador repoEnt, IREquipo repoEqu)
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

        public ActionResult OnPost()
        {
            bool eliminado= _repoEntrenador.EliminarEntrenador(Entrenador.Id);
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
