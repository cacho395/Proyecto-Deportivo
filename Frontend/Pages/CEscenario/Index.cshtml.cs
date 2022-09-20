using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class IndexModel : PageModel
    {
        private readonly IREscenario _repoEsc;
        private readonly IRUnidadDeportiva _repoUnD;

        [BindProperty]
        public IEnumerable<Escenario> Escenarios {get;set;}
        public List<EscenarioVw>EscenariosV= new List<EscenarioVw>();

        //Metodos
        //Constructor
        public IndexModel(IREscenario repoEsc, IRUnidadDeportiva repoUnd)
        {
            this._repoEsc=repoEsc;
            this._repoUnD=repoUnd;
        }
        public void OnGet() //se encarga de enviar vistas al usuario
        {
            List<UnidadDeportiva>lstUnidadDeportiva= _repoUnD.ListarUnidadDeportivas1();
            Escenarios=_repoEsc.ListarEscenarios();
            EscenarioVw ev= null;

            foreach (var es in Escenarios)
            {
                ev= new EscenarioVw();
                foreach (var ud in lstUnidadDeportiva)
                {
                    if(es.UnidadDeportivaId== ud.Id)
                    {
                        ev.UnidadDeportiva= ud.Nombre;
                    }
                }
                ev.Id= es.Id;
                ev.Nombre=es.Nombre;
                ev.Espectadores=es.Espectadores;
                ev.Tipo=es.Tipo;

                //Agregar el objeto a la lista

                EscenariosV.Add(ev);
            }
        }
    }
}
