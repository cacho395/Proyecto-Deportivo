using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Escenario
    {
        public int Id {get;set;}
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(30,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(5, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        public string Nombre {get;set;}
        [Required(ErrorMessage="Espectadores es obligatorio")]
        public int Espectadores {get;set;}
        [Required(ErrorMessage="Tipo es obligatorio")]
        public string Tipo {get;set;}

        //Relacion Unidad Deportiva
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int UnidadDeportivaId {get;set;}
    }
}