using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IREscenario
    {
        public bool CrearEscenario(Escenario esc);
        public Escenario BuscarEscenario(int id);
        public bool ActualizarEscenario(Escenario esc);
        public bool EliminarEscenario(int id);
        public IEnumerable<Escenario> ListarEscenarios(); //tipo de lista mas compatible
    }
}