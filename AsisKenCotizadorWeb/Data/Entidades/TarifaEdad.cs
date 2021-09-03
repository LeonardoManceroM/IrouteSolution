using System.Data;

namespace Data.Entidades
{
    public class TarifaEdad
    {
        public int IdTarifaEdad { get; set; }
        public int IdPlan { get; set; }
        public decimal RangoE1 { get; set; }
        public decimal RangoE2 { get; set; }
        public decimal RangoE3 { get; set; }
        public decimal RangoE4 { get; set; }
        public decimal RangoE5 { get; set; }
        public decimal RangoE6 { get; set; }
        public decimal RangoE7 { get; set; }
        public decimal RangoE8 { get; set; }
        public decimal RangoE9 { get; set; }
        public decimal RangoE10 { get; set; }
        public decimal RangoE11 { get; set; }
        public decimal RangoE12 { get; set; }
        public decimal RangoE13 { get; set; }
        public decimal RangoE14 { get; set; }
        public decimal RangoE15 { get; set; }

        public static TarifaEdad ConTarifasEdadesDR(IDataRecord dataR)
        {
            TarifaEdad tarifaEdades = new TarifaEdad();
            tarifaEdades.IdTarifaEdad = int.Parse(dataR["idtarifa"].ToString());
            tarifaEdades.IdPlan = int.Parse(dataR["idplan"].ToString());
            tarifaEdades.RangoE1 = decimal.Parse(dataR["rangoe1"].ToString());
            tarifaEdades.RangoE2 = decimal.Parse(dataR["rangoe2"].ToString());
            tarifaEdades.RangoE3 = decimal.Parse(dataR["rangoe3"].ToString());
            tarifaEdades.RangoE4 = decimal.Parse(dataR["rangoe4"].ToString());
            tarifaEdades.RangoE5 = decimal.Parse(dataR["rangoe5"].ToString());
            tarifaEdades.RangoE6 = decimal.Parse(dataR["rangoe6"].ToString());
            tarifaEdades.RangoE7 = decimal.Parse(dataR["rangoe7"].ToString());
            tarifaEdades.RangoE8 = decimal.Parse(dataR["rangoe8"].ToString());
            tarifaEdades.RangoE9 = decimal.Parse(dataR["rangoe9"].ToString());
            tarifaEdades.RangoE10 = decimal.Parse(dataR["rangoe10"].ToString());
            tarifaEdades.RangoE11 = decimal.Parse(dataR["rangoe11"].ToString());
            tarifaEdades.RangoE12 = decimal.Parse(dataR["rangoe12"].ToString());
            tarifaEdades.RangoE13 = decimal.Parse(dataR["rangoe13"].ToString());
            tarifaEdades.RangoE14 = decimal.Parse(dataR["rangoe14"].ToString());
            tarifaEdades.RangoE15 = decimal.Parse(dataR["rangoe15"].ToString());
            return tarifaEdades;
        }

    }
}
