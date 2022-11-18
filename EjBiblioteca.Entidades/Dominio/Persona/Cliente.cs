using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades.Persona
{
    // Tomas

    public class Cliente : Persona
    {
        private int _id;
        private DateTime _fechaAlta;
        private bool _activo;

        public Cliente(){}

        public Cliente(int id) {
            _id = id;
        }

        public Cliente(int id, DateTime fechaAlta, bool activo, int DNI, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNac) : base(DNI, nombre, apellido, direccion, telefono, mail, fechaNac)
        {
            _id = id;
            _fechaAlta = fechaAlta;
            _activo = activo;
        }

        public Cliente(int DNI, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNac) : base(DNI, nombre, apellido, direccion, telefono, mail, fechaNac) { }

        public Cliente(DateTime fechaAlta, bool activo, int DNI, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNac) : base(DNI, nombre, apellido, direccion, telefono, mail, fechaNac) 
        {
            _fechaAlta = fechaAlta;
            _activo = activo;
        }

        public Cliente(bool activo, int DNI, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNac) : base(DNI, nombre, apellido, direccion, telefono, mail, fechaNac)
        {
            _activo = activo;
        }

        public Cliente(int id, bool activo, int DNI, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNac) : base(DNI, nombre, apellido, direccion, telefono, mail, fechaNac)
        {
            _id = id;
            _activo = activo;
        }

        public int Id { get => _id; set => _id = value; }
        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public bool Activo { get => _activo; set => _activo = value; }

        public override string ToString()
        {
            return $"ID: {this.Id}\r\nFecha Alta: {this.FechaAlta}\r\nActivo: {this.Activo}\r\nDNI: {this.DNI}\r\nNombre: {this.Nombre}\r\nApellido: {this.Apellido}\r\nDireccion: {this.Direccion}\r\nTelefono: {this.Telefono}\r\nMail: {this.Email}\r\nFecha Nacimiento: {this.FechaNacimiento.ToString("dd/MM/yyyy")}";
        }

    }
}
