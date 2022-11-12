using EjBiblioteca.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio.Exceptions;
using EjBiblioteca.Entidades.Persona;

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
            List<Cliente> list = _clienteDatos.TraerTodosClientesPorRegistro();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenClientes();
        }
    }
}
