using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneo
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRTorneo _repoTorneo;
        private readonly IRMunicipio _repoMun;

        [BindProperty]
        public Torneo Torneo {get;set;}
        public IEnumerable<Municipio> Municipios {get;set;}

        //Constructor

        public CreateModel (IRTorneo repoTor, IRMunicipio repoMun)
        {
            this._repoMun=repoMun;
            this._repoTorneo=repoTor;
        }

        public ActionResult OnGet()
        {
            Municipios=_repoMun.ListarMunicipio();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoTorneo.CrearTorneo(Torneo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Municipios=_repoMun.ListarMunicipio();
                ViewData["Error"]= "Ya existe un Torneo con el Nombre" + Torneo.Nombre;
                return Page();
            }
        }
    }
}
