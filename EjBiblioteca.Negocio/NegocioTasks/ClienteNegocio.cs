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
        private PrestamoDatos _prestamoDatos;

        public ClienteNegocio()
        {
            _clienteDatos = new ClienteDatos();
            _prestamoDatos = new PrestamoDatos();
        }

        public List<Cliente> TraerClientes()
        {
            List<Cliente> list = _clienteDatos.TraerTodosClientes();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenClientesException();
        }

        public List<Cliente> TraerClientesPorRegistro()
        {
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenClientesException();
        }

        public Cliente TraerClientePorTelefono(long telefono)
        {
            bool valida = ValidarTelefono(telefono);
            if (valida)
            {
                Cliente cliente = _clienteDatos.GetClientePorTelefono(telefono);

                if (cliente != null)
                {
                    return cliente;
                }
                else
                    throw new NoExistenClientesException();
            }
            else
            {
                throw new TelefonoNoExisteException();
                //meter exception
            }
        }

        public void InsertarCliente(Cliente client)
        {
            //Validamos que el cliente que se quiere dar de alta no esté ya ingresado. Chequeamos por DNI
            //El cliente debe ser mayor de 12 años
            //No se puede dar de alta con un teléfono ya registrado
            //No se puede dar de alta con email ya registrado

            bool validaDNI = ValidarClientePorDNI(client.DNI);
            bool validaTel = ValidarTelefono(client.Telefono);
            bool validaEmail = ValidarEmail(client.Email);
            if(client.FechaNacimiento>DateTime.Today.AddYears(-12))
            {
                throw new EdadMinimaException();
            }
            if (validaTel)
            {
                throw new TelefonoYaExisteException();
            }    
            if (validaDNI)
            {
                throw new ClienteYaExisteException();
            }
            if (validaEmail)
            {
                throw new EmailYaExisteException();
            }
            else
            {
                
                ABMResult transaction = _clienteDatos.Insertar(client);
                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
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
                throw new ClienteInexistenteException();
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
                throw new ClienteInexistenteException();
        }

        public void EliminarCliente(Cliente cliente)
        {

            bool flagPrestamo = true;
            foreach (var x in _prestamoDatos.TraerTodosPrestamos())
            {
                if (x.IdCliente == cliente.Id)
                {
                    if (!x.Abierto) {
                        flagPrestamo = false;
                    }
                }
            }
            if (flagPrestamo)
            {
                throw new ClienteConPrestamoAbiertoException();
            }

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
                throw new ClienteInexistenteException();
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
       
        public bool ValidarTelefono(long tel)
        {
            if (tel == null)
                return false;
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();
            bool valida = false;
            foreach (var item in list)
            {
                if (item.Telefono == tel)
                    valida = true;
            }

            return valida;
        }

        public bool ValidarEmail(string email)
        {
            if (email == null)
                return false;
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();
            bool valida = false;
            foreach (var item in list)
            {
                if (item.Email == email)
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
