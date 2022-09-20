using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IREquipo
    {
        public bool CrearEquipo(Equipo equ);
        public Equipo BuscarEquipo(int id);
        public bool ActualizarEquipo(Equipo equ);
        public bool EliminarEquipo(int id);
        public IEnumerable<Equipo> ListarEquipos(); //tipo de lista mas compatible
        public List<Equipo>ListarEquipos1();
        
    }
}