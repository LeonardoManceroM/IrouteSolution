using Data.Entidades;
using System;
using System.Collections.Generic;

namespace CotizadorWeb.Models
{
    public class SeccionCompararPoolDto
    {
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public List<CotizacionCategoriaPool> CategoriasPools { get; set; }
        //Datos Agente
        public int IdUsuario { get; set; }
        public string Agente { get; set; }
        public string Telefono { get; set; }
        public string Agencia { get; set; }
        public string Direccion { get; set; }
        public List<int> IdCotizacion { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public List<string> NombrePlan { get; set; }
        public List<SeccionCompararBloqueDto> Caracteristicas { get; set; }
        public List<CalculaTarifasResultado> Totales { get; set; }

        //Pie de pagina de PDF
        public string Conf_Observaciones_Pdf { get; set; }
    }
}