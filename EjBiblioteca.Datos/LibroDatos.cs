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
    // Juanse

    public class LibroDatos
    {
        public List<Libro> TraerTodos()
        {
            string json2 = WebHelper.Get("Biblioteca/Libros/"); // trae un texto en formato json de una web
            List<Libro> resultado = MapList(json2);
            return resultado;
        }

        private List<Libro> MapList(string json)
        {
            List<Libro> lst = JsonConvert.DeserializeObject<List<Libro>>(json); // deserializacion
            return lst;
        }

        public ABMResult Insertar(Libro libro)
        {
            NameValueCollection obj = ReverseMap(libro); //serializacion -> json

            string json = WebHelper.Post("Biblioteca/Libros/", obj);

            ABMResult lst = JsonConvert.DeserializeObject<ABMResult>(json);

            return lst;
        }

        private NameValueCollection ReverseMap(Libro libro)
        {
            NameValueCollection n = new NameValueCollection(); 
            n.Add("Id", libro.Id.ToString());
            n.Add("Titulo", libro.Titulo);
            n.Add("Autor", libro.Autor);
            n.Add("Edicion", libro.Edicion.ToString());
            n.Add("Editorial", libro.Editorial);
            n.Add("Paginas", libro.Paginas.ToString());
            n.Add("Tema", libro.Tema);
            n.Add("Activo", libro.Activo.ToString());
            return n;
        }
    }
}