using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class DeleteModel : PageModel
    {
      //Atributos

        private readonly IRColegio _repoColegio;

        [BindProperty]
        public Colegio Colegio {get;set;}

        //Constructor
        public DeleteModel(IRColegio repoCol)
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

        public ActionResult OnPost()
        {
            bool eliminado= _repoColegio.EliminarColegio(Colegio.Id);
            if(eliminado)
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
