using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class IndexModel : PageModel
    {
       //Atributos
        private readonly IRDeportista _repoDep;
        public IEnumerable<Deportista> Deportistas {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRDeportista repoDep)
        {
            this._repoDep=repoDep;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Deportistas=_repoDep.ListarDeportistas();
        }
    }
}
