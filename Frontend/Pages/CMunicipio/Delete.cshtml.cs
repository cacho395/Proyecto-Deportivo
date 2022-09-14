using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CMunicipio
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty]
        public Municipio Municipio {get;set;}

        //Metodos
        //Constructor

        public DeleteModel(IRMunicipio repoMunicipio)
        {
            this._repoMunicipio= repoMunicipio;
        }

        public ActionResult OnGet(int id)
        {
            Municipio= _repoMunicipio.BuscarMunicipio(id);
            if(Municipio== null)
            {
                ViewData["Error"]="Municipio no encontrado";
                return Page();
            }
            return Page();

        }

        public ActionResult OnPost()
        {
            bool funciono= _repoMunicipio.EliminarMunicipio(Municipio.Id);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No es posible eliminar este registro";
                return Page();
            }
        }
    }
}
