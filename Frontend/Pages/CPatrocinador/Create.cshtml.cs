using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador _repoPatrocinador;

        [BindProperty] //propiedad vinculada con el form html
        public Patrocinador Patrocinador { get; set; }

        //Metodos
        //Constructor
        public CreateModel(IRPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador= repoPatrocinador;
        }

        //enviar informacion o vistas al usuario
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            /*if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoPatrocinador.CrearPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Este Patrocinador ya se encuentra creado";
                return Page();
            }
        }
    }
}
