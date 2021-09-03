using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    // Mantenedor de Rango de Edades Generales
    public class AnotherRateConfigModel
    {
        public int Id { get; set; }
        public string Rango { get; set; }
        public int ValorMinimo { get; set; }
        public int ValorMaximo { get; set; }
        public int Estado { get; set; }
    }
}