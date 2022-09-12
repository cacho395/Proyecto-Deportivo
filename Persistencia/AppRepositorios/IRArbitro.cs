using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRArbitro
    {
        public bool CrearArbitro(Arbitro arb);
        public Arbitro BuscarArbitro(int id);
        public Arbitro BuscarArbitroD(string doc);
        public bool ActualizarArbitro(Arbitro arb);
        public bool EliminarArbitro(int id);
        public IEnumerable<Arbitro> ListarArbitros(); //tipo de lista mas compatible
        
    }
}