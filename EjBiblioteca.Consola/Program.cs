using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EjBiblioteca.Consola.ProgramTasks;
using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Negocio.NegocioTasks;
using EjBiblioteca.Entidades.Exceptions;

namespace EjBiblioteca.Consola
{
    class Program
    {
        public static EjemplarNegocio ejemplarServicio;
        public static LibroNegocio libroServicio;
        public static PrestamoNegocio prestamoServicio;
        public static ClienteNegocio clienteServicio;

        static void Main(string[] args)
        {
            ejemplarServicio = new EjemplarNegocio();
            libroServicio = new LibroNegocio();
            prestamoServicio = new PrestamoNegocio();
            clienteServicio = new ClienteNegocio();

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
                            EjemplaresTasks.ListarEjemplares(ejemplarServicio);
                            break;
                        case "2":
                            EjemplaresTasks.ContarEjemplaresPorLibro(ejemplarServicio);
                            break;
                        case "3":
                            EjemplaresTasks.ListarEjemplaresPorLibro(ejemplarServicio);
                            break;
                        case "4":
                            EjemplaresTasks.AltaEjemplar(ejemplarServicio);
                            break;
                        case "5":
                            EjemplaresTasks.ModificarEjemplar(ejemplarServicio);
                            break;
                        case "6":
                            LibrosTasks.ListarLibros(libroServicio);
                            break;
                        case "7":
                            LibrosTasks.ListarLibroPorID(libroServicio);
                            break;
                        case "8":
                            LibrosTasks.AltaLibro(libroServicio);
                            break;
                        case "9":
                            PrestamosTasks.ListarPrestamos(prestamoServicio);
                            break;
                        case "10":
                            PrestamosTasks.ListarPrestamosPorLibro(prestamoServicio);
                            break;
                        case "11":
                            PrestamosTasks.ListarPrestamosPorCliente(prestamoServicio);
                            break;
                        case "12":
                            PrestamosTasks.ContarPrestamosPorCliente(prestamoServicio);
                            break;
                        case "13":
                            PrestamosTasks.AltaPrestamo(prestamoServicio);
                            break;
                        case "14":
                            PrestamosTasks.ModificarPrestamo(prestamoServicio);
                            break;
                        case "15":
                            PrestamosTasks.CerrarPrestamo(prestamoServicio);
                            break;
                        case "16":
                            PrestamosTasks.BajaPrestamo(prestamoServicio);
                            break;
                        case "17":
                            ClientesTasks.ListarClientes(clienteServicio);
                            break;
                        case "18":
                            ClientesTasks.AltaCliente(clienteServicio);
                            break;
                        case "19":
                            ClientesTasks.ModificarCliente(clienteServicio);
                            break;
                        case "20":
                            ClientesTasks.BajaCliente(clienteServicio);
                            break;
                        case "21":
                            ClientesTasks.ListarClientePorTelefono(clienteServicio);
                            break;
                       // estadísticas: cantidad de préstamos por persona (promedio),  precio promedio por ejemplar
                        case "22":
                            PrestamosTasks.PromPrestamosPorCliente(prestamoServicio);
                            break;
                        case "23":
                            EjemplaresTasks.PromedioPrecioEjemplares(ejemplarServicio);
                            break;
                        case "X":
                            Console.Write("Fin del programa. Saludos!");
                            Thread.Sleep(2500);
                            break;
                        default:
                            Console.Write("ERROR. Ingresaste un valor que no existe \r\n");
                            flag = true;
                            break;
                    }
                }
                catch (ErrorAlHacerTareaException ex)
                {
                    Console.WriteLine("\r\n" + ex.Message);
                    Console.WriteLine("\r\nVuelva a intentar otra opción");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\nVolver a empezar");
                    Console.WriteLine("\r\nOcurrió un error, intente más tarde");
                }
            } while (tareaARealizar.ToUpper() != "X");
        }
    }
}