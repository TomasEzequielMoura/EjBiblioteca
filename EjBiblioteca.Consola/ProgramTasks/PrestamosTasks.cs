using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramTasks
{
    public class PrestamosTasks
    {
        //se consulta el listado completo de prestamos
        public static void ListarPrestamos(BibliotecaNegocio bibliotecaServicio)
        {
            List<Prestamo> listprestamos = bibliotecaServicio.TraerPrestamos();

            Console.WriteLine("\r\nLista de Préstamos:");

            if (listprestamos.Count > 0)
            {
                foreach (var item in listprestamos)
                {
                    Console.WriteLine(item.Id + " " + item.IdCliente + " " + item.IdEjemplar + " " + item.Plazo + " " + item.FechaPrestamo + " " + item.FechaDevolucionTentativa + " " + item.FechaDevolucionReal);
                }
            }
            else
            {
                Console.WriteLine("\r\nNo se han encontrado préstamos");
            }
        }

        //Consultar los préstamos por libro
        public static void ListarPrestamosPorLibro(BibliotecaNegocio bibliotecaServicio)
        {
            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");

            List<Prestamo> list = bibliotecaServicio.TraerTodosPrestamosPorLibro();

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Prestamo", "ID Cliente", "ID Ejemplar", "Plazo", "Fecha Prestamo", "Fecha Devolución Tentativa", "Fecha Devolución Real");
            OutputHelper.PrintLine();

            if (list.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.IdCliente.ToString(), item.IdEjemplar.ToString(), item.Plazo.ToString(), item.FechaPrestamo.ToString(), item.FechaDevolucionTentativa.ToString(), item.FechaDevolucionReal.ToString());
                }
                OutputHelper.PrintLine();
            }
            else
            {
                Console.WriteLine("\r\nNo se ha encontrado ningun préstamo para el ID: " + idLibro);
            }
        }
    }
}
