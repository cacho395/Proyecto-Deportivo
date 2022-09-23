using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class EditModel : PageModel
    {
       //Atributos
        private readonly IRDeportista _repoDep;
        private readonly IREquipo _repoEqu;

        [BindProperty]
        public Deportista Deportista {get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}

        //Constructor

        public EditModel (IRDeportista repoDep, IREquipo repoEqu)
        {
            this._repoDep=repoDep;
            this._repoEqu=repoEqu;
        }

        public ActionResult OnGet(int id)
        {
            Deportista=_repoDep.BuscarDeportista(id);
            if(Deportista!=null)
            {
                Equipos=_repoEqu.ListarEquipos();
                return Page();
            }
            else
            {
                Equipos=_repoEqu.ListarEquipos();
                ViewData["Error"]="Deportista no encontrado";
                return Page(); 
            }
            
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoDep.ActualizarDeportista(Deportista);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Equipos=_repoEqu.ListarEquipos();
                ViewData["Error"]= "Ya existe un Deportista con el Documento: " + Deportista.Documento;
                return Page();
            }
        }
    }
}
