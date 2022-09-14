using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador _repoPatrocinador;
        public IEnumerable<Patrocinador> Patrocinadores {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador=repoPatrocinador;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Patrocinadores=_repoPatrocinador.ListarPatrocinadores();
        }
    }
}
