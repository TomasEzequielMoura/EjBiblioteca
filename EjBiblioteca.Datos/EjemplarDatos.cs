using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using EjBiblioteca.Datos.Utilidades;
using EjBiblioteca.Entidades;

namespace EjBiblioteca.Datos
{
    // Tomas

    public class EjemplarDatos
    {

        // Prueba de llamado a API de todos los ejemplares
        public List<Ejemplar> TraerTodos()
        {
            string json2 = WebHelper.Get("Ejemplares/"); // trae un texto en formato json de una web
            List<Ejemplar> resultado = MapList(json2);
            return resultado;
        }

        public List<Ejemplar> TraerTodosPorLibro(int idLibro)
        {
            string json2 = WebHelper.Get("Ejemplares/" + idLibro); // trae un texto en formato json de una web
            List<Ejemplar> resultado = MapList(json2);
            return resultado;
        }

        private List<Ejemplar> MapList(string json)
        {
            List<Ejemplar> lst = JsonConvert.DeserializeObject<List<Ejemplar>>(json); // deserializacion
            return lst;
        }

        public ABMResult Insertar(Ejemplar ejem)
        {
            NameValueCollection obj = ReverseMap(ejem); //serializacion -> json

            string json = WebHelper.Post("Ejemplares/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        public ABMResult Actualizar(Ejemplar ejem)
        {
            NameValueCollection obj = ReverseMap(ejem);

            string json = WebHelper.Put("Ejemplares/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMap(Ejemplar ejem)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Id", ejem.Id.ToString());
            n.Add("IdLibro", ejem.IdLibro.ToString());
            n.Add("Observaciones", ejem.Observaciones);
            n.Add("Precio", ejem.Precio.ToString());
            n.Add("FechaAlta", ejem.FechaAlta.ToString("yyyy-MM-dd"));
            return n;
        }
    }
}
