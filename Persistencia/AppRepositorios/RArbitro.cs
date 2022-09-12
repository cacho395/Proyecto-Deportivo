using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RArbitro:IRArbitro //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RArbitro(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearArbitro(Arbitro arb)
        {
            bool creado=false;
            bool ex= exist(arb);
            if(!ex)
            {
                try
                {
                    this._appContext.Arbitros.Add(arb);
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
        public Arbitro BuscarArbitro(int id)
        {
            Arbitro arbitro=  _appContext.Arbitros.Find(id);

            return arbitro;
        }

        public Arbitro BuscarArbitroD(string doc)
        {
            Arbitro arbitro=  _appContext.Arbitros.FirstOrDefault(a=> a.Documento== doc);

            return arbitro;
        }
        public bool ActualizarArbitro(Arbitro arb)
        {
            bool actualizado=false;
            var ar=_appContext.Arbitros.Find(arb.Id);
            if(ar != null)
            {
                //bool ex= exist(arb);
                //if(!ex)
                {
                    try
                    {
                        ar.Documento=arb.Documento;
                        ar.Nombres=arb.Nombres;
                        ar.Apellidos=arb.Apellidos;
                        ar.Modalidad= arb.Modalidad;
                        ar.RH= arb.RH;
                        ar.Celular= arb.Celular;
                        ar.ColegioId=arb.ColegioId;
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
        public bool EliminarArbitro(int id)
        {
            bool eliminado= false;
            var arb= this._appContext.Arbitros.Find(id);
            if(arb !=null)
            {
                try
                {
                    this._appContext.Arbitros.Remove(arb);
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
        public IEnumerable<Arbitro> ListarArbitros()
        {
            return this._appContext.Arbitros;
        }

        private bool exist(Arbitro arbitro)
        {
            bool ex= false;
            Arbitro arb= _appContext.Arbitros.FirstOrDefault(a=> a.Documento == arbitro.Documento);
            if(arb !=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}