using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class FechaAnteriorAltaPrestamoException : ErrorAlHacerTareaException
    {
        public FechaAnteriorAltaPrestamoException() : base("La fecha de devolución no puede ser anterior a la del alta del préstamo") { }
        public FechaAnteriorAltaPrestamoException(string msg) : base(msg) { }

    }
}
