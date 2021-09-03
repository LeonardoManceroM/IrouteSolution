using System.Data;
using System.Xml.Linq;

namespace Data.Entidades
{
    public class Caracteristicas
    {
        public int IdCaracteristica { get; set; }
        public int IdPlantillaC { get; set; }
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public bool AplicaMaternidad { get; set; }
        public bool AplicaNSolo { get; set; }
        public int Estado { get; set; }
        public int IdSeccion { get; set; }
        public string Seccion { get; set; }
        public int SeccionOrden { get; set; }
        public int CaracteristicaOrden { get; set; }

        public static Caracteristicas ConCaracteristicasByPlanDR(IDataRecord dataR)
        {
            Caracteristicas caracteristicas = new Caracteristicas();
            caracteristicas.IdCaracteristica = int.Parse(dataR["idcaracteristica"].ToString());
            caracteristicas.IdSeccion = int.Parse(dataR["idseccion"].ToString());
            caracteristicas.Seccion = dataR["seccion"].ToString();
            caracteristicas.IdPlantillaC = int.Parse(dataR["idplantillac"].ToString());
            caracteristicas.IdPlan = int.Parse(dataR["idplan"].ToString());
            caracteristicas.Descripcion = dataR["descripcion"].ToString();
            caracteristicas.Valor = dataR["dato"].ToString();
            caracteristicas.AplicaMaternidad = bool.Parse(dataR["aplicamaternidad"].ToString());
            caracteristicas.AplicaNSolo = bool.Parse(dataR["aplicansolo"].ToString());
            caracteristicas.Estado = int.Parse(dataR["estado"].ToString());
            caracteristicas.SeccionOrden = int.Parse(dataR["sorden"].ToString());
            caracteristicas.CaracteristicaOrden = int.Parse(dataR["corden"].ToString());
            return caracteristicas;
        }

        public static XDocument CaractetisticaBeneficioXML(int[] idBeneficios)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);
            foreach (int beneficios in idBeneficios)
            {
                XElement raiz = new XElement(xns + "Caracteristicas");
                XElement idbeneficio = new XElement(xns + "idbeneficio", beneficios);
                raiz.Add(idbeneficio);
                xRoot.Add(raiz);
            };
            return xDoc;
        }

    }
}
