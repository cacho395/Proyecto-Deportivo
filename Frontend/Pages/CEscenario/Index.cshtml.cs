using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class IndexModel : PageModel
    {
        private readonly IREscenario _repoEsc;
        public IEnumerable<Escenario> Escenarios {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IREscenario repoEsc)
        {
            this._repoEsc=repoEsc;
        }
        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Escenarios=_repoEsc.ListarEscenarios();
        }
    }
}
