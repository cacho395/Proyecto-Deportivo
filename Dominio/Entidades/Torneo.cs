using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Torneo
    {
       
        // propiedades

        public int Id {get;set;}
        
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        [Display(Name="Nombre Torneo")]
        public string Nombre {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(10,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(5, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Categoria {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(5, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Modalidad {get;set;}

        [Required(ErrorMessage="la FechaInicio es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio {get;set;}

        [Required(ErrorMessage="la FechaFin es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaFin {get;set;}

        [Required(ErrorMessage="el Equipo es obligatorio")]
        public int Equipo {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(15, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Fixture {get;set;}

        // Relacion con Municipio
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int MunicipioId {get;set;}
        
        // Relacion con Patrocinador
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int PatrocinadorId {get;set;}

        //public Municipio Municipio {get;set;}

        
        //Relacion TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos {get;set;}

        //propiedad navigacional para la relacion con UnidadDeportiva
        public List<UnidadDeportiva> UnidadDeportivas { get; set; }

        //Propiedad navigacional Arbitros
        public List<Arbitro> Arbitros {get;set;}
    
    }
}