using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class TelefonoNoExiste : ErrorAlHacerTareaException
    {
        public TelefonoNoExiste() : base("El teléfono que ingresó no existe") { }
        public TelefonoNoExiste(string msg) : base(msg) { }
    }
}
