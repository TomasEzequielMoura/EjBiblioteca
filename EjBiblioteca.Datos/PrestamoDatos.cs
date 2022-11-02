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
            string json2 = WebHelper.Get("Prestamos/"); // trae un texto en formato json de una web
            List<Prestamo> resultado = MapList(json2);
            return resultado;
        }

        //En la consigna no aparece como que puedo desde prestamo traer enviandole un parámtro
        //public List<Prestamo> TraerPrestamosPorLibro(int idLibro)
        //{
        //    string json2 = WebHelper.Get("Prestamos/" + idLibro); // trae un texto en formato json de una web
        //    List<Prestamo> resultado = MapList(json2);
        //    return resultado;
        //}
        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json); // deserializacion
            return lst;
        }



        public ABMResult Actualizar(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string json = WebHelper.Put("Prestamos/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }


        public ABMResult Insertar(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo); //serializacion -> json

            string json = WebHelper.Post("Prestamos/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult Eliminar(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string json = WebHelper.Delete("Prestamos/", obj);

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
            n.Add("FechaAlta", prestamo.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("FechaBaja", prestamo.FechaBaja.ToString("yyyy-MM-dd"));
            n.Add("FechaBajaReal", prestamo.FechaBajaReal.ToString("yyyy-MM-dd"));
            return n;
        }
    }
}
