using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio 
{
    public class UnidadDeportiva
    {
        public int Id {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nombre {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Direccion {get;set;}

        //Llave foranea para la relacion con Torneo
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int TorneoId {get;set;}

        //Propiedad navigacional con Escenarios
        public List<Escenario> Escenarios { get; set; }



    }
}