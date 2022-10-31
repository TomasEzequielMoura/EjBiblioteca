using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class EjemplarInexistente : ErrorAlHacerTareaException
    {
        public EjemplarInexistente() : base("El ejemplar no existe") { }
        public EjemplarInexistente(string msg) : base(msg) { }
    }
}
