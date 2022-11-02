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
            Console.Write("Bienvenido al Sistema de la Biblioteca General Jeremias Springfield \r\n");
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.Write("\r\nPara continuar, presione el boton correspondiente y precione Enter: \r\n");
            Console.Write("1. TraerEjemplares \r\n2. ContarEjemplaresPorLibro \r\n3. TraerEjemplaresPorLibro \r\n4. InsertarEjemplar\r\n5. ActualizarEjemplar \r\n6. TraerPrestamos \r\nX. Para salir \r\n");
        }
    }
}