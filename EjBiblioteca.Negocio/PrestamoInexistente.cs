using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio
{
    class PrestamoInexistente : ErrorAlHacerTareaException
    {

           public PrestamoInexistente() : base("El préstamo ingresado no existe") { }
           public PrestamoInexistente(string msg) : base(msg) { }
       
    }
}
