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
            int dni=0;
            int inputDNI = InputHelper.IngresarNumero<int>("el DNI del cliente");
            bool validaDNI = clienteServicio.ValidarClientePorDNI(inputDNI);
            if (!validaDNI)
            {
                dni = inputDNI;
            }
            else
            {
                throw new ClienteYaExiste();
            }
            string nombre = InputHelper.IngresarString("el nombre del cliente");
            string apellido = InputHelper.IngresarString("el apellido del cliente");
            Console.WriteLine("\r\nIngrese la dirección del cliente");
            string direccion = Console.ReadLine();
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

        //Modificación de préstamo
        public static void ModificarCliente(ClienteNegocio clienteServicio)
        {
            //validar que el cliente exista
            int idCliente = 0;
            int id = InputHelper.IngresarNumero<int>("el ID del cliente");
            bool validaId = clienteServicio.ValidarClientePorId(id);
            if (validaId)
            {
                idCliente = id;
            }
            else
            {
                throw new ClienteInexistente();
            }

            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarNumero<int>("el DNI del cliente");
            string nombre = InputHelper.IngresarString("el nombre del cliente");
            string apellido = InputHelper.IngresarString("el apellido del cliente");
            Console.WriteLine("\r\nIngrese la dirección del cliente");
            string direccion = Console.ReadLine();
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
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");

            Cliente deleteCliente = new Cliente(idCliente);

            Console.WriteLine("\r\nCliente a dar de baja:\r\n" + deleteCliente.Id);
            string confirmacion = InputHelper.confirmacionABM("préstamo", "eliminar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.EliminarCliente(deleteCliente);
                Console.WriteLine("\r\nCliente elimando " + deleteCliente.Id);
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
            //DateTime fechaAlta = InputHelper.IngresarFechaPasoAPaso(" de alta del cliente");
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarNumero<int>("el DNI del cliente");
            Console.WriteLine("\r\nIngrese el nombre del cliente");
            string nombre = Console.ReadLine();
            Console.WriteLine("\r\nIngrese el apellido del cliente");
            string apellido = Console.ReadLine();
            Console.WriteLine("\r\nIngrese la dirección del cliente");
            string direccion = Console.ReadLine();
            long telefono = InputHelper.IngresarNumero<long>("el teléfono del cliente");
            Console.WriteLine("\r\nIngrese el mail del cliente");
            string mail = Console.ReadLine();
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
