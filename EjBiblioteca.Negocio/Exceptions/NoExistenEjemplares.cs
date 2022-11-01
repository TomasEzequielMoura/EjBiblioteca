using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class NoExistenEjemplares : ErrorAlHacerTareaException
    {
        public NoExistenEjemplares() : base("No hay ejemplares") { }
        public NoExistenEjemplares(string msg) : base(msg) { }
    }
}
