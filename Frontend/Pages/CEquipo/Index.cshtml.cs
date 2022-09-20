using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class IndexModel : PageModel
    {
       //Atributos
        private readonly IREquipo _repoEquipo;
        private readonly IRPatrocinador _repoPat;
        
        [BindProperty]
        public IEnumerable<Equipo> Equipos {get;set;}
        public List<EquipoView> EquiposView = new List<EquipoView>();

        //Metodos
        //Constructor
        public IndexModel(IREquipo repoEquipo, IRPatrocinador repoPat)
        {
            this._repoEquipo=repoEquipo;
            this._repoPat=repoPat;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            List<Patrocinador> lstPatrocinadores=_repoPat.ListarPatrocinadores1();
            Equipos=_repoEquipo.ListarEquipos();
            EquipoView ev= null;

            foreach (var e in Equipos)
            {
                ev= new EquipoView();
                foreach (var p in lstPatrocinadores)
                {
                    if(e.PatrocinadorId==p.Id)
                    {
                        ev.Patrocinador=p.Nombre;
                    }
                    
                }    
                ev.Id=e.Id;
                    ev.Nombre=e.Nombre;
                    ev.Modalidades=e.Modalidades;
                    ev.Jugadores=e.Jugadores;
                    EquiposView.Add(ev);            
            }
        }
    }
}
