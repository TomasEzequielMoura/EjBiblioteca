using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola
{
    public static class MenuHelper
    {

        public static void DesplegarBienvenida()
        {
            Console.Write("Bienvenido al Sistema de VentaRepuestos \r\n");
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.Write("\r\nPara continuar, presione el boton correspondiente y precione Enter: \r\n");
            Console.Write("1. TraerEjemplares \r\n2. TraerEjemplaresPorLibro \r\nX. Para salir \r\n");
        }
    }
}
