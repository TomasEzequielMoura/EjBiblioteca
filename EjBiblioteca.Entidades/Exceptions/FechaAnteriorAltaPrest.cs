using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class FechaAnteriorAltaPrest : ErrorAlHacerTareaException
    {
        public FechaAnteriorAltaPrest() : base("La fecha de devolución no puede ser anterior a la del alta del préstamo") { }
        public FechaAnteriorAltaPrest(string msg) : base(msg) { }

    }
}
