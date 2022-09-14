using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CMunicipio
{
    public class CrearMunModel : PageModel
    {
        //Atributos
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty] //propiedad vinculada con el form html
        public Municipio Municipio { get; set; }

        //Metodos
        //Constructor
        public CrearMunModel(IRMunicipio repoMunicipio)
        {
            this._repoMunicipio= repoMunicipio;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoMunicipio.CrearMunicipio(Municipio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Este Municipio ya se encuentra creado";
                return Page();
            }
        }
    }
}
