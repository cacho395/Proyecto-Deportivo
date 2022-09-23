using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class CreaArbiModel : PageModel
    {
        //Atributos
        private readonly IRArbitro _repoArbitro;
        private readonly IRColegio _repoColegio;
        private readonly IRTorneo _repoTor;

        [BindProperty] //propiedad vinculada con el form html
        public Arbitro Arbitro { get; set; }
        public IEnumerable<Colegio> Colegios {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}

        //Metodos
        //Constructor
        public CreaArbiModel(IRArbitro repoArbitro, IRColegio repoColegio, IRTorneo repoTor)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoColegio;
            this._repoTor= repoTor;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            Colegios=_repoColegio.ListarColegios();
            Torneos=_repoTor.ListarTorneos();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoArbitro.CrearArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Colegios=_repoColegio.ListarColegios();
                Torneos=_repoTor.ListarTorneos();
                ViewData["Error"]= "Este Arbitro ya se encuentra creado";
                return Page();
            }
        }

    }
}