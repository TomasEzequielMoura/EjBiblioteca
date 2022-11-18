using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class ClienteYaExisteException : ErrorAlHacerTareaException
    {

        public ClienteYaExisteException() : base("El cliente que intenta dar de alta ya existe") { }
        public ClienteYaExisteException(string msg) : base(msg) { }

    }
}
