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
        private DateTime _fechaPrestamo;
        private DateTime _fechaDevolucionTentativa;
        private DateTime _fechaDevolucionReal;

        public Prestamo() { }

        public Prestamo(int id)
        {
            _id = id;
        }
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

        public DateTime FechaDevolucionTentativa { get => _fechaDevolucionTentativa; set => _fechaDevolucionTentativa = _fechaPrestamo.AddDays(_plazo); }

        public DateTime FechaDevolucionReal { get => _fechaDevolucionReal; set => _fechaDevolucionReal = value; }

        public override string ToString()
        {
            return "Id Préstamo: "+this.Id + "\r\nId cliente: " + this.IdCliente + "\r\nId Ejemplar: " + this.IdEjemplar + "\r\nDías de préstamo: " + this.Plazo + "\r\nFecha préstamo: " + this.FechaPrestamo + "\r\nFecha devolución tentativa: " + this.FechaDevolucionTentativa + "\r\nFecha devolución real: " + this.FechaDevolucionReal;
            //return $"Titulo: {this.Titulo}\r\nAutor: {this.Autor}\r\nEdición: {this.Edicion}\r\nEditorial: {this.Editorial}\r\nPaginas: {this.Paginas}\r\nTema: {this.Tema}";
        }

        //TODO: Metodos para la clase prestamos
    }
}