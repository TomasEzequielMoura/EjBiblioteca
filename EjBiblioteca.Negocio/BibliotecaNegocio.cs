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
        private PrestamoDatos _prestamoDatos;

        //private LibroDatos _libroDatos;
        //private PrestamoDatos _prestamoDatos;

        public BibliotecaNegocio()
        {
            _ejemplarDatos = new EjemplarDatos();
            //_libroDatos = new EjemplarDatos();
            //_prestamoDatos = new EjemplarDatos();
        }

        //NEGOCIO EJEMPLARES 
        public List<Ejemplar> TraerTodosEjemplares()
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodos();

            return list;
        }

        public List<Ejemplar> TraerTodosLosEjemplaresPorLibro(int idLibro)
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodosPorLibro(idLibro);

            return list;
        }

        public void AltaEjemplar(Ejemplar ejem)
        {
            ABMResult transaction = _ejemplarDatos.Insertar(ejem);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public void ActualizarEjemplar(Ejemplar ejem)
        {
            ABMResult transaction = _ejemplarDatos.Actualizar(ejem);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        //NEGOCIO PRESTAMOS 
        public List<Prestamo> TraerTodosPrestamos()
        {
            List<Prestamo> list = _prestamoDatos.GetPrestamos();

            return list;
        }


        //TODO: Armar reporte por cliente
        //public List<Prestamo> TraerPrestamosPorCliente(int idCliente)
        //{
        //    List<Prestamo> list = _prestamoDatos.GetPestamos(idCliente);

        //    return list;
        //}

        public List<Prestamo> TraerPestamosPorLibro(int idLibro)
        {

            List<Ejemplar> listEjemplares = TraerTodosLosEjemplaresPorLibro(idLibro);
            //ver como sacar el id libro de la lista de ejemplares que traje
            List<Prestamo> list = _prestamoDatos.GetPrestamos();

            return list;
        }
    }
}
