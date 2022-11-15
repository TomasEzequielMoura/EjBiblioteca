using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Exceptions;
using EjBiblioteca.Entidades.Persona;
using EjBiblioteca.Negocio.NegocioTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EjBiblioteca.Consola.ProgramTasks
{


//* Otros:*
//https://cai-api.azurewebsites.net/api/v1/cliente/895380
//Está dando de alta en la base clientes general, pero no en cliente/895380. Esto está en ClienteDatos. Tendríamos que insertar solo en nuestra base?

    public class ClientesTasks
    {
        public static void ListarClientes(ClienteNegocio clienteServicio)
        {
            List<Cliente> listClientes = clienteServicio.TraerClientesPorRegistro();
            var listaOrdenadaPorId = listClientes.OrderBy(x => x.Id).ToList();

            Console.WriteLine("\r\nLista de Clientes:");

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID", "DNI", "Nombre", "Apellido", "Dirección", "Email", "Telefono", "Fecha Nac.", "Fecha Alta", "Activo");
            OutputHelper.PrintLine();

            if (listClientes.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.Id.ToString(), item.DNI.ToString(), item.Nombre, item.Apellido, item.Direccion, item.Email, item.Telefono.ToString(), item.FechaNacimiento.ToString(), item.FechaAlta.ToString(), item.Activo.ToString());
                    OutputHelper.PrintLine();
                }
            }
            else
            {
                Console.WriteLine("\r\nNo se han encontrado clientes");
            }
        }

        public static void AltaCliente(ClienteNegocio clienteServicio)
        {
            
            //int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
            //DateTime fechaAlta = InputHelper.IngresarFechaPasoAPaso(" de alta del cliente");
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarNumero<int>("el DNI del cliente");
            string nombre = InputHelper.IngresarString("el nombre del cliente");
            string apellido = InputHelper.IngresarString("el apellido del cliente");
            string direccion = InputHelper.IngresarStringYNumeros("la dirección del cliente");
            long telefono= InputHelper.IngresarNumero<long>("el teléfono del cliente");
            string mail = InputHelper.IngresarEmail("el e-mail del cliente");
            DateTime fechaNac = InputHelper.IngresarFechaPasoAPaso(" de nacimiento del cliente");
           

            
            Cliente insertCliente = new Cliente(activo, dni, nombre, apellido, direccion, telefono, mail, fechaNac);

            Console.WriteLine("\r\nCliente nuevo ingresado:\r\n" + insertCliente.ToString());
            string confirmacion = InputHelper.confirmacionABM("cliente", "insertar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.InsertarCliente(insertCliente);

                Console.WriteLine("\r\nNuevo cliente ingresado.\r\nResultado final:\r\n" + insertCliente.ToString());
            }
        }

        //Modificación de cliente
        public static void ModificarCliente(ClienteNegocio clienteServicio)
        {
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarNumero<int>("el DNI del cliente");
            string nombre = InputHelper.IngresarString("el nombre del cliente");
            string apellido = InputHelper.IngresarString("el apellido del cliente");
            string direccion = InputHelper.IngresarStringYNumeros("la dirección del cliente");
            long telefono = InputHelper.IngresarNumero<long>("el teléfono del cliente");
            string mail = InputHelper.IngresarEmail("el e-mail del cliente");
            DateTime fechaNac = InputHelper.IngresarFechaPasoAPaso(" de nacimiento del cliente");

            Cliente modificarCliente = new Cliente(idCliente, activo, dni, nombre, apellido, direccion, telefono, mail, fechaNac);

            Console.WriteLine("\r\nCliente a modificar:\r\n" + modificarCliente.ToString());
            string confirmacion = InputHelper.confirmacionABM("cliente", "modificar");


            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.ActualizarCliente(modificarCliente);

                Console.WriteLine("\r\nCliente " + idCliente + " modificado!\r\n\r\nResultado final:\r\n" + modificarCliente.ToString());
            }
        }

        public static void BajaCliente(ClienteNegocio clienteServicio)
        {
            //validar que el cliente exista
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");

            Cliente deleteCliente = new Cliente(idCliente);

            Console.WriteLine("\r\nCliente a dar de baja:\r\n" + deleteCliente.ToString());
            string confirmacion = InputHelper.confirmacionABM("préstamo", "eliminar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.EliminarCliente(deleteCliente);
                Console.WriteLine("\r\nCliente elimando " + deleteCliente.ToString());
            }
        }

        public static void ListarClientePorTelefono(ClienteNegocio clienteServicio)
        {
            long telefono = InputHelper.IngresarNumero<long>("el telefono del cliente");

            Cliente Cliente = clienteServicio.TraerClientePorTelefono(telefono);

            Console.WriteLine("\r\nCliente encontrado!\r\n" + Cliente.ToString());
        }

        public static void ModificarClientePorID(ClienteNegocio clienteServicio)
        {
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarNumero<int>("el DNI del cliente");
            string nombre = InputHelper.IngresarString("el nombre del cliente");
            string apellido = InputHelper.IngresarString("el apellido del cliente");
            string direccion = InputHelper.IngresarStringYNumeros("la dirección del cliente");
            long telefono = InputHelper.IngresarNumero<long>("el teléfono del cliente");
            string mail = InputHelper.IngresarEmail("el e-mail del cliente");
            DateTime fechaNac = InputHelper.IngresarFechaPasoAPaso(" de nacimiento del cliente");

            Cliente modificarCliente = new Cliente(idCliente, activo, dni, nombre, apellido, direccion, telefono, mail, fechaNac);

            Console.WriteLine("\r\nCliente a modificar:\r\n" + modificarCliente.ToString());
            string confirmacion = InputHelper.confirmacionABM("cliente", "modificar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.ActualizarClientePorID(modificarCliente);

                Console.WriteLine("\r\nCliente " + idCliente + " modificado!\r\n\r\nResultado final:\r\n" + modificarCliente.ToString());
            }
        }
    }
}
