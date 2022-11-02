using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades
{
    // armado de ejemplar con datos que corresponde pero solo para pruebas iniciales
    public class Ejemplar
    {
        private int _id;
        private int _idLibro;
        private string _observaciones;
        private double _precio;
        private DateTime _fechaAlta;

        public Ejemplar() { }

        public Ejemplar(int id, string observaciones)
        {
            _id = id;
            _observaciones = observaciones;
        }

        public Ejemplar(int id, string observaciones, double precio)
        {
            _id = id;
            _observaciones = observaciones;
            _precio = precio;
        }

        public Ejemplar(int id, int idLibro, string observaciones)
        {
            _id = id;
            _idLibro = idLibro;
            _observaciones = observaciones;
        }

        public Ejemplar(int idLibro, string observaciones, double precio, DateTime fechaAlta)
        {
            _idLibro = idLibro;
            _observaciones = observaciones;
            _precio = precio;
            _fechaAlta = fechaAlta;
        }

        public Ejemplar(int idLibro, string observaciones, double precio, DateTime fechaAlta, int id)
        {
            _idLibro = idLibro;
            _observaciones = observaciones;
            _precio = precio;
            _fechaAlta = fechaAlta;
            _id = id;
        }

        public Ejemplar(int id, int idLibro, string observaciones, double precio)
        {
            _id = id;
            _idLibro = idLibro;
            _observaciones = observaciones;
            _precio = precio;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdLibro { get => _idLibro; set => _idLibro = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }

        public override string ToString()
        {
            return $"{this.Id}) {this.IdLibro} $ {this.Precio}";
        }
    }
}
