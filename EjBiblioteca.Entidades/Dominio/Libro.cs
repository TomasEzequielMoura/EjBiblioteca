using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades
{

    public class Libro
    {
        private int _id;
        private string _titulo;
        private string _autor;
        private int _edicion;
        private string _editorial;
        private int _paginas;
        private string _tema;
        private bool _activo;

        public Libro() { }

        public Libro(string titulo, string autor, int edicion, string editorial, int paginas, string tema)
        {
            _titulo = titulo;
            _autor = autor;
            _edicion = edicion;
            _editorial = editorial;
            _paginas = paginas;
            _tema = tema;
        }

        public Libro(int id, string titulo, string autor, int edicion, string editorial, int paginas, string tema)
        {
            _id = id;
            _titulo = titulo;
            _autor = autor;
            _edicion = edicion;
            _editorial = editorial;
            _paginas = paginas;
            _tema = tema;
        }

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Autor { get => _autor; set => _autor = value; }
        public int Edicion { get => _edicion; set => _edicion = value; }
        public string Editorial { get => _editorial; set => _editorial = value; }
        public int Paginas { get => _paginas; set => _paginas = value; }
        public string Tema { get => _tema; set => _tema = value; }
        public bool Activo { get => _activo; set => _activo = value; }

        public string ComboDisplay { get => $"{this.Titulo}/{this.Autor}"; }

        public override string ToString()
        {
            return $"Titulo: {this.Titulo}\r\nAutor: {this.Autor}\r\nEdición: {this.Edicion}\r\nEditorial: {this.Editorial}\r\nPaginas: {this.Paginas}\r\nTema: {this.Tema}";
        }
    }
}