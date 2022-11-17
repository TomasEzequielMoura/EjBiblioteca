using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class EjemplarEnPrestamoException : ErrorAlHacerTareaException
    {

        public EjemplarEnPrestamoException() : base("Ese ejemplar esta dentro de un préstamo en curso") { }
        public EjemplarEnPrestamoException(string msg) : base(msg) { }

    }
}
