using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class CreateModel : PageModel
    {
       //Atributos
        private readonly IRColegio _repoColegio;

        [BindProperty] //propiedad vinculada con el form html
        public Colegio Colegio {get; set;}

        //Metodos
        //Constructor
        public CreateModel(IRColegio repoColegio)
        {
            this._repoColegio= repoColegio;
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
            bool funciono= _repoColegio.CrearColegio(Colegio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "Este Colegio ya se encuentra creado";
                return Page();
            }
        }
    }
}
