using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class EjemplarInexistenteException : ErrorAlHacerTareaException
    {
        public EjemplarInexistenteException() : base("El ejemplar no existe") { }
        public EjemplarInexistenteException(string msg) : base(msg) { }
    }

   
}
