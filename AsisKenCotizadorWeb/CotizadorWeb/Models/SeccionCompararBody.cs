using System.Collections.Generic;

namespace CotizadorWeb.Models
{
    public class SeccionCompararBody
    {
        public int IdSeccion { get; set; }
        public int IdPlantillaC { get; set; }
        public int IdCaracteristica { get; set; }
        public string Descripcion { get; set; }
        public List<string> Valor { get; set; }
        public bool AplicaMaternidad { get; set; }
        public bool AplicaNSolo { get; set; }
        //public int Estado { get; set; }

    }
}