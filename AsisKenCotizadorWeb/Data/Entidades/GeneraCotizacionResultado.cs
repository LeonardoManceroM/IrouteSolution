using System;

namespace Data.Entidades
{
    public class GeneraCotizacionResultado
    {
        public string DescPlan { get; set; }
        public int IdCotizacion { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public decimal ValorMensual { get; set; }
        public decimal ValorTrimestral { get; set; }
        public decimal ValorSemestral { get; set; }
        public decimal ValorAnual { get; set; }
        public decimal ValorContado { get; set; }
        public string Agente { get; set; }
        public string Telefono { get; set; }
        public string Agencia { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
        public int Version_Num { get; set; }
        public string Version_Text { get; set; }
    }
}
