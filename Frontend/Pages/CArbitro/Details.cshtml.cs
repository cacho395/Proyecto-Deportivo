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
        private readonly IRTorneo _repoTor;

        [BindProperty]
        public Arbitro Arbitro {get;set;}
        public Colegio Colegio {get;set;}
        public Torneo Torneo {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRArbitro repoArbitro, IRColegio repoCol, IRTorneo repoTor)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoCol;
            this._repoTor= repoTor;
        }
        public ActionResult OnGet(int id)
        {
           Arbitro= _repoArbitro.BuscarArbitro(id);
           Colegio= _repoColegio.BuscarColegio(Arbitro.ColegioId);
           Torneo= _repoTor.BuscarTorneo(Arbitro.TorneoId);
           return Page(); 

           if(Arbitro !=null && Colegio !=null && Torneo !=null)
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
