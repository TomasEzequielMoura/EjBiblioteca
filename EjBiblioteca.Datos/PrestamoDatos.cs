using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EjBiblioteca.Datos.Utilidades;
using EjBiblioteca.Entidades;

namespace EjBiblioteca.Datos
{
    // Sabri

    public class PrestamoDatos
    {
        //Prueba llamado a API de los Préstamos
        public List<Prestamo> GetPrestamos()
        {
            string json2 = WebHelper.Get("listado de prestamos"); // trae un texto en formato json de una web
            List<Prestamo> resultado = MapList(json2);
            return resultado;
        }
        public List<Prestamo> GetPestamosPorCliente(int idCliente)
        {
            string json2 = WebHelper.Get("Prestamos por cliente/" + idCliente); // trae un texto en formato json de una web
            List<Prestamo> resultado = MapList(json2);
            return resultado;
        }

        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json); // deserializacion
            return lst;
        }
    }
}
