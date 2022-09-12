using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Entrenador
    {
        public int Id {get;set;}
        [Required(ErrorMessage="Documento es obligatorio")]
        [MaxLength(15,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(6, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        [RegularExpression("[0-9]*", ErrorMessage="Solo se permiten numeros en este campo")]
        public string Documento {get;set;}
        
        [Required(ErrorMessage="Nombre es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        [RegularExpression("[A-Za-z]*", ErrorMessage="Solo se permite letras en este campo")]
        public string Nombres {get;set;}
        
        [Required(ErrorMessage="Apellidos es obligatorio")]
        [MaxLength(20,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(3, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        [RegularExpression("[A-Za-z]*", ErrorMessage="Solo se permite letras en este campo")]
        public string Apellidos {get;set;}
        
        [Required(ErrorMessage="Modalidad es obligatorio")]
        [MaxLength(10,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(5, ErrorMessage= "{0} debe tenet min {1} caracteres")]
        [RegularExpression("[A-Za-z0-9]*", ErrorMessage="No se permiten caracteres en este campo")]
        public string Modalidad {get;set;}

        [Range(3000000000,3509999999, ErrorMessage="Ingrese un numero de celular valido")]
        public string Celular {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        public string Correo {get;set;}

        //Llave foranea para relacion con Equipo
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int EquipoId {get;set;}


    }
}