using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CMunicipio
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRMunicipio _repoMunicipio;
        public IEnumerable<Municipio> Municipios {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRMunicipio repoMunicipio)
        {
            this._repoMunicipio=repoMunicipio;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Municipios=_repoMunicipio.ListarMunicipio();
        }
    }
}
