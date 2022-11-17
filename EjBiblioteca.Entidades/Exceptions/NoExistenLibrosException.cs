using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class NoExistenLibrosException : ErrorAlHacerTareaException
    {
        public NoExistenLibrosException() : base("No hay libros") { }
        public NoExistenLibrosException(string msg) : base(msg) { }
    }
}
