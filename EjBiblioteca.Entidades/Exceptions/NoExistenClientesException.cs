using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class NoExistenClientesException : ErrorAlHacerTareaException
    {
        public NoExistenClientesException() : base("No hay clientes") { }
        public NoExistenClientesException(string msg) : base(msg) { }
    }
}
