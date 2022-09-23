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
            
            return creado;
        }
        public Entrenador BuscarEntrenador(int id)
        {
            return _appContext.Entrenadores.Find(id);
        }

        public bool ActualizarEntrenador(Entrenador ent)
        {
            bool actualizado=false;
            var en=_appContext.Entrenadores.Find(ent.Id);
            if(en != null)
            {
                try
                {
                    en.Documento=ent.Documento;
                    en.Nombres=ent.Nombres;
                    en.Apellidos=ent.Apellidos;
                    en.Modalidad= ent.Modalidad;
                    en.Celular= ent.Celular;
                    en.Correo= ent.Correo;
                    en.EquipoId=ent.EquipoId;
                    _appContext.SaveChanges();
                    actualizado= true;
                }
                catch (System.Exception)
                {
                    
                    actualizado=false;
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
        public List<Entrenador> ListarEntrenadores1()
        {
            return this._appContext.Entrenadores.ToList();
        }
        public IEnumerable<Entrenador> ListarEntrenadores()
        {
            return this._appContext.Entrenadores;
        }

        private bool exist(Entrenador ent)
        {
            bool ex= false;
            Entrenador en= _appContext.Entrenadores.FirstOrDefault(e=> e.Nombres == ent.Nombres);
            if(en !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}