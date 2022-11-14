using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class EjemplarExistente : ErrorAlHacerTareaException
    {
        public EjemplarExistente() : base("El ejemplar ya existe") { }
        public EjemplarExistente(string msg) : base(msg) { }
    }
}
