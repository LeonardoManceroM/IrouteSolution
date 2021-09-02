using System.Data;

namespace Data.Entidades
{
    public class TarifaGenero
    {
        public int IdTarifaGen { get; set; }
        public int IdPlan { get; set; }
        public string Genero { get; set; }
        public string DesGenero { get; set; }
        public decimal RangoG1 { get; set; }
        public decimal RangoG2 { get; set; }
        public decimal RangoG3 { get; set; }
        public decimal RangoG4 { get; set; }
        public decimal RangoG5 { get; set; }
        public decimal RangoG6 { get; set; }
        public decimal RangoG7 { get; set; }
        public decimal RangoG8 { get; set; }
        public decimal RangoG9 { get; set; }
        public decimal RangoG10 { get; set; }
        public decimal RangoG11 { get; set; }
        public decimal RangoG12 { get; set; }
        public decimal RangoG13 { get; set; }
        public decimal RangoG14 { get; set; }
        public decimal RangoG15 { get; set; }

        public static TarifaGenero ConTarifasGeneroByPlanDR(IDataRecord dataR)
        {
            TarifaGenero tarifasGenero = new TarifaGenero();
            tarifasGenero.IdTarifaGen = int.Parse(dataR["idtarifa"].ToString());
            tarifasGenero.IdPlan = int.Parse(dataR["idplan"].ToString());
            tarifasGenero.Genero = dataR["genero"].ToString();
            tarifasGenero.DesGenero = dataR["descripcion"].ToString();
            tarifasGenero.RangoG1 = decimal.Parse(dataR["rangog1"].ToString());
            tarifasGenero.RangoG2 = decimal.Parse(dataR["rangog2"].ToString());
            tarifasGenero.RangoG3 = decimal.Parse(dataR["rangog3"].ToString());
            tarifasGenero.RangoG4 = decimal.Parse(dataR["rangog4"].ToString());
            tarifasGenero.RangoG5 = decimal.Parse(dataR["rangog5"].ToString());
            tarifasGenero.RangoG6 = decimal.Parse(dataR["rangog6"].ToString());
            tarifasGenero.RangoG7 = decimal.Parse(dataR["rangog7"].ToString());
            tarifasGenero.RangoG8 = decimal.Parse(dataR["rangog8"].ToString());
            tarifasGenero.RangoG9 = decimal.Parse(dataR["rangog9"].ToString());
            tarifasGenero.RangoG10 = decimal.Parse(dataR["rangog10"].ToString());
            tarifasGenero.RangoG11 = decimal.Parse(dataR["rangog11"].ToString());
            tarifasGenero.RangoG12 = decimal.Parse(dataR["rangog12"].ToString());
            tarifasGenero.RangoG13 = decimal.Parse(dataR["rangog13"].ToString());
            tarifasGenero.RangoG14 = decimal.Parse(dataR["rangog14"].ToString());
            tarifasGenero.RangoG15 = decimal.Parse(dataR["rangog15"].ToString());
            return tarifasGenero;
        }

    }
}
