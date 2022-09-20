using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IREntrenador
    {
        public bool CrearEntrenador(Entrenador ent);
        public Entrenador BuscarEntrenador(int id);
        public bool ActualizarEntrenador(Entrenador ent);
        public bool EliminarEntrenador(int id);
        public List<Entrenador> ListarEntrenadores1();
        public IEnumerable<Entrenador> ListarEntrenadores(); //tipo de lista mas compatible
        
    }
}