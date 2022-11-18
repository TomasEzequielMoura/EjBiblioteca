using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{

    public class LibroExistenteException : ErrorAlHacerTareaException
    {
        public LibroExistenteException() : base("El libro ya existe") { }
        public LibroExistenteException(string msg) : base(msg) { }
    }
}
