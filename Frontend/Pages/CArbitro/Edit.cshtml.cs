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
        private readonly IRTorneo _repoTor;

        [BindProperty] //propiedad vinculada con el form html
        public Arbitro Arbitro { get; set; }
        public IEnumerable<Colegio> Colegios {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}

        //Metodos
        //Constructor
        public EditModel(IRArbitro repoArbitro, IRColegio repoColegio, IRTorneo repoTor)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoColegio;
            this._repoTor= repoTor;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet(int id)
        {
            Arbitro=_repoArbitro.BuscarArbitro(id);
            if(Arbitro!=null)
            {
                Colegios=_repoColegio.ListarColegios();
                Torneos=_repoTor.ListarTorneos();
                return Page();
            }
            else
            {
                Colegios=_repoColegio.ListarColegios();
                Torneos=_repoTor.ListarTorneos();
                ViewData["Error"]="Arbitro no encontrado";
                return Page(); 
            }
            
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
                Colegios=_repoColegio.ListarColegios();
                Torneos=_repoTor.ListarTorneos();
                ViewData["Error"]= "Ya existe un Arbitro con el Documento: " + Arbitro.Documento;
                return Page();
            }
        }

    }
}
