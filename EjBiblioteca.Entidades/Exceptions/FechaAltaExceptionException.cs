using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{

    public class FechaAltaExceptionException : ErrorAlHacerTareaException
    {
        public FechaAltaExceptionException() : base("Fecha de alta no puede ser anterior a la de inicio de actividades (01/07/2019)") { }
        public FechaAltaExceptionException(string msg) : base(msg) { }
    }
}
