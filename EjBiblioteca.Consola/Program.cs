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
using EjBiblioteca.Negocio.NegocioTasks;

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
                        case "22":
                            ClientesTasks.ModificarClientePorID(clienteServicio);
                            break;
                       // estadísticas: cantidad de préstamos por persona (promedio),  precio promedio por ejemplar
                        case "23":
                            PrestamosTasks.PromPrestamosPorCliente(prestamoServicio, clienteServicio);
                            break;
                        case "24":
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


// TODO GENERAL (PENDIENTES)

//Posibles validaciones (Se hacen en la capa de negocio):

// revisar todos los textos


//LISTA DE TAREAS HECHAS:

//DNI único en cliente - LISTO!
//Formato válido email- LISTO!
//Formato válido DNI- LISTO!
// validar strings que no vayan vacios - LISTO para apellido y nombre. Usar IngresarString(string input) para validar strings sin nros,caracteres, ni vacíos
// validar nombre y apellido no tengan numeros - LISTO!
// precio minimo y precio maximo - LISTO!
// cuando da telefono error 500 (Cliente), armar excpetion - LISTO!
// Posibilidad de no ingresar fecha real de devolución
// + pattern validar mail - LISTO!
//- Dropdown de temas - LISTO!
// corregir listado de clientes - LISTO!
// Deja ingresar cualquier fecha de devolución.Validar que sea posterior a la de alta. - LISTO!
// Igual para la fecha real devolución - LISTO!
// Validar que el id de cliente ya exista para modificar - LISTO!
// Dirección sea alfanumérico - LISTO!
// poner fecha de inicio de actividades y exception en base a eso - LISTO!
// corregir reporte de prestamos por cliente fecha prestamo - LISTO!
// corregir alta de prestamo: carga de fechas a la api - LISTO!
// revisar el seter que sea geter - LISTO!
// enum de activo y no activo en cliente - LISTO!
//-Exceptions en Capa de entidades - LISTO!
//- .ToString("$ 0.00") en precio - LISTO!
// validar año que carga / LISTO. INGRESÉ VALIDAR FECHA EN INGRESAR FECHA PASO A PASO 
// regla de negocio: un mismo cliente no puede tener mas de 5 prestamos LISTO!
// no se pueda dar el mismo ejemplar en dos prestamos LISTO!
// el cliente debe existir para asignarle un prestamo LISTO!
// Limite de cantidad de prestamos por persona LISTO!
// tostring mas lindo de cliente LISTO!
//- Calcular y mostar:
//	+ cantidad de prestamos por persona promedio- LISTO!
//	+ precio promedio de ejemplar- LISTO!
// celular, email UNICOS - LISTO! Lo puse solo en alta. Si lo pongo en modificación, no daría siempre error?
// Validación de negocio: solo pueden retirar libros los mayores de 12 años. -LISTO!