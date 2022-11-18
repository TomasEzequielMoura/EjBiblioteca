using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class LibroInexistenteException : ErrorAlHacerTareaException
    {
        public LibroInexistenteException() : base("Libro no existe") { }
        public LibroInexistenteException(string msg) : base(msg) { }
    }
}

