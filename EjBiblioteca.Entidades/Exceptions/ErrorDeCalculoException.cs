using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class ErrorDeCalculoException : ErrorAlHacerTareaException
    {
            public ErrorDeCalculoException() : base("ERROR. No se puede hacer el cálculo solicitado") { }
            public ErrorDeCalculoException(string msg) : base(msg) { }
        
    }
}
