using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class FechaInvalidaException : ErrorAlHacerTareaException
    {
        public FechaInvalidaException() : base("La fecha ingresada es inválida") { }
        public FechaInvalidaException(string msg) : base(msg) { }
    }
}
