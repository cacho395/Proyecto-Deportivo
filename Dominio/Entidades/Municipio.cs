using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio
{
    public class Municipio
    {
        
        // propiedades

        public int Id {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tener min {1} caracteres")]
        public string Nombre {get;set;}


        //Relacion torneo, propiedad navigacional
        public List<Torneo> Torneos {get;set;}

    }
}