using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRArbitro _repoArbitro;
        public IEnumerable<Arbitro> Arbitros {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRArbitro repoArbitro)
        {
            this._repoArbitro=repoArbitro;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Arbitros=_repoArbitro.ListarArbitros();
        }
    }
}
