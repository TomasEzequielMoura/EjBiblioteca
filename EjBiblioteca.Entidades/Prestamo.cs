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
        private DateTime _fechaPrestamo;
        private DateTime _fechaDevolucionTentativa;
        private DateTime _fechaDevolucionReal;

        public Prestamo() { }

        public Prestamo( int cliente, int ejemplar, int plazo, DateTime alta)
        {
          
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _fechaPrestamo = alta;

        }
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
            _fechaPrestamo = alta;

        }
        public Prestamo(int id, int cliente, int ejemplar, int plazo, DateTime alta, DateTime baja)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _fechaPrestamo = alta;
            _fechaDevolucionTentativa = baja;
        }

        public Prestamo(int id, int cliente, int ejemplar, int plazo, DateTime alta, DateTime baja, DateTime bajaReal)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _fechaPrestamo = alta;
            _fechaDevolucionTentativa = baja;
            _fechaDevolucionReal = bajaReal;
        }
        public int Id { get => _id; set => _id = value; }

        public int IdCliente { get => _idCliente; set => _idCliente = value; }

        public int IdEjemplar { get => _idEjemplar; set => _idEjemplar = value; }

        public int Plazo { get => _plazo; set => _plazo = value; }

        public DateTime FechaPrestamo { get => _fechaPrestamo; set => _fechaPrestamo = value; }

        public DateTime FechaDevolucionTentativa { get => _fechaDevolucionTentativa; set => _fechaDevolucionTentativa = value; }

        public DateTime FechaDevolucionReal { get => _fechaDevolucionReal; set => _fechaDevolucionReal = value; }

        public override string ToString()
        {
            return this.Id + ") " + this.IdCliente + ", " + this.IdEjemplar;
        }

        //TODO: Metodos para la clase prestamos
    }
}