using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class EditModel : PageModel
    {
    private readonly IRPatrocinador _repoPatrocinador;

        [BindProperty]
        public Patrocinador Patrocinador { get; set; }

        public EditModel(IRPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador= repoPatrocinador;
        }
        public ActionResult OnGet(int id)
        {
            Patrocinador= _repoPatrocinador.BuscarPatrocinador(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoPatrocinador.ActualizarPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "No se puede actualizar este patrocinador";
                return Page();
            }
        }
    }
}
