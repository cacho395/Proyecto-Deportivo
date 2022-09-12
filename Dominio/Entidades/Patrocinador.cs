using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Patrocinador
    {
              
        // Propiedades
        public int Id {get;set;}
        [Required(ErrorMessage="Documento es obligatorio")]
        [MaxLength(15,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(6, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Documento {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(40,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nombre {get;set;}
        [Required(ErrorMessage="Tipo es obligatorio")]
        [MaxLength(10,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(5, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Tipo {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}

        //Propiedad navigacional con Equipo
        public List<Equipo> Equipos {get;set;}
    }
}