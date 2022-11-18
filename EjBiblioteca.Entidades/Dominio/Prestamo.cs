using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades
{
    // Sabri
    //Armado datos básicos de Préstamo

    // TODO: matar constructores que nunca se usan

    public class Prestamo
    {
        private int _id;
        private int _idCliente;
        private int _idEjemplar;
        private int _plazo;
        private bool _abierto;
        private DateTime _fechaPrestamo;
        private DateTime _fechaDevolucionTentativa;
        private DateTime _fechaDevolucionReal;

        public Prestamo() { }

        public Prestamo(int id)
        {
            _id = id;
        }
        public Prestamo(int id, DateTime fechaDevolucionReal)
        {
            _id = id;
            _fechaDevolucionReal = fechaDevolucionReal;
        }
        public Prestamo(int cliente, int ejemplar, int plazo, bool abierto, DateTime alta)
        {
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _abierto = abierto;
            _fechaPrestamo = alta;
        }
        public Prestamo(int id, int cliente, int ejemplar, bool abierto)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _abierto = abierto;
        }

        public Prestamo(int id, int cliente, int ejemplar, int plazo, bool abierto)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _abierto = abierto;
        }

        public Prestamo(int id, int cliente, int ejemplar, int plazo, bool abierto, DateTime alta)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _abierto = abierto;
            _fechaPrestamo = alta;
        }
        
        public Prestamo(int id, int cliente, int ejemplar, int plazo, bool abierto, DateTime alta, DateTime bajaReal)
        {
            _id = id;
            _idCliente = cliente;
            _idEjemplar = ejemplar;
            _plazo = plazo;
            _abierto = abierto;
            _fechaPrestamo = alta;
            _fechaDevolucionReal = bajaReal;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public int IdEjemplar { get => _idEjemplar; set => _idEjemplar = value; }
        public int Plazo { get => _plazo; set => _plazo = value; }
        public bool Abierto { get => _abierto; set => _abierto = value; }
        public DateTime FechaPrestamo { get => _fechaPrestamo; set => _fechaPrestamo = value; }
        public DateTime FechaDevolucionTentativa { get => _fechaDevolucionTentativa = _fechaPrestamo.AddDays(double.Parse(_plazo.ToString())); set => _fechaDevolucionTentativa = _fechaPrestamo.AddDays(double.Parse(_plazo.ToString())); }

        public DateTime FechaDevolucionReal { get => _fechaDevolucionReal; set => _fechaDevolucionReal = value; }

        public override string ToString()
        {
            return "Id Préstamo: "+ this.Id + "\r\nId cliente: " + this.IdCliente + "\r\nId Ejemplar: " + this.IdEjemplar + "\r\nDías de préstamo: " + this.Plazo + "\r\nAbierto: " + this.Abierto + "\r\nFecha préstamo: " + this.FechaPrestamo + "\r\nFecha devolución tentativa: " + this.FechaDevolucionTentativa + "\r\nFecha devolución real: " + this.FechaDevolucionReal;
            
        }
    }
}