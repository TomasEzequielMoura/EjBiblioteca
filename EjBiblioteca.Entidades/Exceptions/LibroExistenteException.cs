using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{

    public class LibroExistenteException : ErrorAlHacerTareaException
    {
        public LibroExistenteException() : base("El libro ya existe") { }
        public LibroExistenteException(string msg) : base(msg) { }
    }
}
