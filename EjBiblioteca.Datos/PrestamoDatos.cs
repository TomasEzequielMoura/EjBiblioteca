using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EjBiblioteca.Datos.Utilidades;
using EjBiblioteca.Entidades;
using System.Collections.Specialized;

namespace EjBiblioteca.Datos
{
    // Sabri

    public class PrestamoDatos
    {
        //Llamado a API de los Préstamos
        public List<Prestamo> TraerTodosPrestamos()
        {
            string json2 = WebHelper.Get("Biblioteca/Prestamos/"); // trae un texto en formato json de una web
            List<Prestamo> resultado = MapList(json2);
            return resultado;
        }

        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json); // deserializacion
            return lst;
        }

        public ABMResult Actualizar(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string json = WebHelper.Put("Biblioteca/Prestamos/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult Insertar(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo); //serializacion -> json

            string json = WebHelper.Post("Biblioteca/Prestamos/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult Eliminar(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string json = WebHelper.Delete("Biblioteca/Prestamos/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMap(Prestamo prestamo)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Id", prestamo.Id.ToString());
            n.Add("IdCliente", prestamo.IdCliente.ToString());
            n.Add("IdEjemplar", prestamo.IdEjemplar.ToString());
            n.Add("Plazo", prestamo.Plazo.ToString());
            n.Add("Abierto", prestamo.Abierto.ToString());
            n.Add("fechaPrestamo", prestamo.FechaPrestamo.ToString("yyyy-MM-dd"));
            n.Add("fechaDevolucionTentativa", prestamo.FechaDevolucionTentativa.ToString("yyyy-MM-dd"));
            n.Add("fechaDevolucionReal", prestamo.FechaDevolucionReal.ToString("yyyy-MM-dd")); //"yyyy-MM-dd"
            return n;
        }
    }
}
