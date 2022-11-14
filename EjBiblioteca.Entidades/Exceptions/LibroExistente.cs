using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{

    public class LibroExistente : ErrorAlHacerTareaException
    {
        public LibroExistente() : base("Libro ya existe") { }
        public LibroExistente(string msg) : base(msg) { }
    }
}
