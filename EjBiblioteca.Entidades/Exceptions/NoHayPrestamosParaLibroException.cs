using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{

    public class NoHayPrestamosParaLibroException : ErrorAlHacerTareaException
    {
        public NoHayPrestamosParaLibroException() : base("No hay prestamos para el libro ingresado") { }
        public NoHayPrestamosParaLibroException(string msg) : base(msg) { }
    }

}
