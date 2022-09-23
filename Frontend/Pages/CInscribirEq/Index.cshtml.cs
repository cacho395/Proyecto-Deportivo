using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CInscribirEq
{
    public class IndexModel : PageModel
    {
        private readonly IRTorneoEquipo _repoTorEqu;
        private readonly IRTorneo _repoTor;
        private readonly IREquipo _repoEqu;

        [BindProperty]
        public IEnumerable<TorneoEquipo> TorneoEquipos {get;set;}
        public List<TorneoEquipoView> TorneoEquiposV = new List<TorneoEquipoView>();

        public IndexModel(IREquipo repoEqu, IRTorneo repoTor, IRTorneoEquipo repoTorEqu)
        {
            this._repoEqu=repoEqu;
            this._repoTor=repoTor;
            this._repoTorEqu=repoTorEqu;
        }

        public void OnGet()
        {
            List<Torneo>lstTorneos= _repoTor.ListarTorneos1();
            List<Equipo>lstEquipos= _repoEqu.ListarEquipos1();
            TorneoEquipos=_repoTorEqu.ListarTorneoEquipos();
            TorneoEquipoView tev=null;

            foreach (var te in TorneoEquipos)
            {
                tev=new TorneoEquipoView();
                foreach (var t in lstTorneos)
                {
                    if(te.TorneoId== t.Id)
                    {
                        tev.Torneo= t.Nombre;
                        tev.TorneoId= t.Id;
                    }
                }

                foreach (var e in lstEquipos)
                {
                    if(te.EquipoId==e.Id)
                    {
                        tev.Equipo= e.Nombre;
                        tev.EquipoId= e.Id;
                    }
                    
                }

                TorneoEquiposV.Add(tev);
                
            }
        }
    }
}
