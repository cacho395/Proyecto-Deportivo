using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio
{
    public class Equipo
    {
        public int Id{get;set;}
        
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nombre{get;set;}
        //public List<Modalidades> Modalidades {get;set;}
        

        //propiedad navigacional para la relacion con entrenador
        [Required(ErrorMessage="Entrenador es obligatorio")]
        public Entrenador Tecnico {get;set;}
       
        [Required(ErrorMessage="Jugadores es obligatorio")]
        [RegularExpression("[0-9]*", ErrorMessage="Solo puede ingresar valores numericos")]
        public int Jugadores {get;set;}

        
        //llave foranea para la relacion con Patrocinador

        [Required(ErrorMessage="PatrocinadorId es obligatorio")]
        public int PatrocinadorId { get; set; }
        
        //Relacion TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos {get;set;}

        //Relacion con Deportistas
        public List<Deportista> Deportistas {get;set;}



        

    }
}