using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades.Persona;
using EjBiblioteca.Negocio.NegocioTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramTasks
{
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
    }
}
