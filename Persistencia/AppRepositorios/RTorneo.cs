using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RTorneo:IRTorneo //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RTorneo(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearTorneo(Torneo torneo)
        {
            bool creado=false;
            bool ex= exist(torneo);
            if(!ex)
            {
                try
                {
                    this._appContext.Torneos.Add(torneo);
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
        public Torneo BuscarTorneo(int id)
        {
            return _appContext.Torneos.Find(id);
        }

        public bool ActualizarTorneo(Torneo torneo)
        {
            bool actualizado=false;
            var tor=_appContext.Torneos.Find(torneo.Id);
            if(tor != null)
            {
                //bool ex= exist(tor);
                //if(!ex)
                {
                    try
                    {
                        tor.Nombre=torneo.Nombre;
                        tor.Categoria=torneo.Categoria;
                        tor.Modalidad= torneo.Modalidad;
                        tor.FechaInicio= torneo.FechaInicio;
                        tor.FechaFin= torneo.FechaFin;
                        tor.Equipo= torneo.Equipo;
                        tor.Fixture= torneo.Fixture;
                        tor.MunicipioId=torneo.MunicipioId;
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
        public bool EliminarTorneo(int id)
        {
            bool eliminado= false;
            var tor= this._appContext.Torneos.Find(id);
            if(tor !=null)
            {
                try
                {
                    this._appContext.Torneos.Remove(tor);
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
        public List<Torneo> ListarTorneos1()
        {
            return this._appContext.Torneos.ToList();
        }
        public IEnumerable<Torneo> ListarTorneos()
        {
            return this._appContext.Torneos;
        }

        private bool exist(Torneo torneo)
        {
            bool ex= false;
            Torneo tor= _appContext.Torneos.FirstOrDefault(t=> t.Nombre == torneo.Nombre);
            if(tor !=null)
            {
                ex=true;
            }
            return ex;
        }

        private bool date(Torneo fecha)
        {
            bool da= false;
            Torneo fec= _appContext.Torneos.FirstOrDefault(t=> t.FechaInicio >= fecha.FechaFin);
            if(fec !=null)
            {
                da=true;
            }
            return da;
        }
    }
}