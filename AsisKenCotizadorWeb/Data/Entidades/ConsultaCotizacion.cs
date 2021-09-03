using System;
using System.Data;

namespace Data.Entidades
{
    public class ConsultaCotizacion
    {
        public int IdCotizacion { get; set; }
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public int IdPlan { get; set; }
        public bool Estado { get; set; }
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
        public string DescEstadoPlan { get; set; }
        public int Edad { get; set; }
        public int IdBeneficio { get; set; }
        public int IdCatalogoBeneficio { get; set; }
        public string Actividad { get; set; }
        public int IdCategoria { get; set; }
        public int Cantidad { get; set; }
        public bool TitularBeneficio { get; set; }
        public int IdProducto { get; set; }
        public string Region { get; set; }

        public static ConsultaCotizacion ConsultaCotizacionDr(IDataRecord dr)
        {
            ConsultaCotizacion consultaCotizacion = new ConsultaCotizacion();

            consultaCotizacion.IdCotizacion = int.Parse(dr["idcotizacion"].ToString());
            consultaCotizacion.FechaCotizacion = DateTime.Parse(dr["fechacotiza"].ToString());
            consultaCotizacion.IdUsuario = int.Parse(dr["idusuario"].ToString());
            consultaCotizacion.IdPlan = int.Parse(dr["idplan"].ToString());
            consultaCotizacion.Cliente = dr["cliente"].ToString();
            consultaCotizacion.Actividad = dr["actividad"].ToString();
            consultaCotizacion.Estado = bool.Parse(dr["estado"].ToString());
            consultaCotizacion.TitularNacimiento = DateTime.Parse(dr["titularfechanac"].ToString());
            consultaCotizacion.TitularGenero = string.IsNullOrEmpty(dr["titulargenero"].ToString())?' ':char.Parse(dr["titulargenero"].ToString());
            consultaCotizacion.TitularEdad = int.Parse(dr["titularedad"].ToString());
            consultaCotizacion.TitularMaternidad = bool.Parse(dr["titularmaternidad"].ToString());
            consultaCotizacion.TitularBeneficio = bool.Parse(dr["titularbeneficio"].ToString());
            consultaCotizacion.ConyugueEdad = int.Parse(dr["conyugueedad"].ToString());
            consultaCotizacion.ConyugueGenero = string.IsNullOrEmpty(dr["conyuguegenero"].ToString())?' ':char.Parse(dr["conyuguegenero"].ToString());
            consultaCotizacion.ConyugueFechaNacimiento = DateTime.Parse(dr["conyuguefechanac"].ToString());
            consultaCotizacion.ValorMensual = decimal.Parse(dr["valormensual"].ToString());
            consultaCotizacion.ValorTrimestral = decimal.Parse(dr["valortrimestral"].ToString());
            consultaCotizacion.ValorSemestral = decimal.Parse(dr["valorsemestral"].ToString());
            consultaCotizacion.ValorAnual = decimal.Parse(dr["valoranual"].ToString());
            consultaCotizacion.ValorContado = decimal.Parse(dr["valorcontado"].ToString());
            consultaCotizacion.NombrePlan = dr["nombreplan"].ToString();
            consultaCotizacion.DescEstadoPlan = int.Parse(dr["estadoplan"].ToString())==1 ? "Activo": "Inactivo";
            consultaCotizacion.Edad = int.Parse(dr["edad"].ToString());
            consultaCotizacion.IdBeneficio = int.Parse(dr["idbeneficio"].ToString());
            consultaCotizacion.IdCatalogoBeneficio = int.Parse(dr["idbeneficiocat"].ToString());
            consultaCotizacion.IdCategoria = int.Parse(dr["idcategoria"].ToString());
            consultaCotizacion.Cantidad = int.Parse(dr["cantidad"].ToString());
            consultaCotizacion.IdProducto = int.Parse(dr["idproducto"].ToString());
            consultaCotizacion.Region = dr["region"].ToString();

            return consultaCotizacion;
        }       
    }
}
