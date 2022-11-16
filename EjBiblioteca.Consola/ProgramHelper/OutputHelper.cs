
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramHelper
{
    public static class OutputHelper
    {
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', 180));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (180 - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            if (text == null) {
                string textVacio = "--";
                string esaciosDerecha = textVacio.PadRight((width+3)/2);
                string esaciosIzquierda = esaciosDerecha.PadLeft(width);

                return esaciosIzquierda;    
            }
            else
            {
                text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
                if (string.IsNullOrEmpty(text))
                {
                    return new string(' ', width);
                }
                else
                {
                    return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
                }
            }

        }
    }
}
