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
    public class LibrosTasks
    {
        // traemos por consola todo el listado de Libros
        public static void ListarLibros(BibliotecaNegocio bibliotecaServicio)
        {
            List<Libro> list = bibliotecaServicio.TraerTodosLibros();

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

        // instertamos el libro que estamos cargando TODO: validadores
        public static void AltaLibro(BibliotecaNegocio bibliotecaServicio)
        {
            Console.WriteLine("\r\nIngrese el titulo del Libro");
            string titulo = Console.ReadLine();
            Console.WriteLine("\r\nIngrese el autor del Libro");
            string autor = Console.ReadLine();
            int edicion = InputHelper.IngresarNumero<int>("la edición del libro");
            Console.WriteLine("\r\nIngrese la editorial del Libro");
            string editorial = Console.ReadLine();
            int paginas = InputHelper.IngresarNumero<int>("la cantidad de paginas del libro");
            Console.WriteLine("\r\nIngrese el tema del Libro");
            string tema = Console.ReadLine();

            Libro insertLibro = new Libro(titulo, autor, edicion, editorial, paginas, tema);

            Console.WriteLine("Libro cargado:\r\n" + insertLibro.ToString());
            string confirmacion = InputHelper.confirmacionABM("libro", "insertar");

            if (confirmacion == "S" || confirmacion == "s") {
                bibliotecaServicio.InsertarLibro(insertLibro);

                Console.WriteLine("\r\nLibro Insertado!\r\nResultado final:\r\n" + insertLibro.ToString());
            }
        }

        // traemos por consola todo un libro dependiendo ID ingresado
        public static void ListarLibroPorID(BibliotecaNegocio bibliotecaServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del libro");

            Libro libroEncontrado = bibliotecaServicio.TraerLibroPorID(id);

            Console.WriteLine("\r\nLibro con " + id + " encontrado!\r\nResultado final:\r\n" + libroEncontrado.ToString());
        }
    }
}
