using System.Data;

namespace Data.Entidades
{
    public class Configuraciones
    {
        public int IdConfiguracion { get; set; }
        public string DescConfiguracion { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public string Observacion { get; set; }

        public static Configuraciones ConsultaConfiguracionesDR(IDataRecord dataR)
        {
            Configuraciones configuraciones = new Configuraciones();
            configuraciones.IdConfiguracion = int.Parse(dataR["idconfiguracion"].ToString());
            configuraciones.DescConfiguracion = dataR["configuraciones"].ToString();
            configuraciones.Descripcion = dataR["descripcion"].ToString();
            configuraciones.Valor = decimal.Parse(dataR["valor"].ToString());
            configuraciones.Observacion = dataR["observacion"].ToString();
            return configuraciones;
        }
    }
}
