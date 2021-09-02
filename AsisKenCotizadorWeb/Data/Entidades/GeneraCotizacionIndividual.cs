using System;

namespace Data.Entidades
{
    public class GeneraCotizacionIndividual
    {
        public int IdCotizacion { get; set; }
        public int IdPlan { get; set; }
        public bool GuardarCotizacion { get; set; }
        //Datos para el calculo de las tarifas
        public bool TitularBeneficio { get; set; }
        public int TitularEdad { get; set; }
        public string TitularGenero { get; set; }
        public bool TitularMaternidad { get; set; }
        public string ConyugueGenero { get; set; }
        public int ConyugueEdad { get; set; }
        public int[] Dependientes { get; set; }
        public int[] CoberturasAdicionales { get; set; }
        public int[] CatBeneficiosAdicionales { get; set; }
        //SOLO PARA EL CONTROLADOR JGU
        public int ContadorPersonas { get; set; }
        //Datos para el ingreso de la cotizacion

        public bool Estado { get; set; }
        public DateTime TitularNacimiento { get; set; }
        public DateTime ConyugueFechaNacimiento { get; set; }
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }

    }
}
