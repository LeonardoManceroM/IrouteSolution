using System.Data;

namespace Data.Entidades
{
    public class BeneficiosAdicionales
    {
        public int IdCatalogoBeneficio { get; set; }
        public int IdBeneficio { get; set; }
        public string DescBeneficio { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int IdPlan { get; set; }
        public string DescPlan { get; set; }
        public decimal Costo { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }

        //Estado del catalogo
        public int Estado { get; set; }

        public static BeneficiosAdicionales ConsultaBeneficiosAdicionalesDR(IDataRecord dataR)
        {
            BeneficiosAdicionales beneficios = new BeneficiosAdicionales();
            beneficios.IdBeneficio = int.Parse(dataR["idbeneficio"].ToString());
            beneficios.DescBeneficio = dataR["beneficio"].ToString();
            beneficios.IdProducto = int.Parse(dataR["idproducto"].ToString());
            beneficios.DescProducto = dataR["producto"].ToString();
            beneficios.IdPlan = int.Parse(dataR["idplan"].ToString());
            beneficios.DescPlan = dataR["plan"].ToString();
            beneficios.Costo = decimal.Parse(dataR["costo"].ToString());
            beneficios.Observacion = dataR["observacion"].ToString();
            beneficios.Descripcion = dataR["descripcion"].ToString();
            beneficios.IdCatalogoBeneficio = int.Parse(dataR["idcatalogobeneficio"].ToString());
            return beneficios;
        }

        public static BeneficiosAdicionales ConCatalogosBeneficiosDR(IDataRecord dataR)
        {
            BeneficiosAdicionales beneficios = new BeneficiosAdicionales();
            beneficios.IdCatalogoBeneficio = int.Parse(dataR["id_catalogo"].ToString());
            beneficios.DescBeneficio = dataR["beneficio"].ToString();
            beneficios.Costo = decimal.Parse(dataR["costo"].ToString());
            return beneficios;
        }

    }
}
