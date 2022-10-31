using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class EjemplarYaExistente : ErrorAlHacerTareaException
    {
        public EjemplarYaExistente() : base("El ejemplar ya existe") { }
        public EjemplarYaExistente(string msg) : base(msg) { }
    }
}
