using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class ClienteInexistenteException : ErrorAlHacerTareaException
    {

        public ClienteInexistenteException() : base("El cliente ingresado no existe") { }
        public ClienteInexistenteException(string msg) : base(msg) { }

    }
}
