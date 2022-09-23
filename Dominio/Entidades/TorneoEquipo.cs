using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio
{
    public class TorneoEquipo
    {
        //Llaves Foraneas
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int EquipoId {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int TorneoId {get;set;}

        //Propiedades navigacionales
        public Torneo Torneo {get;set;}
        public Equipo Equipo {get;set;}
    }
}