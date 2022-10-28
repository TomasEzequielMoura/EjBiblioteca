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
    public class EjemplarDatos
    {

        // Prueba de llamado a API de todos los ejemplares

        public List<Ejemplar> GetEjemplares()
        {
            string json2 = WebHelper.Get(""); // trae un texto en formato json de una web
            List<Ejemplar> resultado = MapList(json2);
            return resultado;
        }

        private List<Ejemplar> MapList(string json)
        {
            List<Ejemplar> lst = JsonConvert.DeserializeObject<List<Ejemplar>>(json); // deserializacion
            return lst;
        }

        //public Ejemplar Traer(int ejem)
        //{
        //    string json2 = WebHelper.Get("Ejemplar/" + ejem.ToString()); // trae un texto en formato json de una web
        //    Ejemplar resultado = MapObj(json2);
        //    return resultado;
        //}

        //private Ejemplar MapObj(string json)
        //{
        //    Ejemplar lst = JsonConvert.DeserializeObject<Ejemplar>(json); // deserializacion
        //    return lst;
        //}

    }
}
