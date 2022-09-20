using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IREntrenador _repoEntrenador;
        private readonly IREquipo _repoEquipo;

        [BindProperty] //propiedad vinculada con el form html
        public Entrenador Entrenador { get; set; }
        public IEnumerable<Equipo> Equipos {get;set;}

        //Metodos
        //Constructor
        public EditModel(IREntrenador repoEntrenador, IREquipo repoEquipo)
        {
            this._repoEntrenador= repoEntrenador;
            this._repoEquipo=repoEquipo;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet(int id)
        {
            Entrenador=_repoEntrenador.BuscarEntrenador(id);
            Equipos=_repoEquipo.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoEntrenador.ActualizarEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Este Entrenador ya se encuentra creado";
                return Page();
            }
        }
    }
}
