using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class DeleteModel : PageModel
    {
        private readonly IRDeportista _repoDep;
        private readonly IREquipo _repoEqu;

        [BindProperty]
        public Deportista Deportista {get;set;}
        public Equipo Equipo {get;set;}

        public DeleteModel(IRDeportista repoDep, IREquipo repoEqu)
        {
            this._repoDep= repoDep;
            this._repoEqu= repoEqu;
        }

        public ActionResult OnGet(int id)
        {
            Deportista= _repoDep.BuscarDeportista(id);
            Equipo= _repoEqu.BuscarEquipo(Deportista.EquipoId);

            if(Deportista!=null && Equipo!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Deportista no fue encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoDep.EliminarDeportista(Deportista.Id);
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
