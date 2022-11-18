using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class PrestamoCerradoException : ErrorAlHacerTareaException
    {
        public PrestamoCerradoException() : base("El prestamo que intenta modificar esta cerrado") { }
        public PrestamoCerradoException(string msg) : base(msg) { }
    }
}
