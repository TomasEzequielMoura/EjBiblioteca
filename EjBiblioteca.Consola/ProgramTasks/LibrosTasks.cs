using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using EjBiblioteca.Negocio.Enum;
using EjBiblioteca.Entidades.Exceptions;
using EjBiblioteca.Negocio.NegocioTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramTasks
{
    public class LibrosTasks
    {
        // traemos por consola todo el listado de Libros
        public static void ListarLibros(LibroNegocio libroServicio)
        {
            List<Libro> list = libroServicio.TraerTodosLibros();

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            Console.WriteLine("\r\nLista de Libros:");

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Libro", "Titulo", "Autor", "Edicion", "Editorial", "Paginas", "Tema");
            OutputHelper.PrintLine();

            foreach (var item in listaOrdenadaPorId)
            {
                OutputHelper.PrintLine();
                OutputHelper.PrintRow(item.Id.ToString(), item.Titulo, item.Autor, item.Edicion.ToString(), item.Editorial, item.Paginas.ToString(), item.Tema);
            }
            OutputHelper.PrintLine();
        }

        public static void AltaLibro(LibroNegocio libroServicio)
        {
            Console.WriteLine("\r\nIngrese el titulo del Libro");
            string titulo = Console.ReadLine();
            string autor = InputHelper.IngresarStringYNumeros("el autor del Libro");
            int edicion = InputHelper.IngresarNumero<int>("la edición del libro");
            string editorial = InputHelper.IngresarStringYNumeros("la editorial del Libro");
            int paginas = InputHelper.IngresarNumero<int>("la cantidad de paginas del libro");

            Console.WriteLine("\r\nA continuación, se muestran los temas que le puede asignar a su libro");
            Console.WriteLine($"{(TemasLibro.Tema)1} = 1,\r\n" +
                $"{(TemasLibro.Tema)2} = 2,\r\n" +
                $"{(TemasLibro.Tema)3} = 3,\r\n" +
                $"{(TemasLibro.Tema)4} = 4,\r\n" +
                $"{(TemasLibro.Tema)5} = 5,\r\n" +
                $"{(TemasLibro.Tema)6} = 6,\r\n" +
                $"{(TemasLibro.Tema)7} = 7,\r\n" +
                $"{(TemasLibro.Tema)8} = 8"
              );

            int tema;

            do
            {
                tema = InputHelper.IngresarNumero<int>("el número que corresponda al tema del libro");

                if (tema < 1 || tema > (Enum.GetNames(typeof(TemasLibro.Tema)).Length))
                    Console.WriteLine("\r\nEl numero ingresado no corresponde con las opciones mostradas");
            } while (tema < 1 || tema > Enum.GetNames(typeof(TemasLibro.Tema)).Length);

            Libro insertLibro = new Libro(titulo, autor, edicion, editorial, paginas, Enum.GetName(typeof(TemasLibro.Tema), tema));

            Console.WriteLine("\r\nLibro cargado:\r\n" + insertLibro.ToString());
            string confirmacion = InputHelper.confirmacionABM("libro", "insertar");

            if (confirmacion == "S" || confirmacion == "s") {
                libroServicio.InsertarLibro(insertLibro);
                Console.WriteLine("\r\nLibro Insertado!\r\nResultado final:\r\n" + insertLibro.ToString());
            }
        }

        // traemos por consola todo un libro dependiendo ID ingresado
        public static void ListarLibroPorID(LibroNegocio libroServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del libro");

            Libro libroEncontrado = libroServicio.TraerLibroPorID(id);

            Console.WriteLine("\r\nLibro con " + id + " encontrado!\r\nResultado final:\r\n" + libroEncontrado.ToString());
        }
    }
}
