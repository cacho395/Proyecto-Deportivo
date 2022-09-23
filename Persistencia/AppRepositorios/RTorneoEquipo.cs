using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RTorneoEquipo:IRTorneoEquipo //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RTorneoEquipo(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearTorneoEquipo(TorneoEquipo toreq)
        {
            bool creado=false;
            bool ex= exist(toreq);
            if(!ex)
            {
                try
                {
                    this._appContext.TorneoEquipos.Add(toreq);
                    this._appContext.SaveChanges();
                    creado=true;
                }
                catch (System.Exception)
                {
                    creado=false;
                }

                
            }
            return creado;
        }
        public TorneoEquipo BuscarTorneoEquipo(int idT, int idE)
        {
            return _appContext.TorneoEquipos.FirstOrDefault(t => t.TorneoId==idT && t.EquipoId==idE);
        }
        public bool EliminarTorneoEquipo(int idT, int idE)
        {
            bool eliminado= false;
            var tor= this._appContext.TorneoEquipos.FirstOrDefault(t => t.TorneoId==idT && t.EquipoId==idE);
            if(tor !=null)
            {
                try
                {
                    this._appContext.TorneoEquipos.Remove(tor);
                    this._appContext.SaveChanges();
                    eliminado=true;
                }
                catch (System.Exception)
                {
                    
                    eliminado=false;
                }
            }

            return eliminado;
        }
        public IEnumerable<TorneoEquipo> ListarTorneoEquipos()
        {
            return this._appContext.TorneoEquipos;
        }

        private bool exist(TorneoEquipo toreq)
        {
            bool ex= false;
            var te= _appContext.TorneoEquipos.FirstOrDefault(t=> t.EquipoId == toreq.EquipoId
                                                                && t.TorneoId==toreq.TorneoId);
            if(te !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}