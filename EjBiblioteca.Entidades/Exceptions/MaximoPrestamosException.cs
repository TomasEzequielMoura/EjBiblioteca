using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class MaximoPrestamosException : ErrorAlHacerTareaException
    {
        public MaximoPrestamosException() : base("Un mismo cliente no puede tener mas de 5 préstamos") { }
        public MaximoPrestamosException(string msg) : base(msg) { }
    }
}
