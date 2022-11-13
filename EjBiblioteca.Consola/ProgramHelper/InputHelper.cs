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

        public static DateTime IngresarFechaPasoAPaso(string input)
        {
            int dia = IngresarNumero<int>($"\r\nel día {input}:");
            int mes = IngresarNumero<int>($"\r\nel mes {input}:");
            int anio = IngresarNumero<int>($"\r\nel año {input}:");
            DateTime fecha = new DateTime(anio, mes, dia);
            return fecha;
        }

        public static string confirmacionABM(string aValidar, string accion)
        {
            string value;
            bool flag;

            Console.WriteLine($"\r\nUsted va a {accion} el {aValidar} anterior");
            Console.WriteLine("¿Desea confirmar?");

            do
            {
                Console.WriteLine($"\r\nIngrese: \r\n'S' para confirmar \r\n'N' para cancelar");
                value = Console.ReadLine();
                flag = ValidarHelper.ValidarConfirmacion(value.ToUpper());
            } while (flag == false);

            return value;
        }
        public static bool IngresarStatus(string input)
        {
                      
            bool flag = false;
            bool value = false;
            do
            {
                int valor = IngresarNumero<int>($"\r\nIngrese 1 para activo o 0 para inactivo {input}:");
                if (valor == 1)
                { 
                    value = true;
                    flag = true;
                }
                else if (valor == 0)
                {
                    value = false;
                    flag = true;
                }
                else 
                    Console.WriteLine("Valor ingresado incorrecto");
               
            } while (flag == false);
            return value;

        }
        public static T IngresarNumeroLong<T>(string input)
        {
            string value;
            long salidaCodigoLong = 0;
            
            bool flag;

            do
            {
                Console.WriteLine($"\r\nIngrese {input}:");
                value = Console.ReadLine();
                if (typeof(T) == typeof(long))
                {
                    flag = ValidarHelper.ValidarLong(value, ref salidaCodigoLong);
                }
                
                else flag = true;
            } while (flag == false);

            T valueReturn = (T)Convert.ChangeType(value, typeof(T));

            return valueReturn;
        }

    }
}
