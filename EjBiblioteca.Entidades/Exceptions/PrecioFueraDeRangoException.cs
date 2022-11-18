using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class PrecioFueraDeRangoException : ErrorAlHacerTareaException
    {
        // precio minimo es de $ 300 y el precio maximo es de $ 20000
        public PrecioFueraDeRangoException() : base("El precio es demasiado bajo o demasiado alto. Hablar con el encargado.") { }
        public PrecioFueraDeRangoException(string msg) : base(msg) { }

    }
}
