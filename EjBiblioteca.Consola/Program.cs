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
        public static BibliotecaNegocio bibliotecaServicio;

        static void Main(string[] args)
        {
            bibliotecaServicio = new BibliotecaNegocio();

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
                            EjemplaresTasks.ListarEjemplares(bibliotecaServicio);
                            break;
                        case "2":
                            EjemplaresTasks.ContarEjemplaresPorLibro(bibliotecaServicio);
                            break;
                        case "3":
                            EjemplaresTasks.ListarEjemplaresPorLibro(bibliotecaServicio);
                            break;
                        case "4":
                            EjemplaresTasks.AltaEjemplar(bibliotecaServicio);
                            break;
                        case "5":
                            EjemplaresTasks.ModificarEjemplar(bibliotecaServicio);
                            break;
                        case "6":
                            PrestamosTasks.ListarPrestamos(bibliotecaServicio);
                            break;
                        case "7":
                            PrestamosTasks.ListarPrestamosPorLibro(bibliotecaServicio);
                            break;
                        case "8":
                            LibrosTasks.ListarLibros(bibliotecaServicio);
                            break;
                        case "9":
                            LibrosTasks.AltaLibro(bibliotecaServicio);
                            break;
                        case "10":
                            LibrosTasks.ListarLibroPorID(bibliotecaServicio);
                            break;
                        case "11":
                            PrestamosTasks.AltaPrestamo(bibliotecaServicio);
                            break;
                        case "12":
                            PrestamosTasks.ModificarPrestamo(bibliotecaServicio);
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
                    Console.WriteLine("\r\nVuelva a elegir otra opcion");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\nVolver a empezar");
                    Console.WriteLine("\r\nOcurrio un error, intente mas tarde");
                }
            } while (tareaARealizar.ToUpper() != "X");
        }
    }
}
