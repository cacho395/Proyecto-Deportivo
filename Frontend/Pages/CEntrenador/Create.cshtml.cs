using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IREntrenador _repoEntrenador;
        private readonly IREquipo _repoEquipo;

        [BindProperty] //propiedad vinculada con el form html
        public Entrenador Entrenador { get; set; }
        public IEnumerable<Equipo> Equipos {get;set;}

        //Metodos
        //Constructor
        public CreateModel(IREntrenador repoEntrenador, IREquipo repoEquipo)
        {
            this._repoEntrenador= repoEntrenador;
            this._repoEquipo=repoEquipo;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            Equipos=_repoEquipo.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoEntrenador.CrearEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Equipos=_repoEquipo.ListarEquipos();
                ViewData["Error"]= "Este Entrenador ya se encuentra creado";
                return Page();
            }
        }
    }
}
