using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class IndexModel : PageModel
    {
         //Atributos
        private readonly IRColegio _repoColegio;
        public IEnumerable<Colegio> Colegios {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRColegio repoColegio)
        {
            this._repoColegio=repoColegio;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Colegios=_repoColegio.ListarColegios();
        }
    }
}
