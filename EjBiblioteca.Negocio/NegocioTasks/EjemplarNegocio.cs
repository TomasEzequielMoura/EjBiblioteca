using EjBiblioteca.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Exceptions;
using EjBiblioteca.Negocio.Exceptions;

namespace EjBiblioteca.Negocio.NegocioTasks
{
    public class EjemplarNegocio
    {
        private EjemplarDatos _ejemplarDatos;
        private LibroDatos _libroDatos;

        public EjemplarNegocio()
        {
            _ejemplarDatos = new EjemplarDatos();
            _libroDatos = new LibroDatos();
        }

        public List<Ejemplar> TraerTodosEjemplares()
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodos();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenEjemplaresException();
        }

        public List<Ejemplar> TraerTodosLosEjemplaresPorLibro(int idLibro)
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodosPorLibro(idLibro);

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenEjemplaresException();
        }


        public void InsertarEjemplar(Ejemplar ejem)
        {
            if (ejem.FechaAlta > DateTime.Today.AddDays(1))
            {
                throw new FechaMayorActualException();
            }
            if (ejem.Precio < 300 || ejem.Precio > 20000) 
            {
                throw new PrecioFueraDeRangoException();
            }

            bool flag = false;
            foreach (var x in _libroDatos.TraerTodos())
            {
                if (x.Id == ejem.IdLibro)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                throw new LibroInexistenteException();
            }
            else
            {
                List<Ejemplar> list = _ejemplarDatos.TraerTodos();

                if (flag == true)
                {
                    ABMResult transaction = _ejemplarDatos.Insertar(ejem);

                    if (!transaction.IsOk)
                        throw new Exception(transaction.Error);
                }
                else
                    throw new LibroInexistenteException();
            }
        }

        public void ActualizarEjemplar(Ejemplar ejem)
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodos();

            bool flag = false;

            if (ejem.Precio < 300 || ejem.Precio > 20000)
            {
                throw new PrecioFueraDeRangoException();
            }
            bool flagLibro = false;
            foreach (var x in _libroDatos.TraerTodos())
            {
                if (x.Id == ejem.IdLibro)
                {
                    flagLibro = true;
                }
            }
            if (!flagLibro)
            {
                throw new LibroInexistenteException();
            }

            else {
                foreach (var item in list)
                {
                    if (item.Id == ejem.Id)
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    ABMResult transaction = _ejemplarDatos.Actualizar(ejem);

                    if (!transaction.IsOk)
                        throw new Exception(transaction.Error);
                }
                else
                    throw new EjemplarInexistenteException();
            }
        }
    }
}
