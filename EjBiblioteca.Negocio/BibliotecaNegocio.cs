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

        //private LibroDatos _libroDatos;
        //private PrestamoDatos _prestamoDatos;

        public BibliotecaNegocio()
        {
            _ejemplarDatos = new EjemplarDatos();
            //_libroDatos = new EjemplarDatos();
            //_prestamoDatos = new EjemplarDatos();
        }

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

        public void AltaEjemplar(Ejemplar ejem, string descripcion)
        {
            // validar cliente no nulo
            // validar cliente no tenga cuenta

            Ejemplar ejemplarAlta = new Ejemplar(ejem.Id, descripcion);

            ABMResult transaction = _ejemplarDatos.Insertar(ejemplarAlta);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        private void ActualizarEjemplar(Ejemplar ejem)
        {
            ABMResult transaction = _ejemplarDatos.Actualizar(ejem);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }
    }
}
