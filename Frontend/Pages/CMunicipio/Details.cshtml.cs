using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CMunicipio
{
    public class DetailsModel : PageModel
    {

        //Atributos
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty]
        public Municipio Municipio {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRMunicipio repoMunicipio)
        {
            this._repoMunicipio= repoMunicipio;
        }
        public ActionResult OnGet(int id)
        {
           Municipio= _repoMunicipio.BuscarMunicipio(id);
           return Page(); 
        }
    }
}
