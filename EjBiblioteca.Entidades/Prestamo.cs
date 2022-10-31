using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EjBiblioteca.Entidades
{
    // Sabri
    //Armado datos básicos de Préstamo

    public class Prestamo
    {
        private int _id;
        private int _idCliente;
        private int _idEjemplar;
        private int _plazo;
        private DateTime _fechaAlta;
        private DateTime _fechaBaja;
        private DateTime _fechaBajaReal;

        public Prestamo() { }

        public Prestamo(int id, int cliente, int ejemplar)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
        }

        public Prestamo(int id, int cliente, int ejemplar, int plazo)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
        }

        public Prestamo(int id, int cliente, int ejemplar, int plazo, DateTime alta)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _fechaAlta = alta;

        }
        public Prestamo(int id, int cliente, int ejemplar, int plazo, DateTime alta, DateTime baja)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _fechaAlta = alta;
            _fechaBaja = baja;
        }

        public Prestamo(int id, int cliente, int ejemplar, int plazo, DateTime alta, DateTime baja, DateTime bajaReal)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _fechaAlta = alta;
            _fechaBaja = baja;
            _fechaBajaReal = bajaReal;
        }
        public int Id { get => _id; set => _id = value; }

        public int IdCliente { get => _idCliente; set => _idCliente = value; }

        public int IdEjemplar { get => _idEjemplar; set => _idEjemplar = value; }

        public int Plazo { get => _plazo; set => _plazo = value; }

        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }

        public DateTime FechaBaja { get => _fechaBaja; set => _fechaBaja = value; }

        public DateTime FechaBajaReal { get => _fechaBajaReal; set => _fechaBajaReal = value; }

        public override string ToString()
        {
            return this.Id + ") " + this.IdCliente + ", " + this.IdEjemplar;
        }

        //TODO: Metodos para la clase prestamos
    }
}
