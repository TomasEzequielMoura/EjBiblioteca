using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{

    public class NoHayEjemplaresParaLibroException : ErrorAlHacerTareaException
    {
        public NoHayEjemplaresParaLibroException() : base("El libro ingresado no contiene ningun ejemplar") { }
        public NoHayEjemplaresParaLibroException(string msg) : base(msg) { }
    }
}
