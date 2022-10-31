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
        public List<Libro> TraerLibros()
        {
            string json2 = WebHelper.Get("Libros/"); // trae un texto en formato json de una web
            List<Libro> resultado = MapList(json2);
            return resultado;
        }


        private List<Libro> MapList(string json)
        {
            List<Libro> lst = JsonConvert.DeserializeObject< List < Libro >> (json); // deserializacion
            return lst;
        }


        //public TransactionResult Insertar(Libro libro)
        //{
        //    NameValueCollection obj = ReverseMap(cliente); //serializacion -> json

        //    string json = WebHelper.Post("Libros/", obj);

        //    TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

        //    return lst;
        //}

        //public TransactionResult Actualizar(Libro libro)
        //{
        //    NameValueCollection obj = ReverseMap(cliente);

        //    string json = WebHelper.Put("Libros/", obj);

        //    TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

        //    return lst;
        //}
        //private NameValueCollection ReverseMap(Libro libro)
        //{
        //    NameValueCollection n = new NameValueCollection();
        //    n.Add("id", libro.id.ToString());
        //    n.Add("Titulo", libro.Titulo);
        //    n.Add("Autor", libro.Autor);
        //    n.Add("Edición", libro.Edicion);
        //    n.Add("Editorial", libro.Editorial);
        //    n.Add("Paginas", libro.Paginas.ToString());
        //    n.Add("Tema", libro.Tema.ToString());
        //    n.Add("Usuario", "123");
        //    return n;
        //}

    }
}
