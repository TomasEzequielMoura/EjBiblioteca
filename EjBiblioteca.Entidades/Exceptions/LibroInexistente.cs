using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class LibroInexistente : ErrorAlHacerTareaException
    {
        public LibroInexistente() : base("Libro no existe") { }
        public LibroInexistente(string msg) : base(msg) { }
    }
}

