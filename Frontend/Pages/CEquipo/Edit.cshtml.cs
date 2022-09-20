using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
namespace Frontend.Pages.CEquipo
{
    public class EditModel : PageModel
    {
      //Atributos
        private readonly IREquipo _repoEquipo;
        private readonly IRPatrocinador _repoPat;

        [BindProperty]
        public Equipo Equipo {get;set;}
        public IEnumerable<Patrocinador> Patrocinadores {get;set;}

        //Constructor

        public EditModel (IREquipo repoEqu, IRPatrocinador repoPat)
        {
            this._repoEquipo=repoEqu;
            this._repoPat=repoPat;
        }

        public ActionResult OnGet(int id)
        {
            Equipo=_repoEquipo.BuscarEquipo(id);
            Patrocinadores=_repoPat.ListarPatrocinadores();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoEquipo.ActualizarEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Ya existe un Equipo con el Nombre" + Equipo.Nombre;
                return Page();
            }
        }
    }
}
