using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRArbitro _repoArbitro;
        private readonly IRColegio _repoColegio;

        [BindProperty] //propiedad vinculada con el form html
        public Arbitro Arbitro { get; set; }
        public IEnumerable<Colegio> Colegios {get;set;}

        //Metodos
        //Constructor
        public EditModel(IRArbitro repoArbitro, IRColegio repoColegio)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoColegio;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet(int id)
        {
            Arbitro=_repoArbitro.BuscarArbitro(id);
            Colegios=_repoColegio.ListarColegios();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoArbitro.ActualizarArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Este Arbitro ya se encuentra creado";
                return Page();
            }
        }

    }
}
