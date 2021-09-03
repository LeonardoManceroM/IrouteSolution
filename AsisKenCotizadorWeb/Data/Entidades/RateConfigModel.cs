using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class RateConfigModel
    {
        public int Id { get; set; }
        public string Rango { get; set; }
        public int ValorMinimo { get; set; }
        public int ValorMaximo { get; set; }
        public int Estado { get; set; }
    }
}
