using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RUnidadDeportiva:IRUnidadDeportiva //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RUnidadDeportiva(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearUnidadDeportiva(UnidadDeportiva und)
        {
            bool creado=false;
            bool ex= exist(und);
            if(!ex)
            {
                try
                {
                    this._appContext.UnidadDeportivas.Add(und);
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
        public UnidadDeportiva BuscarUnidadDeportiva(int id)
        {
            UnidadDeportiva unidadDeportiva=  _appContext.UnidadDeportivas.Find(id);

            return unidadDeportiva;
        }

        public bool ActualizarUnidadDeportiva(UnidadDeportiva und)
        {
            bool actualizado=false;
            var ud=_appContext.UnidadDeportivas.Find(und.Id);
            if(ud != null)
            {
                //bool ex= exist(col);
                //if(!ex)
                {
                    try
                    {
                        ud.Nombre=und.Nombre;
                        ud.Direccion=und.Direccion;
                        ud.TorneoId=und.TorneoId;
                        _appContext.SaveChanges();
                        actualizado= true;
                    }
                    catch (System.Exception)
                    {
                        actualizado=false;
                    }
                }
                    
            }

            return actualizado;
        }
        public bool EliminarUnidadDeportiva(int id)
        {
            bool eliminado= false;
            var esc= this._appContext.UnidadDeportivas.Find(id);
            if(esc !=null)
            {
                try
                {
                    this._appContext.UnidadDeportivas.Remove(esc);
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

        public List<UnidadDeportiva> ListarUnidadDeportivas1()
        {
            return this._appContext.UnidadDeportivas.ToList();
        }
        
        public IEnumerable<UnidadDeportiva> ListarUnidadDeportivas()
        {
            return this._appContext.UnidadDeportivas;
        }

        private bool exist(UnidadDeportiva und)
        {
            bool ex= false;
            UnidadDeportiva un= _appContext.UnidadDeportivas.FirstOrDefault(ud=> ud.Nombre == und.Nombre);
            if(un !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}