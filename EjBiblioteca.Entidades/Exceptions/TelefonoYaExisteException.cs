using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class TelefonoYaExisteException : ErrorAlHacerTareaException
    {
        public TelefonoYaExisteException() : base("El teléfono ingresado ya existe") { }
        public TelefonoYaExisteException(string msg) : base(msg) { }
    }
}
