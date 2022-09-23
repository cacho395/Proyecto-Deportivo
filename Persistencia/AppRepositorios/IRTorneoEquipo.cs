using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRTorneoEquipo
    {
        public bool CrearTorneoEquipo(TorneoEquipo toreq);
        public TorneoEquipo BuscarTorneoEquipo(int idT, int idE);
        public bool EliminarTorneoEquipo(int idT, int idE);
        public IEnumerable<TorneoEquipo> ListarTorneoEquipos(); //tipo de lista mas compatible
    }
}