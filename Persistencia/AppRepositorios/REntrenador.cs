using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class REntrenador:IREntrenador //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public REntrenador(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearEntrenador(Entrenador ent)
        {
            bool creado=false;
            bool ex= exist(ent);
            if(!ex)
            {
                try
                {
                    this._appContext.Entrenadores.Add(ent);
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
        public Entrenador BuscarEntrenador(int id)
        {
            Entrenador entrenador=  _appContext.Entrenadores.Find(id);

            return entrenador;
        }

        public Entrenador BuscarEntrenadorD(string doc)
        {
            Entrenador entrenador=  _appContext.Entrenadores.FirstOrDefault(e=> e.Documento== doc);

            return entrenador;
        }
        public bool ActualizarEntrenador(Entrenador ent)
        {
            bool actualizado=false;
            var en=_appContext.Entrenadores.Find(ent.Id);
            if(en != null)
            {
                bool ex= exist(ent);
                if(!ex)
                {
                    try
                    {
                        en.Documento=ent.Documento;
                        en.Nombres=ent.Nombres;
                        en.Apellidos=ent.Apellidos;
                        en.Modalidad= ent.Modalidad;
                        en.Celular= ent.Celular;
                        en.Correo= ent.Correo;
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
        public bool EliminarEntrenador(int id)
        {
            bool eliminado= false;
            var ent= this._appContext.Entrenadores.Find(id);
            if(ent !=null)
            {
                try
                {
                    this._appContext.Entrenadores.Remove(ent);
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
        /*public List<Municipio> ListarMunicipios1()
        {
            return this._appContext.Municipios.ToList();
        }*/
        public IEnumerable<Entrenador> ListarEntrenadores()
        {
            return this._appContext.Entrenadores;
        }

        private bool exist(Entrenador entrenador)
        {
            bool ex= false;
            Entrenador ent= _appContext.Entrenadores.FirstOrDefault(e=> e.Documento == entrenador.Documento);
            if(ent !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}