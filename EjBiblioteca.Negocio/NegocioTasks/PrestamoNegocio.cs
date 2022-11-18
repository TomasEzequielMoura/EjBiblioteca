using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBiblioteca.Datos;
using EjBiblioteca.Entidades;
using EjBiblioteca.Entidades.Exceptions;
using EjBiblioteca.Entidades.Persona;
using EjBiblioteca.Negocio.Exceptions;

namespace EjBiblioteca.Negocio.NegocioTasks
{
    public class PrestamoNegocio
    {
        private PrestamoDatos _prestamoDatos;
        private ClienteDatos _clienteDatos;

        //Validación de negocio: Fecha inicio actividades: 01/07/2019. La fecha de alta de préstamo no puede ser anterior
        DateTime fechaInicioAct = DateTime.Parse("01/07/2019");

        public PrestamoNegocio()
        {
            _prestamoDatos = new PrestamoDatos();
            _clienteDatos = new ClienteDatos();
        }

        public List<Prestamo> TraerPrestamos()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }

        
        public void InsertarPrestamo(Prestamo prest)
        {
            //validamos que el cliente no tenga mas de 5 préstamos
            int cantidadPrestamos = 0;
            bool flag = true;

            foreach (var x in TraerPrestamos())
            {
                if (x.IdCliente == prest.IdCliente) {
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

                //bool flag = false;

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
            EjemplarNegocio ejemplarServicio = new EjemplarNegocio();
            List<Ejemplar> listEjemplar = ejemplarServicio.TraerTodosLosEjemplaresPorLibro(idLibro);

            List<Prestamo> listPrestamo = _prestamoDatos.TraerTodosPrestamos();

            List<Prestamo> listPrestamoPorLibro = new List<Prestamo>();

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
            // TODO: MUCHAS VALIDACIONES
            return listPrestamoPorLibro;
        }

        public List<Prestamo> TraerTodosPrestamosPorCliente(int idCliente)
        {
            List<Prestamo> listPrestamo = _prestamoDatos.TraerTodosPrestamos();

            List<Prestamo> listPrestamoPorCliente = new List<Prestamo>();

            foreach (var itemPrestamo in listPrestamo)
            {
                if (itemPrestamo.IdCliente == idCliente)
                {
                    listPrestamoPorCliente.Add(itemPrestamo);
                }
            }
            // TODO: MUCHAS VALIDACIONES
            return listPrestamoPorCliente;
        }
        
    }
}
