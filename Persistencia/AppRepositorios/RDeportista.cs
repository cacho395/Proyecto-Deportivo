using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RDeportista:IRDeportista //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RDeportista(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearDeportista(Deportista dep)
        {
            bool creado=false;
            bool ex= exist(dep);
            if(!ex)
            {
                try
                {
                    this._appContext.Deportistas.Add(dep);
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
        public Deportista BuscarDeportista(int id)
        {
            return _appContext.Deportistas.Find(id);
        }

        public bool ActualizarDeportista(Deportista depo)
        {
            bool actualizado=false;
            var dep=_appContext.Deportistas.Find(depo.Id);
            if(dep != null)
            {
                //bool ex= exist(tor);
                //if(!ex)
                {
                    try
                    {
                        dep.Documento=depo.Documento;
                        dep.Nombres=depo.Nombres;
                        dep.Apellidos= depo.Apellidos;
                        dep.Genero= depo.Genero;
                        dep.Modalidad= depo.Modalidad;
                        dep.FechaNacimiento= depo.FechaNacimiento;
                        dep.Rh= depo.Rh;
                        dep.EPS=depo.EPS;
                        dep.Celular= depo.Celular;
                        dep.EquipoId=depo.EquipoId;
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
        public bool EliminarDeportista(int id)
        {
            bool eliminado= false;
            var dep= this._appContext.Deportistas.Find(id);
            if(dep !=null)
            {
                try
                {
                    this._appContext.Deportistas.Remove(dep);
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
        public List<Deportista> ListarDeportistas1()
        {
            return this._appContext.Deportistas.ToList();
        }
        public IEnumerable<Deportista> ListarDeportistas()
        {
            return this._appContext.Deportistas;
        }

        private bool exist(Deportista deportista)
        {
            bool ex= false;
            Deportista dep= _appContext.Deportistas.FirstOrDefault(d=>d.Documento == deportista.Documento);
            if(dep !=null)
            {
                ex=true;
            }
            return ex;
        }

       
    }
}