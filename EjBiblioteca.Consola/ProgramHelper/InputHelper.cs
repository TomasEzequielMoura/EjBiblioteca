using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramHelper
{
    public class InputHelper
    {
        public static T IngresarNumero<T>(string input)
        {
            string value;
            int salidaCodigoInt = 0;
            double salidaCodigoDouble = 0;
            bool flag;

            do
            {
                Console.WriteLine($"\r\nIngrese {input}:");
                value = Console.ReadLine();
                if (typeof(T) == typeof(int))
                {
                    flag = ValidarHelper.ValidarEntero(value, ref salidaCodigoInt);
                }
                else if (typeof(T) == typeof(double)) flag = ValidarHelper.ValidarDouble(value, ref salidaCodigoDouble);
                else flag = true;
            } while (flag == false);

            T valueReturn = (T)Convert.ChangeType(value, typeof(T));

            return valueReturn;
        }

        public static DateTime IngresarFechaString(string input)
        {
            string value;
            DateTime salidaCodigoDateTime = new DateTime(2012, 12, 31, 16, 45, 0);
            bool flag;

            do
            {
                Console.WriteLine($"\r\nIngrese {input}:");
                value = Console.ReadLine();
                flag = ValidarHelper.ValidarFecha(value, ref salidaCodigoDateTime);
            } while (flag == false);

            DateTime valueReturn = DateTime.Parse(value);

            return valueReturn;
        }

        public static DateTime IngresarFechaPasoAPaso()
        {
            int dia = IngresarNumero<int>("el dia de alta del libro");
            int mes = IngresarNumero<int>("el mes de alta del libro");
            int anio = IngresarNumero<int>("el año de alta del libro");
            DateTime fechaAlta = new DateTime(anio, mes, dia);
            return fechaAlta;
        }
    }
}
