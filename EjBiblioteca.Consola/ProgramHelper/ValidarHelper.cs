﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EjBiblioteca.Consola
{
    public static class ValidarHelper
    {

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

        public static bool ValidarLong(string numero, ref long salida)
        {
            bool flag = false;

            if (!long.TryParse(numero, out salida))
            {
                Console.WriteLine("Usted debe ingresar un número tipo long.");
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

        public static bool ValidarDouble(string registro, ref double salida)
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

        public static bool ValidarFecha(string stringValue, ref DateTime salida)
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

        public static bool ValidarConfirmacion(string stringConfirmacion)
        {
            bool flag = false;

            if (stringConfirmacion == "N" || stringConfirmacion == "S")
            {
                flag = true;
            }
            else
                Console.WriteLine("El valor ingresado no corresponde a una 'S' o 'N'.");

            return flag;
        }

        public static bool EsAlfabetico(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$");
        }
        public static bool EsAlfanumerico(string input)
        {
            if (input == "")
            {
                return false;
            }
            if (input.All(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x)))
                return true;
            else 
                return false;
        }

        public static bool IsValidEmail(string email)
        {
            //para una validación muy simple sería así:
            //return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            //lo siguiente valida dominio tmb

            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}