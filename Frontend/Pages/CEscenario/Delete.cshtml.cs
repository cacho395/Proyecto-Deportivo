using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class DeleteModel : PageModel
    {
        private readonly IREscenario _repoEsc;
        private readonly IRUnidadDeportiva _repoUniD;

        [BindProperty]
        public Escenario Escenario {get;set;}
        public UnidadDeportiva UnidadDeportiva {get;set;}

        //Constructor

        public DeleteModel(IREscenario repoEsc, IRUnidadDeportiva repoUniD)
        {
            this._repoEsc= repoEsc;
            this._repoUniD= repoUniD;
        }
        public ActionResult OnGet(int id)
        {
            Escenario= _repoEsc.BuscarEscenario(id);
            UnidadDeportiva= _repoUniD.BuscarUnidadDeportiva(Escenario.UnidadDeportivaId);

            if(Escenario!=null && UnidadDeportiva!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Escenario no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoEsc.EliminarEscenario(Escenario.Id);
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
