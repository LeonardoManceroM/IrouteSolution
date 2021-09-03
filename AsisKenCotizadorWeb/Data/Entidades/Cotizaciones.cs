using System;
using System.Data;

namespace Data.Entidades
{
    public class Cotizaciones
    {
        public int IdContizacion { get; set; }
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public int IdPlan { get; set; }
        public bool Estado { get; set; }
        public bool TitularBeneficio { get; set; }
        public DateTime TitularNacimiento { get; set; }
        public char TitularGenero { get; set; }
        public int TitularEdad { get; set; }
        public bool TitularMaternidad { get; set; }
        public DateTime ConyugueFechaNacimiento { get; set; }
        public char ConyugueGenero { get; set; }
        public int ConyugueEdad { get; set; }
        public decimal ValorMensual { get; set; }
        public decimal ValorTrimestral { get; set; }
        public decimal ValorSemestral { get; set; }
        public decimal ValorAnual { get; set; }
        public decimal ValorContado { get; set; }
        public string NombrePlan { get; set; }
        public string EstadoDescripcion { get; set; }//1--->activo 0-->inactivo
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescEstadoPlan { get; set; }
        public bool Guardada { get; set; }
        public int IdRegion { get; set; }
        public string Region { get; set; }

        public static Cotizaciones FromDataRecord(IDataRecord dr)
        {
            Cotizaciones cotizacion = new Cotizaciones();
            try
            {

                cotizacion.Cliente = dr["cliente"].ToString();
                cotizacion.ConyugueEdad = int.Parse(dr["conyugueedad"].ToString());
                cotizacion.ConyugueFechaNacimiento = DateTime.Parse(dr["conyuguefechanac"].ToString());
                cotizacion.ConyugueGenero = string.IsNullOrEmpty(dr["conyuguegenero"].ToString())?' ': char.Parse(dr["conyuguegenero"].ToString());
                cotizacion.Estado = bool.Parse(dr["estado"].ToString());
                cotizacion.EstadoDescripcion = bool.Parse(dr["estado"].ToString()) ? "Activo" : "Inactivo";
                cotizacion.FechaCotizacion = DateTime.Parse(dr["fechacotiza"].ToString());
                cotizacion.IdContizacion = int.Parse(dr["idcotizacion"].ToString());
                cotizacion.IdPlan = int.Parse(dr["idplan"].ToString());
                cotizacion.IdUsuario = int.Parse(dr["idusuario"].ToString());
                cotizacion.NombrePlan = dr["plan"].ToString();
                cotizacion.IdProducto = int.Parse(dr["idproducto"].ToString());
                cotizacion.NombreProducto = dr["nombreProducto"].ToString();
                cotizacion.TitularBeneficio = bool.Parse(dr["titularbeneficio"].ToString());
                cotizacion.TitularEdad = int.Parse(dr["titularedad"].ToString());
                cotizacion.TitularGenero = string.IsNullOrEmpty(dr["titulargenero"].ToString()) ? ' ' : char.Parse(dr["titulargenero"].ToString());
                cotizacion.TitularMaternidad = bool.Parse(dr["titularmaternidad"].ToString());
                cotizacion.TitularNacimiento = DateTime.Parse(dr["titularfechanac"].ToString());
                cotizacion.ValorAnual = decimal.Parse(dr["valoranual"].ToString());
                cotizacion.ValorContado = decimal.Parse(dr["valorcontado"].ToString());
                cotizacion.ValorMensual = decimal.Parse(dr["valormensual"].ToString());
                cotizacion.ValorSemestral = decimal.Parse(dr["valorsemestral"].ToString());
                cotizacion.ValorTrimestral = decimal.Parse(dr["valortrimestral"].ToString());
                cotizacion.DescEstadoPlan = int.Parse(dr["estadoPlan"].ToString()).Equals(1) ? "Activo" : "Inactivo";
                cotizacion.Guardada = bool.Parse(dr["guardada"].ToString());
                cotizacion.IdRegion = int.Parse(dr["idregion"].ToString());
                cotizacion.Region = dr["region"].ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return cotizacion;
        }
    }
}
