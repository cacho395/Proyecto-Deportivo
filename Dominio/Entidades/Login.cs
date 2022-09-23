using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Login
    {
       
        // propiedades
        public int Id {get;set;}

        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        public string Usuario{get;set;}

        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [MaxLength(12,ErrorMessage="{0} debe tener max {1} caracteres")]
        [MinLength(8, ErrorMessage= "{0} debe tener min {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        
    
    }
}