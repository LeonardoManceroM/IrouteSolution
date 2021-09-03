using System.Data;

namespace Data.Entidades
{
    public class CotizacionDependiente
    {
        public int IdCotizacionDependiente { get; set; }
        public int IdCotizacion { get; set; }
        public int Edad { get; set; }
        public static CotizacionDependiente ConsultaFromDataRecord(IDataRecord dr)
        {
            CotizacionDependiente cotizacion = new CotizacionDependiente
            {
                Edad = int.Parse(dr["edad"].ToString()),
                IdCotizacion = int.Parse(dr["idcotizacion"].ToString()),
                IdCotizacionDependiente = int.Parse(dr["idcotizaciondep"].ToString())
            };
            
            return cotizacion;
        }
    }
}
