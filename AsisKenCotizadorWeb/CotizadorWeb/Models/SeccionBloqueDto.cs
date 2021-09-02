using System.Collections.Generic;

namespace CotizadorWeb.Models
{
    public class SeccionBloqueDto
    {
        public int IdSeccion { get; set; }
        public string Seccion { get; set; }
        public List<SeccionCaracteristicasDto> Plantillas { get; set; }
    }


}