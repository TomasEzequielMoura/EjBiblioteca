using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EjBiblioteca.Consola.ProgramTasks;
using EjBiblioteca.Consola.ProgramHelper;

namespace EjBiblioteca.Consola
{
    class Program
    {
        public static BibliotecaNegocio InstanciaBiblioteca;

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
                            EjemplaresTasks.TraerEjemplares();
                            break;
                        case "2":
                            EjemplaresTasks.ContarEjemplaresPorLibro();
                            break;
                        case "3":
                            EjemplaresTasks.TraerEjemplaresPorLibro();
                            break;
                        case "4":
                            EjemplaresTasks.InsertarEjemplar();
                            break;
                        case "5":
                            EjemplaresTasks.ActualizarEjemplar();
                            break;
                        case "6":
                            TraerPrestamos();
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
                    Console.WriteLine("\r\nVuelva a elegir otra opcion");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\nVolver a empezar");
                    Console.WriteLine("\r\nOcurrio un error, intente mas tarde");
                }
            } while (tareaARealizar.ToUpper() != "X");
        }

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
