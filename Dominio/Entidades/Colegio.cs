using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Dominio
{
    public class Colegio
    {
              
        // propiedades
        public int Id {get;set;}
        [Required(ErrorMessage="Nit es obligatorio")]
        [MaxLength(12,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(6, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nit {get;set;}
        [Required(ErrorMessage="Razon Social es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tener min {1} caracteres")]
        public string RazonSocial {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}
        [Required(ErrorMessage="Modalidad es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(4, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Modalidad {get;set;}
        
        [Required(ErrorMessage="Licencia es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(6, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Licencia {get;set;}

        //propiedad navigacional para la relacion con arbitros

        public List<Arbitro> Arbitros { get; set; }
    }
}