using EjBiblioteca.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio.Exceptions;
using EjBiblioteca.Entidades.Persona;
using EjBiblioteca.Entidades.Exceptions;

namespace EjBiblioteca.Negocio.NegocioTasks
{
    public class ClienteNegocio
    {
        private ClienteDatos _clienteDatos;

        public ClienteNegocio()
        {
            _clienteDatos = new ClienteDatos();
        }

        public List<Cliente> TraerClientes()
        {
            List<Cliente> list = _clienteDatos.TraerTodosClientes();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenClientes();
        }

        public List<Cliente> TraerClientesPorRegistro()
        {
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenClientes();
        }

        public Cliente TraerClientePorTelefono(long telefono)
        {
            Cliente cliente = _clienteDatos.GetClientePorTelefono(telefono);

            if (cliente != null)
            {
                return cliente;
            }
            else
                throw new NoExistenClientes();
        }

        public void InsertarCliente(Cliente client)
        {
           
        
            //Validamos que el cliente que se quiere dar de alta no esté ya ingresado. Chequeamos por DNI
            bool validaDNI = ValidarClientePorDNI(client.DNI);
            if (!validaDNI)
            {
                ABMResult transaction = _clienteDatos.Insertar(client);
                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else
            {
                throw new ClienteYaExiste();
            }
                       
        }
            
        public void ActualizarCliente(Cliente cliente)
        {
            List<Cliente> list = TraerClientesPorRegistro();

            

            bool flag = false;

            foreach (var item in list)
            {
                if (item.Id == cliente.Id)
                {
                    flag = true;
                }
            }

            if (flag == true)
            {
                ABMResult transaction = _clienteDatos.Actualizar(cliente);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else
                throw new ClienteInexistente();
        }

        public void ActualizarClientePorID(Cliente cliente)
        {
            List<Cliente> list = TraerClientesPorRegistro();

            bool flag = false;

            foreach (var item in list)
            {
                if (item.Id == cliente.Id)
                {
                    flag = true;
                }
            }

            if (flag == true)
            {
                ABMResult transaction = _clienteDatos.ActualizarPorId(cliente);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else
                throw new ClienteInexistente();
        }

        public void EliminarCliente(Cliente cliente)
        {
            List<Cliente> list = TraerClientesPorRegistro();

            bool flag = false;

            foreach (var item in list)
            {
                if (item.Id == cliente.Id)
                {
                    flag = true;
                }
            }

            if (flag == true)
            {

                ABMResult transaction = _clienteDatos.Eliminar(cliente);

                // validar que ese cliente exista

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else
                throw new ClienteInexistente();
        }

        public bool ValidarClientePorId(int id)
        {
            if (id == null)
                return false;
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();
            bool valida = false;
            foreach (var item in list)
            {
                if (item.Id == id)
                    valida = true;
            }

            return valida;
        }

        public bool ValidarClientePorDNI(int dni)
        {
            if (dni == null)
                return false;
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();
            bool valida = false;
            foreach (var item in list)
            {
                if (item.DNI==dni)
                valida = true;
            }

            return valida;
        }

        public bool ValidarClientePorIdMasDNI(int id, int dni)
        {
            if (dni == null)
                return false;
            if (id == null)
                return false;
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();
            bool valida = false;
            foreach (var item in list)
            {
                if (item.Id == id)
                    if (item.DNI == dni)
                    {
                        valida = true;
                    }
                else
                    {
                        Console.WriteLine("El DNI ingresado no corresponde al Id de cliente que ingresado");
                    }
                    
            }

            return valida;
        }

    }
}
