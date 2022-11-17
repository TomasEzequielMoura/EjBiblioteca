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
        //Validación de negocio: Fecha inicio actividades: 01/07/2019. La fecha de alta de préstamo no puede ser anterior
        DateTime fechaInicioAct = DateTime.Parse("01/07/2019");

        public PrestamoNegocio()
        {
            _prestamoDatos = new PrestamoDatos();
        }

        //TODO: Armar reporte por cliente
        //public List<Prestamo> TraerPrestamosPorCliente(int idCliente)
        //{
        //    List<Prestamo> list = _prestamoDatos.GetPestamos(idCliente);

        //    return list;
        //}

        public List<Prestamo> TraerPrestamos()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }

        public void InsertarPrestamo(Prestamo prest)
        {
            if (prest.FechaPrestamo < fechaInicioAct)
            {
                throw new FechaAltaException();
            }
            else
            {
                ABMResult transaction = _prestamoDatos.Insertar(prest);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }


            // validar que ese ejemplar no este en un prestamo activo y exista
            // validar que el cliente exista

            //List<Cliente> list = clienteServicio.TraerClientesPorRegistro();

            //bool flag = false;

            //foreach (var item in list)
            //{
            //    if (item.Id == prest.Id)
            //    {
            //        flag = true;
            //    }
            //}

            //if (flag == true)
            //{
            //    ABMResult transaction = _prestamoDatos.Insertar(prest);

            //    if (!transaction.IsOk)
            //        throw new Exception(transaction.Error);
            //}
            //else
            //    throw new ClienteInexistente();

        }

        public void ActualizarPrestamo(Prestamo prest)
        {

            if (prest.FechaPrestamo < fechaInicioAct)
            {
                throw new FechaAltaException();
            }
            if (prest.FechaDevolucionReal < prest.FechaPrestamo || prest.FechaDevolucionTentativa < prest.FechaPrestamo)
            {
                throw new FechaAnteriorAltaPrest();
            }
            else {
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
                    ABMResult transaction = _prestamoDatos.Actualizar(prest);

                    if (!transaction.IsOk)
                        throw new Exception(transaction.Error);
                }
                else
                    throw new PrestamoInexistente();
            }
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
                throw new PrestamoInexistente();
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

        public List<Prestamo> TraerPrestamosPorCliente()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }
    }
}
