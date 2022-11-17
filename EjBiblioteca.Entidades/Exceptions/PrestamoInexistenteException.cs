using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio
{
    public class PrestamoInexistenteException : ErrorAlHacerTareaException
    {

           public PrestamoInexistenteException() : base("El préstamo ingresado no existe") { }
           public PrestamoInexistenteException(string msg) : base(msg) { }
       
    }
}
