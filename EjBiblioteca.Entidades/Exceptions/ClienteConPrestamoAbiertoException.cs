using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class ClienteConPrestamoAbiertoException : ErrorAlHacerTareaException
    {
        public ClienteConPrestamoAbiertoException() : base("Cliente con prestamo abierto") { }
        public ClienteConPrestamoAbiertoException(string msg) : base(msg) { }
    }
}
