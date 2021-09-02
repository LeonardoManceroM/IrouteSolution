using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace Data.Entidades
{
    public class TarifaPool
    {
        public int IdTarifaPool { get; set; }
        public int IdPlan { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int CantidadMin { get; set; }
        public decimal Valor { get; set; }

        public static TarifaPool ConTarifasPoolByPlanDR(IDataRecord dataR)
        {
            TarifaPool tarifasPool = new TarifaPool();
            tarifasPool.IdTarifaPool = int.Parse(dataR["idtarifapool"].ToString());
            tarifasPool.IdPlan = int.Parse(dataR["idplan"].ToString());
            tarifasPool.IdCategoria = int.Parse(dataR["idcategoria"].ToString());
            tarifasPool.Categoria = dataR["categoria"].ToString();
            tarifasPool.CantidadMin = int.Parse(dataR["cantidadmin"].ToString());
            tarifasPool.Valor = decimal.Parse(dataR["valor"].ToString());
            return tarifasPool;
        }

        public static XDocument ListaTarifasPoolXML(List<TarifaPool> listaTarifasPools)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);

            listaTarifasPools.ForEach(x =>
            {
                //XElement XE_TarifasPool = new XElement(xns + "TarifasPool");
                XElement XE_TarifasPool = new XElement(xns + "Caracteristicas");
                XElement idtarifapool = new XElement(xns + "idtarifapool", x.IdTarifaPool);
                XElement idplan = new XElement(xns + "idplan", x.IdPlan);
                XElement idcategoria = new XElement(xns + "idcategoria", x.IdCategoria);
                //XElement cantidadmin = new XElement(xns + "cantidadmin", x.CantidadMin);
                XElement cantidadmin = new XElement(xns + "cantidad", x.CantidadMin);
                XElement valor = new XElement(xns + "valor", x.Valor);
                XE_TarifasPool.Add(idtarifapool);
                XE_TarifasPool.Add(idplan);
                XE_TarifasPool.Add(idcategoria);
                XE_TarifasPool.Add(cantidadmin);
                XE_TarifasPool.Add(valor);
                xRoot.Add(XE_TarifasPool);
            });
            return xDoc;
        }
    }
}
