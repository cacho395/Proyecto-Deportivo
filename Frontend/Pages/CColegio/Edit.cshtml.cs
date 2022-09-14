using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class EditModel : PageModel
    {
        //Atributos

        private readonly IRColegio _repoColegio;

        [BindProperty]
        public Colegio Colegio {get;set;}

        //Constructor
        public EditModel(IRColegio repoCol)
        {
            this._repoColegio= repoCol;
        }
        public ActionResult OnGet(int id)
        {
            Colegio=_repoColegio.BuscarColegio(id);
            return Page(); 
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoColegio.ActualizarColegio(Colegio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No es posible actualizar este registro";
                return Page();
            }
        }
    }
}
