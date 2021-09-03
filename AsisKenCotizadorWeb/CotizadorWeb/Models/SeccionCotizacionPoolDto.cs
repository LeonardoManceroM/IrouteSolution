using Data.Entidades;
using System;
using System.Collections.Generic;

namespace CotizadorWeb.Models
{
    public class SeccionCotizacionPoolDto
    {
        public string NombrePlan { get; set; }
        public int IdCotizacion { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public List<CotizacionCategoriaPool> CategoriasPools { get; set; }
        //Datos Agente
        public int IdUsuario { get; set; }
        public string Agente { get; set; }
        public string Telefono { get; set; }
        public string Agencia { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
        public int VersionPlan { get; set; }
        public string VersionPlanTexto { get; set; }
        public List<SeccionBloqueDto> SeccionBloquesPlantillas { get; set; }
        public CalculaTarifasResultado TarifasResultado { get; set; }
        
        //Pie de pagina de PDF
        public string Conf_Observaciones_Pdf { get; set; }
    }
}