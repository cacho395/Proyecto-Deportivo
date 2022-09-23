using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Deportista
    {
        public int Id {get;set;}
       
        [Required(ErrorMessage="Documento es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(6, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Documento {get;set;}
        
        [Required(ErrorMessage="Nombres es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nombres {get;set;}
        
        [Required(ErrorMessage="Apellidos es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Apellidos {get;set;}
        public string Genero {get;set;}
        [Required(ErrorMessage="Modalidad es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Modalidad {get;set;}
        [Required(ErrorMessage="FechaNacimiento es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento {get;set;}
        public string Rh {get;set;}
        [Required(ErrorMessage="EPS es obligatorio")]
        public string EPS {get;set;}
        public string Celular{get;set;}

        //Relacion Equipos
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int EquipoId {get;set;}
    }
}