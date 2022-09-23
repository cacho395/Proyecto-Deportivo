using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRDeportista _repoDep;
        private readonly IREquipo _repoEqu;

        [BindProperty]
        public Deportista Deportista {get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}

        //Constructor

        public CreateModel (IRDeportista repoDep, IREquipo repoEqu)
        {
            this._repoDep=repoDep;
            this._repoEqu=repoEqu;
        }

        public ActionResult OnGet()
        {
            Equipos=_repoEqu.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoDep.CrearDeportista(Deportista);
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
