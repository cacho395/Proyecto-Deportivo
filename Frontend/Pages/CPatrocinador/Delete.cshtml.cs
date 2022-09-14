using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador _repoPatrocinador;

        [BindProperty]
        public Patrocinador Patrocinador {get;set;}

        //Metodos
        //Constructor

        public DeleteModel(IRPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador= repoPatrocinador;
        }

        public ActionResult OnGet(int id)
        {
            Patrocinador= _repoPatrocinador.BuscarPatrocinador(id);
            if(Patrocinador== null)
            {
                ViewData["Error"]="Patrocinador no encontrado";
                return Page();
            }
            return Page();

        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoPatrocinador.EliminarPatrocinador(Patrocinador.Id);
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
