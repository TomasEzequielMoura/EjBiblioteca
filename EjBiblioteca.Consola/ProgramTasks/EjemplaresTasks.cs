using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio.NegocioTasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjBiblioteca.Consola.ProgramTasks
{
    public class EjemplaresTasks
    {
        // traemos por consola todo el listado de ejemplares
        public static void ListarEjemplares(EjemplarNegocio ejemplarServicio)
        {
            List<Ejemplar> list = ejemplarServicio.TraerTodosEjemplares();

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            Console.WriteLine("\r\nLista de Ejemplares:");

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Ejemplar", "ID Libro", "Observaciones", "Precio", "Fecha Alta");
            OutputHelper.PrintLine();

            foreach (var item in listaOrdenadaPorId)
            {
                OutputHelper.PrintLine();
                OutputHelper.PrintRow(item.Id.ToString(), item.IdLibro.ToString(), item.Observaciones, item.Precio.ToString("$ 0.00"), item.FechaAlta.ToString("dd/MM/yyyy"));
            }
            OutputHelper.PrintLine();
        }

        public static void ContarEjemplaresPorLibro(EjemplarNegocio ejemplarServicio)
        {
            int count = 0;

            int idLibro = InputHelper.IngresarNumero<int>("el ID del libro");

            List<Ejemplar> list = ejemplarServicio.TraerTodosEjemplares();

            foreach (var item in list)
            {
                if (item.IdLibro == idLibro) count++;
            }

            if (count > 0)
                Console.WriteLine("\r\nEl libro con ID " + idLibro + " tiene " + count + " ejemplares\r\n");
            else
                Console.WriteLine("\r\nNo se ha encontrado ningun ejemplar para el libro con ID: " + idLibro);
        }

        public static void PromedioPrecioEjemplares(EjemplarNegocio ejemplarServicio)
        {
            int count = 0;
            double totalPrecio = 0;
            double prom = 0;

            List <Ejemplar> list = ejemplarServicio.TraerTodosEjemplares();
           
            //totalPrecio = list.Sum(item => item.Precio);
            
            foreach (var item in list)
            {
                totalPrecio = totalPrecio + item.Precio;
                count++;
            }
            if (count > 0)
            {
                prom = totalPrecio / count;
                Console.WriteLine("\r\nEl precio promedio por ejemplar es: " + prom.ToString("$ 0.00"));
            }
            else
            {
                Console.WriteLine("\r\nNo hay ejemplares dados de alta");
            }
            
            //calculamos el precio promedio por ejemplar para mostrarlo como estadistica
            
        }

        // traemos por consola todo el listado de ejemplares para un libro
        public static void ListarEjemplaresPorLibro(EjemplarNegocio ejemplarServicio)
        {
            int idLibro = InputHelper.IngresarNumero<int>("el ID del libro");

            List<Ejemplar> list = ejemplarServicio.TraerTodosLosEjemplaresPorLibro(idLibro);

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Ejemplar", "ID Libro", "Observaciones", "Precio", "Fecha Alta");
            OutputHelper.PrintLine();

            foreach (var item in listaOrdenadaPorId)
            {
                OutputHelper.PrintLine();
                OutputHelper.PrintRow(item.Id.ToString(), item.IdLibro.ToString(), item.Observaciones, item.Precio.ToString("$ 0.00"), item.FechaAlta.ToString("dd/MM/yyyy"));
            }
            OutputHelper.PrintLine();
        }

        public static void AltaEjemplar(EjemplarNegocio ejemplarServicio)
        {
            int idLibro = InputHelper.IngresarNumero<int>("el ID del libro");
            string observaciones = InputHelper.IngresarStringYNumeros("las observaciones del ejemplar");
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");
            DateTime fechaAlta = InputHelper.IngresarFechaPasoAPaso(" de alta del ejemplar");

            Ejemplar insertEjemplar = new Ejemplar(idLibro, observaciones, precio, fechaAlta);

            Console.WriteLine("\r\nEjemplar cargado:\r\n" + insertEjemplar.ToString());
            string confirmacion = InputHelper.confirmacionABM("ejemplar", "insertar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                ejemplarServicio.InsertarEjemplar(insertEjemplar);

                Console.WriteLine("\r\nEjemplar Insertado!\r\nResultado final:\r\n" + insertEjemplar.ToString());
            }
        }

        public static void ModificarEjemplar(EjemplarNegocio ejemplarServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del ejemplar");
            string observaciones = InputHelper.IngresarStringYNumeros("las observaciones del ejemplar");
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");
            Ejemplar modificarEjemplar = new Ejemplar(id, observaciones, precio);

            Console.WriteLine("\r\nEjemplar cargado:\r\n" + modificarEjemplar.ToString());
            string confirmacion = InputHelper.confirmacionABM("ejemplar", "actualizar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                ejemplarServicio.ActualizarEjemplar(modificarEjemplar);

                Console.WriteLine("\r\nEjemplar " + id + " modificado!\r\n\r\nResultado final:\r\n" + modificarEjemplar.ToString());
            }
        }
    }
}
