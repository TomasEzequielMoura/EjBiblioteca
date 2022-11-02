using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramTasks
{
    public class EjemplaresTasks
    {
        // traemos por consola todo el listado de ejemplares
        public static void TraerEjemplares()
        {
            List<Ejemplar> list = Program.InstanciaBiblioteca.TraerTodosEjemplares();

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            Console.WriteLine("\r\nLista de Ejemplares:");

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Ejemplar", "ID Libro", "Observaciones", "Precio", "Fecha Alta");
            OutputHelper.PrintLine();

            if (list.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.IdLibro.ToString(), item.Observaciones, item.Precio.ToString(), item.FechaAlta.ToString());
                }
                OutputHelper.PrintLine();
            }
            else
                throw new NoExistenEjemplares();
        }

        public static void ContarEjemplaresPorLibro()
        {
            int count = 0;

            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");

            List<Ejemplar> list = Program.InstanciaBiblioteca.TraerTodosEjemplares();

            foreach (var item in list)
            {
                if (item.IdLibro == idLibro) count++;
            }

            if (count > 0)
                Console.WriteLine("\r\nEl libro con id " + idLibro + " tiene " + count + " ejemplares\r\n");
            else
                Console.WriteLine("\r\nNo se ha encontrado ningun ejemplar para el libro con ID: " + idLibro);
        }

        // traemos por consola todo el listado de ejemplares para un libro
        public static void TraerEjemplaresPorLibro()
        {
            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");

            List<Ejemplar> list = Program.InstanciaBiblioteca.TraerTodosLosEjemplaresPorLibro(Convert.ToInt32(idLibro));

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Ejemplar", "ID Libro", "Observaciones", "Precio", "Fecha Alta");
            OutputHelper.PrintLine();

            if (list.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.IdLibro.ToString(), item.Observaciones, item.Precio.ToString(), item.FechaAlta.ToString());
                }
                OutputHelper.PrintLine();
            }
            else
            {
                Console.WriteLine("\r\nNo se ha encontrado ningun ejemplar para el libro con ID: " + idLibro);
            }
        }

        public static void InsertarEjemplar()
        {
            //int id = InputHelper.IngresarNumero<int>("el numero del ejemplar");
            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");
            Console.WriteLine("\r\nIngrese las observaciones del ejemplar");
            string observaciones = Console.ReadLine();
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");
            DateTime fechaAlta = InputHelper.IngresarFechaPasoAPaso();

            Ejemplar instanciaEjemplarInsert = new Ejemplar(idLibro, observaciones, precio, fechaAlta);

            Program.InstanciaBiblioteca.AltaEjemplar(instanciaEjemplarInsert);

            Console.WriteLine("\r\nEjemplar Insertado!\r\nResultado final:" + "\r\nId Libro: " + idLibro + "\r\nObservaciones: " + observaciones + "\r\nPrecio: " + precio + "\r\nFecha Alta: " + fechaAlta);
        }

        public static void ActualizarEjemplar()
        {
            int id = InputHelper.IngresarNumero<int>("el numero del ejemplar");
            Console.WriteLine("\r\nIngrese las observaciones del ejemplar");
            string observaciones = Console.ReadLine();
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");

            Ejemplar instanciaEjemplarInsert = new Ejemplar(id, observaciones, precio);

            Program.InstanciaBiblioteca.ModificarEjemplar(instanciaEjemplarInsert);

            Console.WriteLine("\r\nEjemplar " + id + " modificado!\r\n\r\nResultado final:\r\nId Ejemplar: " + id + "\r\nObservaciones: " + observaciones + "\r\nPrecio: " + precio);
        }
    }
}
