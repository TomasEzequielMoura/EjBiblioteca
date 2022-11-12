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
            Console.Write("1. Listar Ejemplares \r\n2. Contar Ejemplares Por Libro \r\n3. Listar Ejemplares Por Libro \r\n4. Alta Ejemplar\r\n5. Modificar Ejemplar \r\n6. Listar Libros \r\n7. Listar Libro por ID \r\n8. Alta Libro \r\n9. Listar Prestamos \r\n10. Listar Prestamos por Libro \r\n11. Alta Préstamo \r\n12. Modificar Préstamo \r\n13. Baja Préstamo\r\n14. Listar Clientes \r\nX. Para salir \r\n"); 
        }
    }
}