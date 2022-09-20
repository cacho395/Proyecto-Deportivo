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
        private readonly IREquipo _repoEquipo;

        [BindProperty]
        public IEnumerable<Entrenador> Entrenadores {get;set;}
        public List<EntrenadorView>EntrenadoresV= new List<EntrenadorView>();

        //Metodos
        //Constructor
        public IndexModel(IREntrenador repoEntrenador, IREquipo repoEqu)
        {
            this._repoEntrenador=repoEntrenador;
            this._repoEquipo=repoEqu;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            List<Equipo>lstEquipos= _repoEquipo.ListarEquipos1();
            Entrenadores=_repoEntrenador.ListarEntrenadores();
            EntrenadorView ev= null;

            foreach (var e in Entrenadores)
            {
                ev= new EntrenadorView();
                foreach (var eq in lstEquipos)
                {
                    if(e.EquipoId== eq.Id)
                    {
                        ev.Equipo= eq.Nombre;
                    }
                }
                ev.Id= e.Id;
                ev.Documento=e.Documento;
                ev.Nombres=e.Nombres;
                ev.Apellidos=e.Apellidos;

                //Agregar el objeto a la lista

                EntrenadoresV.Add(ev);
            }
        }
    }
}
