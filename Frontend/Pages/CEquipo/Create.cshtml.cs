using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IREquipo _repoEquipo;
        private readonly IRPatrocinador _repoPat;

        [BindProperty]
        public Equipo Equipo {get;set;}
        public IEnumerable<Patrocinador> Patrocinadores {get;set;}

        //Constructor

        public CreateModel (IREquipo repoEqu, IRPatrocinador repoPat)
        {
            this._repoEquipo=repoEqu;
            this._repoPat=repoPat;
        }

        public ActionResult OnGet()
        {
            Patrocinadores=_repoPat.ListarPatrocinadores();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoEquipo.CrearEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Patrocinadores=_repoPat.ListarPatrocinadores();
                ViewData["Error"]= "Ya existe un Equipo con el Nombre" + Equipo.Nombre;
                return Page();
            }
        }
    }
}
