using System.Data;

namespace Data.Entidades
{
    public class TarifaNiñoSolo
    {
        public int IdTarifaSolo { get; set; }
        public int IdPlan { get; set; }
        public decimal RangoN1 { get; set; }
        public decimal RangoN2 { get; set; }

        public static TarifaNiñoSolo ConTarifasNSoloDR(IDataRecord dataR)
        {
            TarifaNiñoSolo tarifaNSolo = new TarifaNiñoSolo();
            tarifaNSolo.IdTarifaSolo = int.Parse(dataR["idtarifasolo"].ToString());
            tarifaNSolo.IdPlan = int.Parse(dataR["idplan"].ToString());
            tarifaNSolo.RangoN1 = decimal.Parse(dataR["rangon1"].ToString());
            tarifaNSolo.RangoN2 = decimal.Parse(dataR["rangon2"].ToString());
            return tarifaNSolo;
        }

    }
}
