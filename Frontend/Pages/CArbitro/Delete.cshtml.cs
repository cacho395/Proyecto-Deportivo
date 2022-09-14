using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class DeleteModel : PageModel
    {
        private readonly IRArbitro _repoArbitro;
        private readonly IRColegio _repoColegio;

        [BindProperty]
        public Arbitro Arbitro {get;set;}
        public Colegio Colegio {get;set;}

        //Constructor

        public DeleteModel(IRArbitro repoArbitro, IRColegio repoCol)
        {
            this._repoArbitro= repoArbitro;
            this._repoColegio= repoCol;
        }
        public ActionResult OnGet(int id)
        {
            Arbitro= _repoArbitro.BuscarArbitro(id);
            Colegio= _repoColegio.BuscarColegio(Arbitro.ColegioId);

            if(Arbitro!=null && Colegio!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Arbitro no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoArbitro.EliminarArbitro(Arbitro.Id);
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
