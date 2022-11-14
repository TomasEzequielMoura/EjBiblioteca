using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class ClienteInexistente : ErrorAlHacerTareaException
    {

        public ClienteInexistente() : base("El cliente ingresado no existe") { }
        public ClienteInexistente(string msg) : base(msg) { }

    }
}
