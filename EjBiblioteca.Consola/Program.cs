using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola
{
    class Program
    {
        public static BibliotecaNegocio InstanciaBiblioteca;

        // Tomas

        //Instancia de ejemplo para arrancar
        Ejemplar ejemInstancia = new Ejemplar(110, "hola como estas");

        static void Main(string[] args)
        {

            InstanciaBiblioteca = new BibliotecaNegocio();

            MenuHelper.DesplegarBienvenida();
            string tareaARealizar = "";

            do
            {
                try
                {
                    bool flag = false;

                    MenuHelper.DesplegarOpcionesMenu();
                    tareaARealizar = Console.ReadLine();

                    switch (tareaARealizar.ToUpper())
                    {
                        case "1":
                            TraerEjemplares();
                            break;
                        case "2":
                            TraerEjemplaresPorLibro();
                            break;
                        case "X":
                            Console.Write("Fin del programa. Saludos!");
                            Thread.Sleep(2500);
                            break;
                        default:
                            Console.Write("\r\nERROR. Ingresaste un valor que no existe \r\n");
                            flag = true;
                            break;
                    }
                }
                //catch (ErrorAlHacerTareaException ex)
                //{
                //    Console.WriteLine("\r\nVolver a empezar");
                //    Console.WriteLine("\r\n" + ex.Message);
                //}
                catch (Exception ex)
                {
                    Console.WriteLine("\r\nVolver a empezar");
                    Console.WriteLine("\r\n" + ex.Message);
                    Console.WriteLine("\r\nOcurrio un error, intente mas tarde");
                }
            } while (tareaARealizar.ToUpper() != "X");
        }

        // traemos por consola todo el listado de ejemplares
        public static void TraerEjemplares()
        {
            List<Ejemplar> list = InstanciaBiblioteca.TraerTodosEjemplares();

            foreach (var item in list)
            {
                Console.WriteLine(item.Id + " " + item.IdLibro + " " + item.Observaciones + " " + item.Precio + " " + item.FechaAlta);
            }

        }

        // traemos por consola todo el listado de ejemplares para un libro
        public static void TraerEjemplaresPorLibro()
        {
            int idLibro = ValidarHelper.IngresarNumero<int>("el numero del libro");

            List<Ejemplar> list = InstanciaBiblioteca.TraerTodosLosEjemplaresPorLibro(Convert.ToInt32(idLibro));

            foreach (var item in list)
            {
                Console.WriteLine(item.Id + " " + item.IdLibro + " " + item.Observaciones + " " + item.Precio + " " + item.FechaAlta);
            }

        }


        // Sabri





        // Juanse




    }
}
