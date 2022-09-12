namespace Dominio
{
    public class TorneoEquipo
    {
        //Llaves Foraneas
        public int EquipoId {get;set;}
        public int TorneoId {get;set;}

        //Propiedades navigacionales
        public Torneo Torneo {get;set;}
        public Equipo Equipo {get;set;}
    }
}