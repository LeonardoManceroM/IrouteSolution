using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class CalculaTarifasResultado
    {
        public decimal ValorMensual { get; set; }
        public decimal ValorTrimestral { get; set; }
        public decimal ValorSemestral { get; set; }
        public decimal ValorAnual { get; set; }
        public decimal ValorContado { get; set; }
    }
}
