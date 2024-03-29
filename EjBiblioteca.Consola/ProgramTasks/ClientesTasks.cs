﻿using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades.Enum;
using EjBiblioteca.Entidades.Persona;
using EjBiblioteca.Negocio.NegocioTasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjBiblioteca.Consola.ProgramTasks
{
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
                    OutputHelper.PrintRow(item.Id.ToString(), item.DNI.ToString(), item.Nombre, item.Apellido, item.Direccion, item.Email, item.Telefono.ToString(), item.FechaNacimiento.ToString("dd/MM/yyyy"), item.FechaAlta.ToString("dd/MM/yyyy"), item.Activo.ToString());
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
            Console.WriteLine("\r\nLos estados válidos para cliente son:");
            Console.WriteLine($"{(ActivoNoActivo.StatusCliente)0} = 0,\r\n" +
                $"{(ActivoNoActivo.StatusCliente)1} = 1"
              );
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarDNI("el DNI del cliente");
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
            Console.WriteLine("\r\nLos estados válidos para cliente son:");
            Console.WriteLine($"{(ActivoNoActivo.StatusCliente)0} = 0,\r\n" +
                $"{(ActivoNoActivo.StatusCliente)1} = 1"
              );
            bool activo = InputHelper.IngresarStatus("el status del cliente");
            int dni = InputHelper.IngresarDNI("el DNI del cliente");
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
            string confirmacion = InputHelper.confirmacionABM("cliente", "eliminar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                clienteServicio.EliminarCliente(deleteCliente);
                Console.WriteLine("\r\nCliente elimando " + deleteCliente.ToString());
            }
        }

        public static void ListarClientePorTelefono(ClienteNegocio clienteServicio)
        {
            long telefono = InputHelper.IngresarNumero<long>("el teléfono del cliente");

            Cliente Cliente = clienteServicio.TraerClientePorTelefono(telefono);

            Console.WriteLine("\r\nCliente encontrado!\r\n" + Cliente.ToString());
        }

        //public static void ModificarClientePorID(ClienteNegocio clienteServicio)
        //{
        //    int idCliente = InputHelper.IngresarNumero<int>("el ID del cliente");
        //    bool activo = InputHelper.IngresarStatus("el status del cliente");
        //    int dni = InputHelper.IngresarDNI("el DNI del cliente");
        //    string nombre = InputHelper.IngresarString("el nombre del cliente");
        //    string apellido = InputHelper.IngresarString("el apellido del cliente");
        //    string direccion = InputHelper.IngresarStringYNumeros("la dirección del cliente");
        //    long telefono = InputHelper.IngresarNumero<long>("el teléfono del cliente");
        //    string mail = InputHelper.IngresarEmail("el e-mail del cliente");
        //    DateTime fechaNac = InputHelper.IngresarFechaPasoAPaso(" de nacimiento del cliente");

        //    Cliente modificarCliente = new Cliente(idCliente, activo, dni, nombre, apellido, direccion, telefono, mail, fechaNac);

        //    Console.WriteLine("\r\nCliente a modificar:\r\n" + modificarCliente.ToString());
        //    string confirmacion = InputHelper.confirmacionABM("cliente", "modificar");

        //    if (confirmacion == "S" || confirmacion == "s")
        //    {
        //        clienteServicio.ActualizarClientePorID(modificarCliente);

        //        Console.WriteLine("\r\nCliente " + idCliente + " modificado!\r\n\r\nResultado final:\r\n" + modificarCliente.ToString());
        //    }
        //}
    }
}
