using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RMunicipio:IRMunicipio //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RMunicipio(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearMunicipio(Municipio mun)
        {
            bool creado=false;
            bool ex= exist(mun);
            if(!ex)
            {
                try
                {
                    this._appContext.Municipios.Add(mun);
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
        public Municipio BuscarMunicipio(int idMunicipio)
        {
            Municipio municipio=  _appContext.Municipios.Find(idMunicipio);

            return municipio;
        }
        public bool ActualizarMunicipio(Municipio mun)
        {
            bool actualizado=false;
            var muni=_appContext.Municipios.Find(mun.Id);
            if(muni != null)
            {
                bool ex= exist(mun);
                if(!ex)
                {
                    try
                    {
                        muni.Nombre=mun.Nombre;
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
        public bool EliminarMunicipio(int idmunicipio)
        {
            bool eliminado= false;
            var mun= this._appContext.Municipios.Find(idmunicipio);
            if(mun !=null)
            {
                try
                {
                    this._appContext.Municipios.Remove(mun);
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
        public List<Municipio> ListarMunicipios1()
        {
            return this._appContext.Municipios.ToList();
        }
        public IEnumerable<Municipio> ListarMunicipio()
        {
            return this._appContext.Municipios;
        }

        private bool exist(Municipio muni)
        {
            bool ex= false;
            Municipio mun= _appContext.Municipios.FirstOrDefault(mun=> mun.Nombre == muni.Nombre);
            if(mun !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}