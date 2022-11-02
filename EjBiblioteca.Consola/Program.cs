using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using EjBiblioteca.Negocio.Exceptions;
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
                        case "3":
                            InsertarEjemplar();
                            break;
                        case "4":
                            ActualizarEjemplar();
                            break;
                        case "5":
                            //ContarEjemplaresPorLibro();
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
                catch (ErrorAlHacerTareaException ex)
                {
                    Console.WriteLine("\r\n" + ex.Message);
                    Console.WriteLine("\r\nGenere otra consuta");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\nVolver a empezar");
                    Console.WriteLine("\r\nOcurrio un error, intente mas tarde");
                }
            } while (tareaARealizar.ToUpper() != "X");
        }

        // traemos por consola todo el listado de ejemplares
        public static void TraerEjemplares()
        {
            List<Ejemplar> list = InstanciaBiblioteca.TraerTodosEjemplares();

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

        // traemos por consola todo el listado de ejemplares para un libro
        public static void TraerEjemplaresPorLibro()
        {
            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");

            List<Ejemplar> list = InstanciaBiblioteca.TraerTodosLosEjemplaresPorLibro(Convert.ToInt32(idLibro));

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
                Console.WriteLine("\r\nNo se ha encontrado ningun ejemplar para el ID: " + idLibro);
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

            InstanciaBiblioteca.AltaEjemplar(instanciaEjemplarInsert);

            Console.WriteLine("\r\nEjemplar Insertado!\r\nResultado final:" + "\r\nId Libro: " + idLibro + "\r\nObservaciones: " + observaciones + "\r\nPrecio: " + precio + "\r\nFecha Alta: " + fechaAlta);
        }

        public static void ActualizarEjemplar()
        {
            int id = InputHelper.IngresarNumero<int>("el numero del ejemplar");
            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");
            Console.WriteLine("\r\nIngrese las observaciones del ejemplar");
            string observaciones = Console.ReadLine();
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");

            Ejemplar instanciaEjemplarInsert = new Ejemplar(id, idLibro, observaciones, precio);

            InstanciaBiblioteca.ActualizarEjemplar(instanciaEjemplarInsert);

            Console.WriteLine("\r\nEjemplar " + id + " modificado!\r\nResultado final:\r\nId Ejemplar: " + id + "\r\nId Libro: " + idLibro + "\r\nObservaciones: " + observaciones + "\r\nPrecio: " + precio);
        }

        //public static void ContarEjemplaresPorLibro()
        //{
        //    List<Ejemplar> list = InstanciaBiblioteca.TraerTodosEjemplares();

        //    var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

        //    var results = listaOrdenadaPorId.GroupBy(
        //        p => p.IdLibro,
        //        p => p.Id,
        //        (key, g) => new { IdLibro = key, Id = g.ToList() });

        //    Console.WriteLine(results);
        //}

        // Sabri


        //se consulta el listado completo de prestamos
        public static void TraerPrestamos()
        {
            List<Prestamo> listprestamos = InstanciaBiblioteca.TraerPrestamos();

            Console.WriteLine("\r\nLista de Préstamos:");

            if (listprestamos.Count > 0)
            {
                foreach (var item in listprestamos)
                {
                    Console.WriteLine(item.Id + " " + item.IdCliente + " " + item.IdEjemplar + " " + item.Plazo + " " + item.FechaAlta + " " + item.FechaBaja + " " + item.FechaBajaReal);
                }
            }
            else
            {
                Console.WriteLine("\r\nNo se han encontrado préstamos");
            }
        }



        // Juanse




    }
}
