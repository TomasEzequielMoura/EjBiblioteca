﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class NoHayPrestamosParaClienteException : ErrorAlHacerTareaException
    {
        public NoHayPrestamosParaClienteException() : base("No hay prestamos para cliente") { }
        public NoHayPrestamosParaClienteException(string msg) : base(msg) { }
    }
}
