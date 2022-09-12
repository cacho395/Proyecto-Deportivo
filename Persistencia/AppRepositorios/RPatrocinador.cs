using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RPatrocinador:IRPatrocinador //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RPatrocinador(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearPatrocinador(Patrocinador pat)
        {
            bool creado=false;
            bool ex= exist(pat);
            if(!ex)
            {
                try
                {
                    this._appContext.Patrocinadores.Add(pat);
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
        public Patrocinador BuscarPatrocinador(int id)
        {
            Patrocinador patrocinador=  _appContext.Patrocinadores.Find(id);

            return patrocinador;
        }

        public Patrocinador BuscarPatrocinadorD(string doc)
        {
            Patrocinador patrocinador=  _appContext.Patrocinadores.FirstOrDefault(p=> p.Documento== doc);

            return patrocinador;
        }
        public bool ActualizarPatrocinador(Patrocinador pat)
        {
            bool actualizado=false;
            var patro=_appContext.Patrocinadores.Find(pat.Id);
            if(patro != null)
            {
                //bool ex= exist(pat);
                //if(!ex)
                {
                    try
                    {
                        patro.Documento=pat.Documento;
                        patro.Nombre=pat.Nombre;
                        patro.Tipo=pat.Tipo;
                        patro.Direccion= pat.Direccion;
                        patro.Telefono= pat.Telefono;
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
        public bool EliminarPatrocinador(int id)
        {
            bool eliminado= false;
            var pat= this._appContext.Patrocinadores.Find(id);
            if(pat !=null)
            {
                try
                {
                    this._appContext.Patrocinadores.Remove(pat);
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
        public IEnumerable<Patrocinador> ListarPatrocinadores()
        {
            return this._appContext.Patrocinadores;
        }

        private bool exist(Patrocinador patrocinador)
        {
            bool ex= false;
            Patrocinador pat= _appContext.Patrocinadores.FirstOrDefault(p=> p.Documento == patrocinador.Documento);
            if(pat !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}