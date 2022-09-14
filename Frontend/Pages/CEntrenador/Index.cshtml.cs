using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IREntrenador _repoEntrenador;
        public IEnumerable<Entrenador> Entrenadores {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IREntrenador repoEntrenador)
        {
            this._repoEntrenador=repoEntrenador;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            Entrenadores=_repoEntrenador.ListarEntrenadores();
        }
    }
}
