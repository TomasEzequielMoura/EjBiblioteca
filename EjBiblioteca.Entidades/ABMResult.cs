using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Entidades
{
    public class ABMResult
    {
        public bool IsOk { get; set; }
        public int Id { get; set; }
        public string Error { get; set; }
    }
}
