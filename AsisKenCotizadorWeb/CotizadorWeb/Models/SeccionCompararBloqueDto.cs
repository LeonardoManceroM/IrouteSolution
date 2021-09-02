using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class SeccionCompararBloqueDto
    {
        public int IdSeccion { get; set; }
        public string Seccion { get; set; }
        public List<SeccionCompararBody> CompararCaracteristicas { get; set; }


    }
}