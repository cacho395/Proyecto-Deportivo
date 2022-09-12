using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Arbitro
    {
        public int Id {get;set;}
        [Required(ErrorMessage="Documento es obligatorio")]
        [MaxLength(15,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(6, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Documento {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nombres {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Apellidos {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(5, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Modalidad {get;set;}
        public string RH {get;set;}
        public string Celular {get;set;}

        // relacion con Colegio

        [Required(ErrorMessage="Este campo es obligatorio")]
        public int ColegioId { get; set; }

        // relacion con Torneo

        //public int TorneoId {get;set;}
    }
}