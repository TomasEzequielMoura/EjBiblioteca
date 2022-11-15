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
                            PrestamosTasks.AltaPrestamo(prestamoServicio);
                            break;
                        case "12":
                            PrestamosTasks.ModificarPrestamo(prestamoServicio);
                            break;
                        case "13":
                            PrestamosTasks.BajaPrestamo(prestamoServicio);
                            break;
                        case "14":
                            ClientesTasks.ListarClientes(clienteServicio);
                            break;
                        case "15":
                            ClientesTasks.AltaCliente(clienteServicio);
                            break;
                        case "16":
                            ClientesTasks.ModificarCliente(clienteServicio);
                            break;
                        case "17":
                            ClientesTasks.BajaCliente(clienteServicio);
                            break;
                        case "18":
                            ClientesTasks.ListarClientePorTelefono(clienteServicio);
                            break;
                        case "19":
                            ClientesTasks.ModificarClientePorID(clienteServicio);
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


// TODO GENERAL
//-Exceptions en Capa de entidades 
//- .ToString("$ 0.00") en precio - LISTO!
//- ver como usar enum para los temas {(TipoTarjetaEnum)this.Tipo }
//-     public enum TipoTarjetaEnum
//{
//    SELECCIONE = 0, VISA = 1, MASTER = 2, AMEX = 3
//}


//- Dropdown de temas
//- Calcular y mostar:
//	+cantidad de prestamos por persona promedio
//	+ precio promedio de ejemplar
// + pattern validar mail

//Posibles validaciones (Se hacen en la capa de negocio):
// precio minimo y precio maximo
// el cliente debe existir para asignarle un prestamo
// Podriamos hacer que no se permitan cargar libros de determinados temas o editoriales
// Limite de cantidad de prestamos por persona
// tostring mas lindo de cliente
// revisar todos los textos
// enum de activo y no activo en cliente
// validar año que carga / LISTO. INGRESÉ VALIDAR FECHA EN INGRESAR FECHA PASO A PASO 
// validar nombre y apellido no tengan numeros - LISTO!
// validar strings que no vayan vacios - LISTO para apellido y nombre. Usar IngresarString(string input) para validar strings sin nros,caracteres, ni vacíos
// corregir listado de clientes
// celular, dni, email UNICOS / DNI está, validación de formato email está
// esperar respuesta de los profes con get por telefono
//Deja ingresar cualquier fecha de devolución.Validar que sea posterior a la de alta.
//Igual para la fecha real devolución
//Posibilidad de no ingresar fecha real de devolución
//Validar que el id de cliente ya exista para modificar - LISTO!
//Dirección sea alfanumérico - LISTO!