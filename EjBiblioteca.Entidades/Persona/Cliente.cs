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

        public Cliente(int id, string nombre, string apellido, string direccion, long telefono, string mail) : base(id, nombre, apellido, direccion, telefono, mail) { }

        public Cliente(int id, DateTime fechaAlta, bool activo, int idPersona, string nombre, string apellido, string direccion, long telefono, string mail) : base(idPersona, nombre, apellido, direccion, telefono, mail) {
            _id = id;
            _fechaAlta = fechaAlta;
            _activo = activo;
        }

        public int IdCliente { get => _id; set => _id = value; }
        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public bool Activo { get => _activo; set => _activo = value; }

        public override string ToString()
        {
            return $"{this.IdCliente}) {this.Nombre} $ {this.Apellido}";
        }

    }
}
