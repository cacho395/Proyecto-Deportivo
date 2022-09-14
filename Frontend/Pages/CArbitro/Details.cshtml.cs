using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IRArbitro _repoArbitro;
        private readonly IRColegio _repoColegio;

        [BindProperty]
        public Arbitro Arbitro {get;set;}
        public Colegio Colegio {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRArbitro repoArbitro, IRColegio repoCol)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoCol;
        }
        public ActionResult OnGet(int id)
        {
           Arbitro= _repoArbitro.BuscarArbitro(id);
           Colegio= _repoColegio.BuscarColegio(Arbitro.ColegioId);
           return Page(); 

           if(Arbitro!=null && Colegio!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Arbitro no encontrado";
                return Page();
            }
        }
    }
}
