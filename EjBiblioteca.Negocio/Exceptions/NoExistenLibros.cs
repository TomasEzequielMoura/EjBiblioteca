using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class NoExistenLibros : ErrorAlHacerTareaException
    {
        public NoExistenLibros() : base("No hay libros") { }
        public NoExistenLibros(string msg) : base(msg) { }
    }
}
