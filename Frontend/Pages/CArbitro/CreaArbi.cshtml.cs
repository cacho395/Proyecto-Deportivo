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

        [BindProperty] //propiedad vinculada con el form html
        public Arbitro Arbitro { get; set; }
        public IEnumerable<Colegio> Colegios {get;set;}

        //Metodos
        //Constructor
        public CreaArbiModel(IRArbitro repoArbitro, IRColegio repoColegio)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoColegio;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            Colegios=_repoColegio.ListarColegios();
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
                ViewData["Error"]= "Este Arbitro ya se encuentra creado";
                return Page();
            }
        }

    }
}