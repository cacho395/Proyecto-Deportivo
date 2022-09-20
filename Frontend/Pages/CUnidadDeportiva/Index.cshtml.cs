using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
    public class IndexModel : PageModel
    {
        private readonly IRUnidadDeportiva _repoUnd;
        public IEnumerable<UnidadDeportiva> UnidadDeportivas {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRUnidadDeportiva repoUnd)
        {
            this._repoUnd=repoUnd;
        }
        public void OnGet() //se encarga de enviar vistas al usuario
        {
            UnidadDeportivas=_repoUnd.ListarUnidadDeportivas();
        }

    }
}
