using System.Data;

namespace Data.Entidades
{
    public class BeneficioPlan
    {
        public int IdBeneficio { get; set; }
        public string DescBeneficio { get; set; }
        public string Descripcion { get; set; }
        public int IdCatalogoBeneficio { get; set; }

        public static BeneficioPlan ConBeneficiosAdicionalesByPlanDR(IDataRecord dataR)
        {
            BeneficioPlan beneficios = new BeneficioPlan();
            beneficios.IdBeneficio = int.Parse(dataR["id_beneficio"].ToString());
            beneficios.DescBeneficio = dataR["beneficio"].ToString();
            beneficios.Descripcion = dataR["descripcion"].ToString();
            beneficios.IdCatalogoBeneficio = int.Parse(dataR["idcatalogobeneficio"].ToString());
            return beneficios;
        }


    

    }
}
