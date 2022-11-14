using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Exceptions
{
    public class ClienteYaExiste : ErrorAlHacerTareaException
    {

        public ClienteYaExiste() : base("El cliente que intenta dar de alta ya existe") { }
        public ClienteYaExiste(string msg) : base(msg) { }

    }
}
