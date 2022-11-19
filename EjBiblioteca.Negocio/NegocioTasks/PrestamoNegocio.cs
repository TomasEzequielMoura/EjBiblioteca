using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBiblioteca.Datos;
using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Exceptions;
using EjBiblioteca.Entidades.Persona;

namespace EjBiblioteca.Negocio.NegocioTasks
{
    public class PrestamoNegocio
    {
        private PrestamoDatos _prestamoDatos;
        private ClienteDatos _clienteDatos;
        private LibroDatos _libroDatos;
        private EjemplarDatos _ejemplarDatos;

        private EjemplarNegocio _ejemplarNegocio;

        public PrestamoNegocio()
        {
            _prestamoDatos = new PrestamoDatos();
            _clienteDatos = new ClienteDatos();
            _libroDatos = new LibroDatos();
            _ejemplarDatos = new EjemplarDatos();

            _ejemplarNegocio = new EjemplarNegocio();
        }

        //Validación de negocio: Fecha inicio actividades: 01/07/2019. La fecha de alta de préstamo no puede ser anterior
        DateTime fechaInicioAct = DateTime.Parse("01/07/2019");

        public List<Prestamo> TraerPrestamos()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }
        
        public void InsertarPrestamo(Prestamo prest)
        {
            //validamos que el cliente no tenga mas de 5 préstamos
            int cantidadPrestamos = 0;
            bool flagCliente = true;
            bool flagEjemplar = true;

            foreach (var x in TraerPrestamos())
            {
                if (x.IdCliente == prest.IdCliente) {
                    cantidadPrestamos++;
                }
                if (x.IdEjemplar == prest.IdEjemplar)
                {
                    if (x.Abierto) {
                        throw new EjemplarEnPrestamoException();
                    }
                }
            }
            foreach (var x in _clienteDatos.TraerTodosClientesPorRegistro())
            {
                if (x.Id == prest.IdCliente)
                {
                    flagCliente = false;
                }
            }
            foreach (var x in _ejemplarDatos.TraerTodos())
            {
                if (x.Id == prest.IdEjemplar)
                {
                    flagEjemplar = false;
                }
            }
            if (cantidadPrestamos >= 5)
            {
                throw new MaximoPrestamosException();
            }
            if (flagCliente)
            {
                throw new ClienteInexistenteException();
            }
            if (flagEjemplar)
            {
                throw new EjemplarInexistenteException();
            }
            if (prest.FechaPrestamo < fechaInicioAct)
            {
                throw new FechaAltaExceptionException();
            }
            else
            {
                ABMResult transaction = _prestamoDatos.Insertar(prest);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
        }

        public void ActualizarPrestamo(Prestamo prest)
        {
            int cantidadPrestamos = 0;
            bool flag = true;

            foreach (var x in TraerPrestamos())
            {
                if (x.IdCliente == prest.IdCliente)
                {
                    cantidadPrestamos++;
                }
                if (x.IdEjemplar == prest.IdEjemplar)
                {
                    throw new EjemplarEnPrestamoException();
                }
            }
            foreach (var x in _clienteDatos.TraerTodosClientesPorRegistro())
            {
                if (x.Id == prest.IdCliente)
                {
                    flag = false;
                }
            }
            if (cantidadPrestamos >= 5)
            {
                throw new MaximoPrestamosException();
            }
            if (flag)
            {
                throw new ClienteInexistenteException();
            }
            if (prest.FechaPrestamo < fechaInicioAct)
            {
                throw new FechaAltaExceptionException();
            }
            else {
                List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

                foreach (var item in list)
                {
                    if (item.Id == prest.Id)
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    if (prest.Abierto)
                    {
                        ABMResult transaction = _prestamoDatos.Actualizar(prest);

                        if (!transaction.IsOk)
                            throw new Exception(transaction.Error);
                    }
                    else {
                        throw new PrestamoCerradoException();
                    }
                }
                else
                    throw new PrestamoInexistenteException();
            }
        }

        public void CambiarEstadoPrestamo(int id, DateTime now)
        {
            bool flag = false;
            Prestamo prestamoCerrar = new Prestamo();

            foreach (var item in _prestamoDatos.TraerTodosPrestamos())
            {
                if (item.Id == id)
                {
                    flag = true;
                    prestamoCerrar.Id = id;
                    prestamoCerrar.IdCliente = item.IdCliente;
                    prestamoCerrar.IdEjemplar = item.IdEjemplar;
                    prestamoCerrar.Abierto = item.Abierto;
                    prestamoCerrar.Plazo = item.Plazo;
                    prestamoCerrar.FechaPrestamo = item.FechaPrestamo;
                }
            }
            if (flag == true)
            {
                if (prestamoCerrar.Abierto)
                {
                    prestamoCerrar.Abierto = false;
                    prestamoCerrar.FechaDevolucionReal = now;
                    ABMResult transaction = _prestamoDatos.Actualizar(prestamoCerrar);

                    if (!transaction.IsOk)
                        throw new Exception(transaction.Error);
                }
                else
                {
                    throw new PrestamoCerradoException();
                }
            }
            else
                throw new PrestamoInexistenteException();
        }

        public void EliminarPrestamo(Prestamo prest)
        {
           //validamos que el préstamo exista
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            bool flag = false;

            foreach (var item in list)
            {
                if (item.Id == prest.Id)
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                ABMResult transaction = _prestamoDatos.Eliminar(prest);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else
                throw new PrestamoInexistenteException();
        }

        public List<Prestamo> TraerTodosPrestamosPorLibro(int idLibro)
        {
            bool flag = false;
            foreach (var x in _libroDatos.TraerTodos())
            {
                if (x.Id == idLibro)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                throw new LibroInexistenteException();
            }

            List<Ejemplar> listEjemplar = _ejemplarNegocio.TraerTodosLosEjemplaresPorLibro(idLibro);

            List<Prestamo> listPrestamo = _prestamoDatos.TraerTodosPrestamos();

            List<Prestamo> listPrestamoPorLibro = new List<Prestamo>();

            if (listEjemplar.Count < 1)
                throw new NoHayEjemplaresParaLibroException();
            if (listPrestamo.Count < 1)
                throw new NoHayPrestamosException();

            foreach (var itemEjemplar in listEjemplar)
            {
                foreach (var itemPrestamo in listPrestamo)
                {
                    if (itemPrestamo.IdEjemplar == itemEjemplar.Id)
                    {
                        listPrestamoPorLibro.Add(itemPrestamo);
                    }
                }
            }

            if (listPrestamoPorLibro.Count() > 0)
            {
                return listPrestamoPorLibro;
            }
            else {
                throw new NoHayPrestamosParaLibroException();
            }
        }

        public List<Prestamo> TraerTodosPrestamosPorCliente(int idCliente)
        {
            bool flagCliente = true;
            foreach (var x in _clienteDatos.TraerTodosClientesPorRegistro())
            {
                if (x.Id == idCliente)
                {
                    flagCliente = false;
                }
            }
            if (flagCliente)
            {
                throw new ClienteInexistenteException();
            }

            List<Prestamo> listPrestamo = _prestamoDatos.TraerTodosPrestamos();

            List<Prestamo> listPrestamoPorCliente = new List<Prestamo>();

            if (listPrestamo.Count < 1)
                throw new NoHayPrestamosException();

            foreach (var itemPrestamo in listPrestamo)
            {
                if (itemPrestamo.IdCliente == idCliente)
                {
                    listPrestamoPorCliente.Add(itemPrestamo);
                }
            }

            if (listPrestamoPorCliente.Count() > 0)
            {
                return listPrestamoPorCliente;
            }
            else
            {
                throw new NoHayPrestamosParaClienteException();
            }
        }

        public double TraerPromedioPrestamosPorCliente() {
            int countPrestamos = 0;
            int countClientes = 0;

            List<Prestamo> listPrest = _prestamoDatos.TraerTodosPrestamos();
            List<Cliente> listClient = _clienteDatos.TraerTodosClientesPorRegistro();

            foreach (var p in listPrest)
            {
                countPrestamos++;
            }
            foreach (var c in listClient)
            {
                countClientes++;
            }

            double prom = (double)countPrestamos / (double)countClientes;

            if (countPrestamos == 0 || countClientes == 0)
            {
                throw new ErrorDeCalculoException();
            }

            else
                return prom;
        }

    }
}
