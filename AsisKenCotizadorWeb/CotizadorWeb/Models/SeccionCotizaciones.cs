using Data.Entidades;
using System;
using System.Collections.Generic;

namespace CotizadorWeb.Models
{
    public class SeccionCotizaciones
    {
        public int IdCotizacion { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public bool EstadoCotizacion { get; set; }
        public string Cliente { get; set; }
        public int TitularEdad { get; set; }
        public int ConyugueEdad { get; set; }
        public int[] Dependientes { get; set; }
        public int[] IdBeneficiosAdicionales { get; set; }
        public int[] IdCatalogosBeneficios { get; set; }
        public DateTime TitularNacimiento { get; set; }
        public string TitularGenero { get; set; }
        public bool TitularMaternidad { get; set; }
        public bool TitularBeneficio { get; set; }
        public DateTime ConyugueFechaNacimiento { get; set; }
        public string ConyugueGenero { get; set; }
        public int IdPlan { get; set; }
        public string NombrePlan { get; set; }
        public string DescEstadoPlan { get; set; }
        //Datos Agente
        public int IdUsuario { get; set; }
        public string Agente { get; set; }
        public string Telefono { get; set; }
        public string Agencia { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
        public List<SeccionBloqueDto> SeccionBloquesPlantillas { get; set; }
        public CalculaTarifasResultado TarifasResultado { get; set; }

        //Pool
        public string Actividad { get; set; }
        public List<CotizacionCategoriaPool> CategoriasPools { get; set; }

        //Pie de pagina de PDF
        public string Conf_Observaciones_Pdf { get; set; }
        public int IdProducto { get; set; }

    }
}