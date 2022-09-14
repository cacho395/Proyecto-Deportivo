using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class DetailsModel : PageModel
    {

        //Atributos

        private readonly IRColegio _repoColegio;

        [BindProperty]
        public Colegio Colegio {get;set;}

        //Constructor
        public DetailsModel(IRColegio repoCol)
        {
            this._repoColegio= repoCol;
        }
        public ActionResult OnGet(int id)
        {
            Colegio=_repoColegio.BuscarColegio(id);
            return Page(); 

            if(Colegio!=null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Colegio no encontrado";
                return Page();
            }
        }
    }
}
