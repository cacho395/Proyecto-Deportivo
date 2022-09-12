using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio
{
    public class Municipio
    {
        /*
        //atributos
        private int Id;
        private string Nombre;

        //Metodos
        public Municipio()
        {}
        public void setId(int id)
        {
            this.Id=id;
        }
        public int getId()
        {
            return this.Id;
        }
        public void setNombre(string Nombre)
        {
            this.Nombre=nombre;
        }
        public string getNombre()
        {
            return this.Nombre;
        }
        */
        
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