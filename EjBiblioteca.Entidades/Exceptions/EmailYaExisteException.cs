using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class EmailYaExisteException : ErrorAlHacerTareaException
    {
        public EmailYaExisteException() : base("El email que ingresó ya se encuentra registrado") { }
        public EmailYaExisteException(string msg) : base(msg) { }
    }
}
