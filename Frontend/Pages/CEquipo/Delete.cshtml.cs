using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class DeleteModel : PageModel
    {
       private readonly IREquipo _repoEquipo;
        private readonly IRPatrocinador _repoPat;

        [BindProperty]
        public Equipo Equipo {get;set;}
        public Patrocinador Patrocinador {get;set;}

        //Constructor

        public DeleteModel(IREquipo repoEquipo, IRPatrocinador repoPat)
        {
            this._repoEquipo= repoEquipo;
            this._repoPat= repoPat;
        }
        public ActionResult OnGet(int id)
        {
            Equipo= _repoEquipo.BuscarEquipo(id);
            Patrocinador= _repoPat.BuscarPatrocinador(Equipo.PatrocinadorId);

            if(Equipo!=null && Patrocinador!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Equipo no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoEquipo.EliminarEquipo(Equipo.Id);
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
