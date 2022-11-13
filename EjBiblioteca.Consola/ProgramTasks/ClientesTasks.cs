using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
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

//    TODO:
//Validar:
//Deja ingresar cualquier fecha de devolución.Validar que sea posterior a la de alta.
//Igual para la fecha real devolución
//Posibilidad de no ingresar fecha real de devolución

//* Otros:*
//https://cai-api.azurewebsites.net/api/v1/cliente/895380
//Está dando de alta en la base clientes general, pero no en cliente/895380. Esto está en ClienteDatos. Tendríamos que insertar solo en nuestra base?

    public class ClientesTasks
    {
        public static void ListarClientes(ClienteNegocio clienteServicio)
        {
            List<Cliente> listClientes = clienteServicio.TraerClientes();
            var listaOrdenadaPorId = listClientes.OrderBy(x => x.IdCliente).ToList();

            Console.WriteLine("\r\nLista de Clientes:");

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID", "DNI", "Nombre", "Apellido", "Dirección", "Email", "Telefono", "Fecha Nac.", "Fecha Alta", "Activo");
            OutputHelper.PrintLine();

            if (listClientes.Count > 0)
            {
                foreach (var item in listaOrdenadaPorId)
                {
                    OutputHelper.PrintLine();
                    OutputHelper.PrintRow(item.IdCliente.ToString(), item.DNI.ToString(), item.Nombre, item.Apellido, item.Direccion, item.Mail, item.Telefono.ToString(), item.FechaNacimiento.ToString(), item.FechaAlta.ToString(), item.Activo.ToString());
                    OutputHelper.PrintLine();
                }
            }
            else
            {
                Console.WriteLine("\r\nNo se han encontrado clientes");
            }

        }

        public static void AltaClientes(ClienteNegocio clienteServicio)
        {
            
            int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
            DateTime fechaAlta = InputHelper.IngresarFechaPasoAPaso(" de alta del cliente");
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarNumero<int>("el DNI del cliente");
            Console.WriteLine("\r\nIngrese el nombre del cliente");
            string nombre = Console.ReadLine();
            Console.WriteLine("\r\nIngrese el apellido del cliente");
            string apellido = Console.ReadLine();
            Console.WriteLine("\r\nIngrese la dirección del cliente");
            string direccion = Console.ReadLine();
            long telefono= InputHelper.IngresarNumero<int>("el teléfono del cliente");
            Console.WriteLine("\r\nIngrese el mail del cliente");
            string mail = Console.ReadLine();

            Cliente insertCliente = new Cliente(idCliente, fechaAlta, activo,dni,nombre,apellido,direccion,telefono,mail);

            Console.WriteLine("\r\nCliente nuevo ingresado:\r\n" + insertCliente.ToString());
            string confirmacion = InputHelper.confirmacionABM("cliente", "insertar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.InsertarCliente(insertCliente);

                Console.WriteLine("\r\nNuevo cliente ingresado.\r\nResultado final:\r\n" + insertCliente.ToString());
            }
        }
    }
}
