using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class EdadMinimaException : ErrorAlHacerTareaException
    {
        public EdadMinimaException() : base("El cliente no puede ser menor de 12 años") { }
        public EdadMinimaException(string msg) : base(msg) { }
    }
    
}
