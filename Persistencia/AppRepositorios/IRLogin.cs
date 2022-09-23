using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRLogin
    {
        public bool CrearLogin(Login login);
        public bool Validar(Login login);
    }
}