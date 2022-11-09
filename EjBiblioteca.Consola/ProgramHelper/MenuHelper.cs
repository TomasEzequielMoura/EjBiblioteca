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
            Console.Write("1. Listar Ejemplares \r\n2. Contar Ejemplares Por Libro \r\n3. Listar Ejemplares Por Libro \r\n4. Alta Ejemplar\r\n5. Modificar Ejemplar \r\n6. Listar Prestamos \r\n7. Listar Prestamos por Libro \r\n8. Listar Libros \r\n9. Alta Libro \r\n10. Listar Libro Por ID \r\nX. Para salir \r\n"); 
        }
    }
}