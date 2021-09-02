using System;
using System.Data;

namespace Data.Entidades
{
    public class CotizacionesPool
    {
        public int IdCotizacion { get; set; }
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public DateTime FechaCotiza { get; set; }
        public int IdPlan { get; set; }
        public bool Estado { get; set; }
        public string DescEstado { get; set; } //Activo Inactivo
        public decimal ValorMensual { get; set; }
        public decimal ValorTrimestral { get; set; }
        public decimal ValorSemestral { get; set; }
        public decimal ValorAnual { get; set; }
        public decimal ValorContado { get; set; }
        public string NombrePlan { get; set; } 
        public string DescEstadoPlan { get; set; } //Activo Inactivo
        public int IdRegion { get; set; }
        public string Region { get; set; }

        public static CotizacionesPool dataFromRecord(IDataRecord dr)
        {
            CotizacionesPool cotizacionPool = new CotizacionesPool { 
                Actividad=dr["actividad"].ToString(),
                Cliente=dr["cliente"].ToString(),
                DescEstado=bool.Parse(dr["estado"].ToString())?"Activo":"Inactivo",
                DescEstadoPlan=int.Parse(dr["estadoplan"].ToString()).Equals(1)? "Activo" : "Inactivo",
                Estado = bool.Parse(dr["estado"].ToString()),
                FechaCotiza=DateTime.Parse(dr["fechacotiza"].ToString()),
                IdCotizacion=int.Parse(dr["idcotizacionpool"].ToString()),
                IdPlan=int.Parse(dr["idplan"].ToString()),
                IdUsuario=int.Parse(dr["idusuario"].ToString()),
                NombrePlan=dr["nombreplan"].ToString(),
                ValorAnual=decimal.Parse(dr["valoranual"].ToString()),
                ValorContado= decimal.Parse(dr["valorcontado"].ToString()),
                ValorMensual= decimal.Parse(dr["valormensual"].ToString()),
                ValorSemestral= decimal.Parse(dr["valorsemestral"].ToString()),
                ValorTrimestral = decimal.Parse(dr["valortrimestral"].ToString()),
                IdRegion = int.Parse(dr["idregion"].ToString()),
                Region = dr["region"].ToString()
        };

            return cotizacionPool;
        }
    }
}
