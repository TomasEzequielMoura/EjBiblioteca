using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class FechaInvalida : ErrorAlHacerTareaException
    {
        public FechaInvalida() : base("La fecha ingresada es inválida") { }
        public FechaInvalida(string msg) : base(msg) { }
    }
}
