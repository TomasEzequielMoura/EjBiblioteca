using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            // traemos por consola todo el listado de ejemplares

            BibliotecaNegocio biblioteca = new BibliotecaNegocio();

            Ejemplar ejemInstancia = new Ejemplar(110, "hola como estas");

            List<Ejemplar> list = biblioteca.GetTodosEjemplares();

            foreach (var item in list)
            {
                Console.WriteLine(item.Id + " " + item.IdLibro + " " + item.Observaciones + " " + item.Precio + " " + item.FechaAlta );
            }


            string asd = Console.ReadLine();

        }
    }
}
