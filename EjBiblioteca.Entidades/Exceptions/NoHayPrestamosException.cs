using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class NoHayPrestamosException : ErrorAlHacerTareaException
    {
        public NoHayPrestamosException() : base("No hay prestamos otorgados por el momento.") { }
        public NoHayPrestamosException(string msg) : base(msg) { }
    }

}
