using System.Data;

namespace Data.Entidades
{
    public class TarifaGenDependiente
    {
        public string TarifaDep { get; set; }
        public string DescripcionDep { get; set; }
        public int IdTarifa { get; set; }
        public int IdPlan { get; set; }
        public decimal RangoD1 { get; set; }
        public decimal RangoD2 { get; set; }

        public static TarifaGenDependiente ConTarifasGenDependientesDR(IDataRecord dataR)
        {
            TarifaGenDependiente tarifasGeneroD = new TarifaGenDependiente();
            tarifasGeneroD.IdTarifa = int.Parse(dataR["idtarifa"].ToString());
            tarifasGeneroD.IdPlan = int.Parse(dataR["idplan"].ToString());
            tarifasGeneroD.TarifaDep = dataR["tarifa"].ToString();
            tarifasGeneroD.DescripcionDep = dataR["descripcion"].ToString();
            tarifasGeneroD.RangoD1 = decimal.Parse(dataR["rangod1"].ToString());
            tarifasGeneroD.RangoD2 = decimal.Parse(dataR["rangod2"].ToString());
            return tarifasGeneroD;
        }
    }
}
