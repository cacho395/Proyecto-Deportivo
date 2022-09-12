using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRMunicipio
    {
        public bool CrearMunicipio(Municipio mun);
        public Municipio BuscarMunicipio(int idMunicipio);
        public bool ActualizarMunicipio(Municipio mun);
        public bool EliminarMunicipio(int idmunicipio);
        public List<Municipio> ListarMunicipios1();
        public IEnumerable<Municipio> ListarMunicipio(); //tipo de lista mas compatible
        
    }
}