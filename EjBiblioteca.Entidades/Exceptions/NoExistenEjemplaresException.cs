using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class NoExistenEjemplaresException : ErrorAlHacerTareaException
    {
        public NoExistenEjemplaresException() : base("No hay ejemplares") { }
        public NoExistenEjemplaresException(string msg) : base(msg) { }
    }
}
