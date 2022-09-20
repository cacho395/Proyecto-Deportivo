using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class DetailsModel : PageModel
    {
    //Atributos
        private readonly IRPatrocinador _repoPatrocinador;

        [BindProperty]
        public Patrocinador Patrocinador {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador= repoPatrocinador;
        }
        public ActionResult OnGet(int id)
        {
           Patrocinador= _repoPatrocinador.BuscarPatrocinador(id);
           return Page(); 
        }
    }
}
