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

        public EjemplarNegocio()
        {
            _ejemplarDatos = new EjemplarDatos();
        }

        public List<Ejemplar> TraerTodosEjemplares()
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodos();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenEjemplares();
        }

        public List<Ejemplar> TraerTodosLosEjemplaresPorLibro(int idLibro)
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodosPorLibro(idLibro);

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenEjemplares();
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
            else
            {
                List<Ejemplar> list = _ejemplarDatos.TraerTodos();

                bool flag = true;

                // TODO: VALIDAR QUE EL LIBRO EXISTA

                if (flag == true)
                {
                    ABMResult transaction = _ejemplarDatos.Insertar(ejem);

                    if (!transaction.IsOk)
                        throw new Exception(transaction.Error);
                }
                else
                    throw new LibroInexistente();
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
                    throw new EjemplarInexistente();
            }
        }
    }
}
