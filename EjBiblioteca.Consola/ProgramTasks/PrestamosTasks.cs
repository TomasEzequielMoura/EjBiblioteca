using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Exceptions;
using EjBiblioteca.Entidades.Persona;
using EjBiblioteca.Negocio;
using EjBiblioteca.Negocio.Exceptions;
using EjBiblioteca.Negocio.NegocioTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramTasks
{
    public class PrestamosTasks
    {
        //se consulta el listado completo de prestamos
        public static void ListarPrestamos(PrestamoNegocio prestamoServicio)
        {
            List<Prestamo> listPrestamos = prestamoServicio.TraerPrestamos();
            var listaOrdenadaPorId = listPrestamos.OrderBy(x => x.Id).ToList();

            Console.WriteLine("\r\nLista de Préstamos:");
            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Préstamo", "ID Cliente", "ID Ejemplar", "Plazo", "Abierto", "Fecha Préstamo", "Fecha Dev. Tentativa", "Fecha Dev. Real");
            OutputHelper.PrintLine();

            if (listPrestamos.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.IdCliente.ToString(), item.IdEjemplar.ToString() , item.Plazo.ToString(), item.Abierto.ToString(), item.FechaPrestamo.ToString(), item.FechaDevolucionTentativa.ToString(), item.FechaDevolucionReal.ToString());
                    OutputHelper.PrintLine();
                }
            }
            else
            {
                Console.WriteLine("\r\nNo se han encontrado préstamos");
            }
        }

        //Dar de alta un préstamo
        public static void AltaPrestamo(PrestamoNegocio prestamoServicio)
        {
            //int id = InputHelper.IngresarNumero<int>("el ID del préstamo"); // chequear si la numeración del préstamo nuevo debe ser automática
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
            int idEjemplar = InputHelper.IngresarNumero<int>("el ID del ejemplar");
            int plazo = InputHelper.IngresarNumero<int>("el plazo del préstamo");
            DateTime fechaPrestamo = InputHelper.IngresarFechaPasoAPaso(" de alta del préstamo");

            Prestamo insertPrestamo = new Prestamo(idCliente, idEjemplar, plazo, true, fechaPrestamo);
            Console.WriteLine("\r\nPréstamo nuevo cargado:\r\n" + insertPrestamo.ToString());
            string confirmacion = InputHelper.confirmacionABM("préstamo", "insertar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                prestamoServicio.InsertarPrestamo(insertPrestamo);

                Console.WriteLine("\r\nNuevo préstamo ingresado.\r\nResultado final:\r\n" + insertPrestamo.ToString());
            }
        }

        //Modificación de préstamo
        public static void ModificarPrestamo(PrestamoNegocio prestamoServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del préstamo que desea actualizar");
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
            int idEjemplar = InputHelper.IngresarNumero<int>("el ID del ejemplar");
            int plazo = InputHelper.IngresarNumero<int>("el plazo del préstamo");
            DateTime fechaPrestamo = InputHelper.IngresarFechaPasoAPaso(" de alta del préstamo");
            //DateTime fechaDevolucionTentativa = InputHelper.IngresarFechaPasoAPaso(" de devolución tentativa del préstamo");
            //DateTime fechaDevolucionReal = InputHelper.IngresarFechaPasoAPaso(" de devolución real del préstamo");

            Prestamo modificarPrestamo = new Prestamo(id, idCliente, idEjemplar, plazo, true, fechaPrestamo);

            Console.WriteLine("\r\nPréstamo nuevo cargado:\r\n" + modificarPrestamo.ToString());
            string confirmacion = InputHelper.confirmacionABM("préstamo", "actualizar");
            if (confirmacion == "S" || confirmacion == "s")
            {
                prestamoServicio.ActualizarPrestamo(modificarPrestamo);

                Console.WriteLine("\r\nPréstamo " + id + " modificado!\r\n\r\nResultado final:\r\n" + modificarPrestamo.ToString());
            }
        }

        public static void CerrarPrestamo(PrestamoNegocio prestamoServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del préstamo");
            DateTime now = DateTime.Now;

            string confirmacion = InputHelper.confirmacionABM("préstamo", "cerrar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                prestamoServicio.CambiarEstadoPrestamo(id, now);
                Console.WriteLine("\r\nPréstamo " + id + " cerrado");
            }
        }

        //Consultar los préstamos por libro
        public static void ListarPrestamosPorLibro(PrestamoNegocio prestamoServicio)
        {
            int idLibro = InputHelper.IngresarNumero<int>("el numero del libro");

            List<Prestamo> list = prestamoServicio.TraerTodosPrestamosPorLibro(idLibro);

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Prestamo", "ID Cliente", "ID Ejemplar", "Plazo", "Abierto", "Fecha Prestamo", "Fecha Dev. Tentativa", "Fecha Dev. Real");
            OutputHelper.PrintLine();

            if (list.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.IdCliente.ToString(), item.IdEjemplar.ToString(), item.Plazo.ToString(), item.Abierto.ToString(), item.FechaPrestamo.ToString(), item.FechaDevolucionTentativa.ToString(), item.FechaDevolucionReal.ToString());
                }
                OutputHelper.PrintLine();
            }
            else
            {
                Console.WriteLine("\r\nNo se ha encontrado ningun préstamo para el ID: " + idLibro);
            }
        }

        public static void ListarPrestamosPorCliente(PrestamoNegocio prestamoServicio)
        {
            int idCliente = InputHelper.IngresarNumero<int>("el numero del cliente");

            List<Prestamo> list = prestamoServicio.TraerTodosPrestamosPorCliente(idCliente);

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Prestamo", "ID Cliente", "ID Ejemplar", "Plazo", "Abierto", "Fecha Prestamo", "Fecha Dev. Tentativa", "Fecha Dev. Real");
            OutputHelper.PrintLine();

            if (list.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.IdCliente.ToString(), item.IdEjemplar.ToString(), item.Plazo.ToString(), item.Abierto.ToString(), item.FechaPrestamo.ToString(), item.FechaDevolucionTentativa.ToString(), item.FechaDevolucionReal.ToString());
                }
                OutputHelper.PrintLine();
            }
            else
            {
                Console.WriteLine("\r\nNo se ha encontrado ningun préstamo para el ID: " + idCliente);
            }
        }

        public static void ContarPrestamosPorCliente(PrestamoNegocio prestamoServicio)
        {
            int count = 0;
            int idCliente = InputHelper.IngresarNumero<int>("el numero del cliente");

            List<Prestamo> list = prestamoServicio.TraerTodosPrestamosPorCliente(idCliente);

            foreach (var item in list)
            {
               count++;
            }

            if (count > 0)
                Console.WriteLine("\r\nEl cliente ID " + idCliente + " tiene " + count + " préstamos\r\n");
                       
            else
            {
                Console.WriteLine("\r\nNo se ha encontrado ningun préstamo para el ID: " + idCliente);
            }
        }

        
        public static void BajaPrestamo(PrestamoNegocio prestamoServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del préstamo"); 

            Prestamo deletePrestamo = new Prestamo(id);

            Console.WriteLine("\r\nPréstamo a dar de baja:\r\n" + deletePrestamo.Id);
            string confirmacion = InputHelper.confirmacionABM("préstamo", "eliminar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                prestamoServicio.EliminarPrestamo(deletePrestamo);
                Console.WriteLine("\r\nPréstamo elimando " + deletePrestamo.Id);
            }
        }

        public static void PromPrestamosPorCliente(PrestamoNegocio prestamoServicio, ClienteNegocio clienteServicio)
        {
            int countPrestamos = 0;
            int countClientes = 0;

            List<Prestamo> lisPrest = prestamoServicio.TraerPrestamos();
            List<Cliente> listClient = clienteServicio.TraerClientesPorRegistro();

            foreach (var p in lisPrest)
            {
                countPrestamos++;
            }
            foreach (var c in listClient)
            {
                countClientes++;
            }
            double prom = countPrestamos / countClientes;
            if (countPrestamos > 0 && countClientes > 0)
            {
                Console.WriteLine($"El promedio de préstamos por cliente es {prom}");
            }
            else
                throw new ErrorDeCalculoException();

        }
    }
}
