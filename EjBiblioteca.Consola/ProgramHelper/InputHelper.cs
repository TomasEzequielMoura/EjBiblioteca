using EjBiblioteca.Entidades.Exceptions;
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
            long salidaCodigoLong = 0;
            bool flag;

            do
            {
                Console.WriteLine($"\r\nIngrese {input}:");
                value = Console.ReadLine();
                if (typeof(T) == typeof(int))
                {
                    flag = ValidarHelper.ValidarEntero(value, ref salidaCodigoInt);
                }
                else if (typeof(T) == typeof(long))
                {
                    flag = ValidarHelper.ValidarLong(value, ref salidaCodigoLong);
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
            int dia = IngresarNumero<int>($"el día{input}");
            int mes = IngresarNumero<int>($"el mes{input}");
            int anio = IngresarNumero<int>($"el año{input}");
            try
            {
                DateTime fecha = new DateTime(anio, mes, dia);
                return fecha;
            }
            catch (Exception)
            {
                throw new FechaInvalida();
            }
        }

        public static int IngresarDNI(string input)
        {
            bool flagValidacion = false;
            int dni;
            do
            {
                dni = IngresarNumero<int>(input);
                if (dni.ToString().Length > 8 || dni.ToString().Length < 7)
                {
                    Console.WriteLine("ERROR. El DNI debe ser de 7 u 8 caracteres");
                }
                else {
                    flagValidacion = true;
                }

            } while (flagValidacion == false);

            return dni;
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
                Console.WriteLine("\r\nIngrese 1 para activo o 0 para inactivo");
                string valor = Console.ReadLine();
                if (valor == "1")
                { 
                    value = true;
                    flag = true;
                }
                else if (valor == "0")
                {
                    value = false;
                    flag = true;
                }
                else 
                    Console.WriteLine("Valor ingresado incorrecto");
               
            } while (flag == false);
            return value;

        }
        public static string IngresarString(string input)
        {
            string texto = "";
            do
            {
                Console.WriteLine($"\r\nIngrese {input}");
                texto = Console.ReadLine();
                if (!ValidarHelper.EsNumero(texto))
                {
                    Console.WriteLine("Ingreso inválido. Por favor, ingrese solo letras");
                }
            } while (!ValidarHelper.EsNumero(texto));
            return texto;
        }

        public static string IngresarStringYNumeros(string input)
        {
            string texto = "";
            do
            {
                Console.WriteLine($"\r\nIngrese {input}");
                texto = Console.ReadLine();
                if (!ValidarHelper.EsAlfanumerico(texto))
                {
                    Console.WriteLine("Ingreso inválido. Por favor, ingrese solo letras y números");
                }
            } while (!ValidarHelper.EsAlfanumerico(texto));
            return texto;
        }

        public static string IngresarEmail(string input)
        {
            string email = "";
            do
            {
                Console.WriteLine($"\r\nIngrese {input}");
                email = Console.ReadLine();
                if (!ValidarHelper.IsValidEmail(email))
                {
                    Console.WriteLine("Ingreso inválido. Por favor, ingrese un email válido");
                }
            } while (!ValidarHelper.IsValidEmail(email));
            return email;
        }

    }
}
