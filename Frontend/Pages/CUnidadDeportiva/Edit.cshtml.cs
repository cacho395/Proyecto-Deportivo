using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRUnidadDeportiva _repoUnd;
        private readonly IRTorneo _repoTor;

        [BindProperty] //propiedad vinculada con el form html
        public UnidadDeportiva UnidadDeportiva { get; set; }
        public IEnumerable<Torneo> Torneos {get;set;}

        //Metodos
        //Constructor
        public EditModel(IRUnidadDeportiva repoUnd, IRTorneo repoTor)
        {
            this._repoUnd= repoUnd;
            this._repoTor= repoTor;
        }


        //enviar informacion o vistas al usuario
        public ActionResult OnGet(int id)
        {
            UnidadDeportiva=_repoUnd.BuscarUnidadDeportiva(id);
            Torneos=_repoTor.ListarTorneos();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoUnd.ActualizarUnidadDeportiva(UnidadDeportiva);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Torneos=_repoTor.ListarTorneos();
                ViewData["Error"]= "NO es posible actualizar esta Unidad Deportiva";
                return Page();
            }
        }
    }
}
