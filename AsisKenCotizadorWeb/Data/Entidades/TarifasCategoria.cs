using System.Data;

namespace Data.Entidades
{
    public class TarifasCategoria
    {
        public int IdTarifaCat { get; set; }
        public int IdPlan { get; set; }
        public int IdCategoria { get; set; }
        public string DescCategoria { get; set; }
        public decimal Rango1 { get; set; }
        public decimal Rango2 { get; set; }
        public decimal Rango3 { get; set; }
        public decimal Rango4 { get; set; }
        public decimal Rango5 { get; set; }
        public decimal Rango6 { get; set; }
        public decimal Rango7 { get; set; }
        public decimal Rango8 { get; set; }
        public decimal Rango9 { get; set; }
        public decimal Rango10 { get; set; }
        public decimal Rango11 { get; set; }
        public decimal Rango12 { get; set; }
        public decimal Rango13 { get; set; }
        public decimal Rango14 { get; set; }
        public decimal Rango15 { get; set; }

        public static TarifasCategoria ConTarifasCategoriasByPlanDR(IDataRecord dataR)
        {
            TarifasCategoria tarifasCategoria = new TarifasCategoria();
            tarifasCategoria.IdTarifaCat = int.Parse(dataR["idtarifa"].ToString());
            tarifasCategoria.IdPlan = int.Parse(dataR["idplan"].ToString());
            tarifasCategoria.IdCategoria = int.Parse(dataR["idcategoria"].ToString());
            tarifasCategoria.DescCategoria = dataR["categoria"].ToString();
            tarifasCategoria.Rango1 = decimal.Parse(dataR["rango1"].ToString());
            tarifasCategoria.Rango2 = decimal.Parse(dataR["rango2"].ToString());
            tarifasCategoria.Rango3 = decimal.Parse(dataR["rango3"].ToString());
            tarifasCategoria.Rango4 = decimal.Parse(dataR["rango4"].ToString());
            tarifasCategoria.Rango5 = decimal.Parse(dataR["rango5"].ToString());
            tarifasCategoria.Rango6 = decimal.Parse(dataR["rango6"].ToString());
            tarifasCategoria.Rango7 = decimal.Parse(dataR["rango7"].ToString());
            tarifasCategoria.Rango8 = decimal.Parse(dataR["rango8"].ToString());
            tarifasCategoria.Rango9 = decimal.Parse(dataR["rango9"].ToString());
            tarifasCategoria.Rango10 = decimal.Parse(dataR["rango10"].ToString());
            tarifasCategoria.Rango11 = decimal.Parse(dataR["rango11"].ToString());
            tarifasCategoria.Rango12 = decimal.Parse(dataR["rango12"].ToString());
            tarifasCategoria.Rango13 = decimal.Parse(dataR["rango13"].ToString());
            tarifasCategoria.Rango14 = decimal.Parse(dataR["rango14"].ToString());
            tarifasCategoria.Rango15 = decimal.Parse(dataR["rango15"].ToString());
            return tarifasCategoria;
        }

    }
}
