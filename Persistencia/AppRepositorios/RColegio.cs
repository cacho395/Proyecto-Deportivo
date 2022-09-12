using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RColegio:IRColegio //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RColegio(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearColegio(Colegio col)
        {
            bool creado=false;
            bool ex= exist(col);
            if(!ex)
            {
                try
                {
                    this._appContext.Colegios.Add(col);
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
        public Colegio BuscarColegio(int id)
        {
            Colegio colegio=  _appContext.Colegios.Find(id);

            return colegio;
        }

        public bool ActualizarColegio(Colegio col)
        {
            bool actualizado=false;
            var c=_appContext.Colegios.Find(col.Id);
            if(c != null)
            {
                bool ex= exist(col);
                if(!ex)
                {
                    try
                    {
                        c.Nit=col.Nit;
                        c.RazonSocial=col.RazonSocial;
                        c.Direccion=col.Direccion;
                        c.Telefono= col.Telefono;
                        c.Modalidad= col.Modalidad;
                        c.Licencia= col.Licencia;
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
        public bool EliminarColegio(int id)
        {
            bool eliminado= false;
            var col= this._appContext.Colegios.Find(id);
            if(col !=null)
            {
                try
                {
                    this._appContext.Colegios.Remove(col);
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
        
        public IEnumerable<Colegio> ListarColegios()
        {
            return this._appContext.Colegios;
        }

        private bool exist(Colegio colegio)
        {
            bool ex= false;
            Colegio col= _appContext.Colegios.FirstOrDefault(c=> c.Nit == colegio.Nit);
            if(col !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}