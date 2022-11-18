using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class EjemplarExistenteException : ErrorAlHacerTareaException
    {
        public EjemplarExistenteException() : base("El ejemplar ya existe") { }
        public EjemplarExistenteException(string msg) : base(msg) { }
    }
}
