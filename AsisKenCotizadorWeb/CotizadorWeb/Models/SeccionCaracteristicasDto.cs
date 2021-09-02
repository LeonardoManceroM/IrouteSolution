namespace CotizadorWeb.Models
{
    public class SeccionCaracteristicasDto
    {
        public int IdSeccion { get; set; }
        public int IdPlantillaC { get; set; }
        public int IdCaracteristica { get; set; }
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public bool AplicaMaternidad { get; set; }
        public bool AplicaNSolo { get; set; }
        public int Estado { get; set; }
    }
}