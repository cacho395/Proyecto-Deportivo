using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRUnidadDeportiva
    {
        public bool CrearUnidadDeportiva(UnidadDeportiva esc);
        public UnidadDeportiva BuscarUnidadDeportiva(int id);
        public bool ActualizarUnidadDeportiva(UnidadDeportiva esc);
        public bool EliminarUnidadDeportiva(int id);
        public List<UnidadDeportiva> ListarUnidadDeportivas1();
        public IEnumerable<UnidadDeportiva> ListarUnidadDeportivas(); //tipo de lista mas compatible
    }
}