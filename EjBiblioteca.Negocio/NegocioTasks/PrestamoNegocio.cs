using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBiblioteca.Datos;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio.Exceptions;

namespace EjBiblioteca.Negocio.NegocioTasks
{
    public class PrestamoNegocio
    {
        private PrestamoDatos _prestamoDatos;

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
            ABMResult transaction = _prestamoDatos.Insertar(prest);

            // validar que ese ejemplar no este en un prestamo activo y exista
            // validar que el cliente exista

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public void ActualizarPrestamo(Prestamo prest)
        {
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

        public void EliminarPrestamo(Prestamo prest)
        {
            ABMResult transaction = _prestamoDatos.Eliminar(prest);

            // validar que ese prestamo exista

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
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

        public List<Prestamo> TraerPrestamosPorCliente()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }
    }
}
