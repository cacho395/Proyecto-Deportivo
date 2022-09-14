using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CMunicipio
{
    public class EditModel : PageModel
    {
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty]
        public Municipio Municipio { get; set; }

        public EditModel(IRMunicipio repoMunicipio)
        {
            this._repoMunicipio= repoMunicipio;
        }
        public ActionResult OnGet(int id)
        {
            Municipio= _repoMunicipio.BuscarMunicipio(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoMunicipio.ActualizarMunicipio(Municipio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "No se puede actualizar este municipio";
                return Page();
            }
        }
    }
}
