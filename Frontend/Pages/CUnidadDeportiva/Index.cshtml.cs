using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
    public class IndexModel : PageModel
    {
        private readonly IRUnidadDeportiva _repoUnd;
        private readonly IRTorneo _repoTor;
        
        [BindProperty]
        public IEnumerable<UnidadDeportiva> UnidadDeportivas {get;set;}
        public List<UndDView> UnidadV= new List<UndDView>();

        //Metodos
        //Constructor
        public IndexModel(IRUnidadDeportiva repoUnd, IRTorneo repoTor)
        {
            this._repoUnd=repoUnd;
            this._repoTor=repoTor;
        }
        public void OnGet() //se encarga de enviar vistas al usuario
        {
            List<Torneo>lstTorneos= _repoTor.ListarTorneos1();
            UnidadDeportivas=_repoUnd.ListarUnidadDeportivas();
            UndDView ud= null;
            
            foreach (var und in UnidadDeportivas)
            {
                ud= new UndDView();
                foreach (var tr in lstTorneos)
                {
                    if(und.TorneoId== tr.Id)
                    {
                        ud.Torneo= tr.Nombre;
                    }
                }
                ud.Id= und.Id;
                ud.Nombre=und.Nombre;
                ud.Direccion=und.Direccion;

                //Agregar el objeto a la lista

                UnidadV.Add(ud);
            }
        }

    }
}
