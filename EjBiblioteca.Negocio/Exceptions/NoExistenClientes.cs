using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio.Exceptions
{
    public class NoExistenClientes : ErrorAlHacerTareaException
    {
        public NoExistenClientes() : base("No hay clientes") { }
        public NoExistenClientes(string msg) : base(msg) { }
    }
}
