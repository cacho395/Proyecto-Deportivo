using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class REquipo:IREquipo //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public REquipo(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearEquipo(Equipo equ)
        {
            bool creado=false;
            try
            {
                this._appContext.Equipos.Add(equ);
                this._appContext.SaveChanges();
                creado=true;
            }
            catch (System.Exception)
            {
                creado=false;
            }
            return creado;
        }
        public Equipo BuscarEquipo(int id)
        {
            Equipo equipo=  _appContext.Equipos.Find(id);

            return equipo;
        }
        public bool ActualizarEquipo(Equipo equ)
        {
            bool actualizado=false;
            var eq=_appContext.Equipos.Find(equ.Id);
            if(eq != null)
            { 
                    try
                {
                    eq.Nombre=equ.Nombre;
                    eq.Modalidades=equ.Modalidades;
                    eq.Jugadores= equ.Jugadores;
                    eq.PatrocinadorId=equ.PatrocinadorId;
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
        public bool EliminarEquipo(int id)
        {
            bool eliminado= false;
            var eq= this._appContext.Equipos.Find(id);
            if(eq !=null)
            {
                try
                {
                    this._appContext.Equipos.Remove(eq);
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
        public List<Equipo> ListarEquipos1()
        {
            return this._appContext.Equipos.ToList();
        }
        public IEnumerable<Equipo> ListarEquipos()
        {
            return this._appContext.Equipos;
        }

    }
}