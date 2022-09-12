using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRTorneo
    {
        public bool CrearTorneo(Torneo torneo);
        public Torneo BuscarTorneo(int id);
        public bool ActualizarTorneo(Torneo torneo);
        public bool EliminarTorneo(int id);
        public IEnumerable<Torneo> ListarTorneos(); //tipo de lista mas compatible
        public List<Torneo> ListarTorneos1();
    }
}