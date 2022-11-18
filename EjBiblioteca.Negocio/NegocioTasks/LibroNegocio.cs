using EjBiblioteca.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Exceptions;

namespace EjBiblioteca.Negocio.NegocioTasks
{
    public class LibroNegocio
    {
        private LibroDatos _libroDatos;

        public LibroNegocio()
        {
            _libroDatos = new LibroDatos();
        }

        public List<Libro> TraerTodosLibros()
        {
            List<Libro> list = _libroDatos.TraerTodos();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenLibrosException();
        }

        public void InsertarLibro(Libro libro)
        {
            ABMResult transaction = _libroDatos.Insertar(libro);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public Libro TraerLibroPorID(int idLibro)
        {
            List<Libro> list = _libroDatos.TraerTodos();

            Libro libro = new Libro();
            bool flag = false;
            foreach (var item in list)
            {
                if (item.Id == idLibro)
                {
                    libro.Titulo = item.Titulo;
                    libro.Autor = item.Autor;
                    libro.Edicion = item.Edicion;
                    libro.Editorial = item.Editorial;
                    libro.Paginas = item.Paginas;
                    libro.Tema = item.Tema;
                    flag = true;
                }
            }
            if (flag == false)
            {
                throw new LibroInexistenteException();
            }
            else
                return libro;
        }

    }
}
