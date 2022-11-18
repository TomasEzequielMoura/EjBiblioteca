using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public abstract class ErrorAlHacerTareaException : Exception
    {
        public ErrorAlHacerTareaException() : base("Error general al hacer la tarea") { }
        public ErrorAlHacerTareaException(string msg) : base(msg) { }
    }
}
