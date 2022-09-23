using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio 
{
    public class UndDView
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Direccion {get;set;}
        public string Torneo{get;set;}
    }
}