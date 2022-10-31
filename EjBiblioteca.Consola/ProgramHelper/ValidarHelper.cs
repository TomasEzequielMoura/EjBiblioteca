using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola
{
    public static class ValidarHelper
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
                    flag = ValidarEntero(value, ref salidaCodigoInt);
                }
                else if (typeof(T) == typeof(double)) flag = ValidarDouble(value, ref salidaCodigoDouble);
                else flag = true;
            } while (flag == false);

            T valueReturn = (T)Convert.ChangeType(value, typeof(T));

            return valueReturn;
        }

        public static bool ValidarEntero(string numero, ref int salida)
        {
            bool flag = false;

            if (!int.TryParse(numero, out salida))
            {
                Console.WriteLine("Usted debe ingresar un número entero.");
            }
            else if (salida <= 0)
            {
                Console.WriteLine("Usted debe ingresar un número mayor que cero.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        private static bool ValidarDouble(string registro, ref double salida)
        {
            bool flag = false;

            if (registro.Contains("."))
            {
                Console.WriteLine("Utilice las ',' (comas) para los centavos. NO utilice puntos bajo ningun punto de vista");
            }
            else if (!double.TryParse(registro, out salida))
            {
                Console.WriteLine("Usted debe ingresar un valor numérico.");
            }
            else if (salida <= 0)
            {
                Console.WriteLine("Usted debe ingresar un numero positivo.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static DateTime IngresarFecha(string input)
        {
            string value;
            DateTime salidaCodigoDateTime = new DateTime(2012, 12, 31, 16, 45, 0);
            bool flag;

            do
            {
                Console.WriteLine($"\r\nIngrese {input}:");
                value = Console.ReadLine();
                flag = ValidarFecha(value, ref salidaCodigoDateTime);
            } while (flag == false);

            DateTime valueReturn = DateTime.Parse(value);

            return valueReturn;
        }

        private static bool ValidarFecha(string stringValue, ref DateTime salida)
        {
            bool flag = false;

            if (!DateTime.TryParse(stringValue, out salida))
            {
                Console.WriteLine("Usted debe ingresar un valor fecha.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }
    }
}