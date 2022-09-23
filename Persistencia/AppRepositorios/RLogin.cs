using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RLogin:IRLogin //: operador de herencia entre clases
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RLogin(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearLogin(Login log)
        {
            bool creado=false;
            try
            {
                this._appContext.Logins.Add(log);
                this._appContext.SaveChanges();
                creado=true;
            }
            catch (System.Exception)
            {
                creado=false;
            }
            return creado;
        }
        
        public bool Validar(Login log)
        {
            bool valido= false;
            var user=_appContext.Logins.FirstOrDefault(l=> l.Usuario== log.Usuario && l.Password == log.Password);
            if(user !=null)
            {
                valido=true;
            }
            return valido;
        }
    }
}