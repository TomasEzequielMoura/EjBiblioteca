using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class TelefonoNoExisteException : ErrorAlHacerTareaException
    {
        public TelefonoNoExisteException() : base("El teléfono que ingresó no existe") { }
        public TelefonoNoExisteException(string msg) : base(msg) { }
    }
}
