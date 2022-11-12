using EjBiblioteca.Datos.Utilidades;
using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Persona;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Datos
{
    public class ClienteDatos
    {
        //Llamado a API de los Cliente
        public List<Cliente> TraerTodosClientes()
        {
            string json2 = WebHelper.Get("cliente/"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        public List<Cliente> TraerTodosClientesPorRegistro()
        {
            string json2 = WebHelper.Get("cliente/895380"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        public List<Cliente> TraerTodosClientesPorTelefono(long telefono)
        {
            string json2 = WebHelper.Get("cliente/" + telefono + "/telefono"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        private List<Cliente> MapList(string json)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject<List<Cliente>>(json); // deserializacion
            return lst;
        }

        public ABMResult Actualizar(Cliente Cliente)
        {
            NameValueCollection obj = ReverseMap(Cliente);

            string json = WebHelper.Put("cliente/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult ActualizarPorId(Cliente Cliente)
        {
            NameValueCollection obj = ReverseMap(Cliente);

            string json = WebHelper.Put("cliente/" + Cliente.IdCliente, obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult Insertar(Cliente Cliente)
        {
            NameValueCollection obj = ReverseMap(Cliente); //serializacion -> json

            string json = WebHelper.Post("cliente/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult Eliminar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);

            string json = WebHelper.Delete("cliente/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("IdCliente", cliente.IdCliente.ToString());
            n.Add("FechaAlta", cliente.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("Activo", cliente.Activo.ToString());
            n.Add("DNI", cliente.DNI.ToString());
            n.Add("Nombre", cliente.Nombre);
            n.Add("Apellido", cliente.Apellido);
            n.Add("Direccion", cliente.Direccion);
            n.Add("Telefono", cliente.Telefono.ToString());
            n.Add("Mail", cliente.Mail);
            n.Add("FechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            return n;
        }
    }
}
