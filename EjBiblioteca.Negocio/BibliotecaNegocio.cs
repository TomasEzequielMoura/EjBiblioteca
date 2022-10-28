using EjBiblioteca.Datos;
using EjBiblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio
{
    public class BibliotecaNegocio
    {
        // generamos un bibliotecaNegocio muy basico para arrancar y primeras llamadas a la API

        private EjemplarDatos _ejemplarDatos;

        public BibliotecaNegocio()
        {
            _ejemplarDatos = new EjemplarDatos();
        }

        public List<Ejemplar> TraerTodosEjemplares()
        {
            List<Ejemplar> list = _ejemplarDatos.GetEjemplares();

            return list;
        }

        public List<Ejemplar> TraerTodosLosEjemplaresPorLibro(int idLibro)
        {
            List<Ejemplar> list = _ejemplarDatos.GetEjemplaresPorLibro(idLibro);

            return list;
        }
    }
}
