using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneo
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRTorneo _repoTorneo;
        private readonly IRMunicipio _repoMun;
        
        [BindProperty]
        public IEnumerable<Torneo> Torneos {get;set;}
        public List<TorneoView> TorneosV = new List<TorneoView>();

        //Metodos
        //Constructor
        public IndexModel(IRTorneo repoTorneo, IRMunicipio repoMun)
        {
            this._repoTorneo=repoTorneo;
            this._repoMun=repoMun;
        }

        public void OnGet() //se encarga de enviar vistas al usuario
        {
            List<Municipio> lstMunicipios=_repoMun.ListarMunicipios1();
            Torneos=_repoTorneo.ListarTorneos();
            TorneoView tv= null;

            foreach (var t in Torneos)
            {
                tv= new TorneoView();
                foreach (var m in lstMunicipios)
                {
                    if(t.MunicipioId==m.Id)
                    {
                        tv.Municipio=m.Nombre;
                    }
                    
                }    
                tv.Id=t.Id;
                    tv.Nombre=t.Nombre;
                    tv.Categoria=t.Categoria;
                    tv.Modalidad=t.Modalidad;
                    tv.FechaInicio=t.FechaInicio;
                    tv.FechaFin=t.FechaFin;
                    tv.Equipo=t.Equipo;
                    tv.Fixture=t.Fixture;
                    TorneosV.Add(tv);            
            }
        }
    }
}
