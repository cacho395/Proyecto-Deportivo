using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class REscenario:IREscenario //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public REscenario(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearEscenario(Escenario esc)
        {
            bool creado=false;
            bool ex= exist(esc);
            if(!ex)
            {
                try
                {
                    this._appContext.Escenarios.Add(esc);
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
        public Escenario BuscarEscenario(int id)
        {
            Escenario escenario=  _appContext.Escenarios.Find(id);

            return escenario;
        }

        public bool ActualizarEscenario(Escenario esc)
        {
            bool actualizado=false;
            var c=_appContext.Escenarios.Find(esc.Id);
            if(c != null)
            {
                //bool ex= exist(col);
                //if(!ex)
                {
                    try
                    {
                        c.Nombre=esc.Nombre;
                        c.Espectadores=esc.Espectadores;
                        c.Tipo=esc.Tipo;
                        c.UnidadDeportivaId= esc.UnidadDeportivaId;
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
        public bool EliminarEscenario(int id)
        {
            bool eliminado= false;
            var esc= this._appContext.Escenarios.Find(id);
            if(esc !=null)
            {
                try
                {
                    this._appContext.Escenarios.Remove(esc);
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
        
        public IEnumerable<Escenario> ListarEscenarios()
        {
            return this._appContext.Escenarios;
        }

        private bool exist(Escenario escenario)
        {
            bool ex= false;
            Escenario esc= _appContext.Escenarios.FirstOrDefault(e=> e.Nombre == escenario.Nombre);
            if(esc !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}