using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class FechaMayorActualException : ErrorAlHacerTareaException
    {
        public FechaMayorActualException() : base("La fecha no puede ser mayor a la actual " + DateTime.Today) { }
        public FechaMayorActualException(string msg) : base(msg) { }
    }
}
