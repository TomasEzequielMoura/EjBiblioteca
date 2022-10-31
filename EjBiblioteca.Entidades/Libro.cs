using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades
{
    // Juanse

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


        public int id { get => _id; set => _id = value; }
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
            return this.id + ") " + this.Titulo + ", " + this.Autor;
        }

    }
}
