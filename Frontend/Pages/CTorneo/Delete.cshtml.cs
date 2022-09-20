using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneo
{
    public class DeleteModel : PageModel
    {
        private readonly IRTorneo _repoTorneo;
        private readonly IRMunicipio _repoMunicipio;

        [BindProperty]
        public Torneo Torneo {get;set;}
        public Municipio Municipio {get;set;}

        public DeleteModel(IRTorneo repoTor, IRMunicipio repoMun)
        {
            this._repoTorneo= repoTor;
            this._repoMunicipio= repoMun;
        }
        public ActionResult OnGet(int id)
        {
            Torneo= _repoTorneo.BuscarTorneo(id);
            Municipio= _repoMunicipio.BuscarMunicipio(Torneo.MunicipioId);

            if(Torneo!=null && Municipio!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Torneo no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoTorneo.EliminarTorneo(Torneo.Id);
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
