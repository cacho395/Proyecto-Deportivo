using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRPatrocinador
    {
        public bool CrearPatrocinador(Patrocinador pat);
        public Patrocinador BuscarPatrocinador(int id);
        public Patrocinador BuscarPatrocinadorD(string doc);
        public bool ActualizarPatrocinador(Patrocinador pat);
        public bool EliminarPatrocinador(int id);
        public List<Patrocinador>ListarPatrocinadores1();
        public IEnumerable<Patrocinador> ListarPatrocinadores(); //tipo de lista mas compatible
        
    }
}