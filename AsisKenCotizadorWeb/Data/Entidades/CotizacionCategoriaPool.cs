using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace Data.Entidades
{
    public class CotizacionCategoriaPool
    {
        public int IdCotizacionCatPool { get; set; }
        public int IdCotizacion { get; set; }
        public int IdCategoria { get; set; }
        public int Cantidad { get; set; }

        public static CotizacionCategoriaPool FormDataReader(IDataReader dr)
        {
            CotizacionCategoriaPool cotizacionCatego = new CotizacionCategoriaPool
            {
                IdCotizacionCatPool = int.Parse(dr["idcotizacatpool"].ToString()),
                Cantidad = int.Parse(dr["cantidad"].ToString()),
                IdCategoria = int.Parse(dr["idcategoria"].ToString()),
                IdCotizacion = int.Parse(dr["idcotizacion"].ToString())
            };
            return cotizacionCatego;
        }
        public static XDocument CotizacionCategoriaXML(List<CotizacionCategoriaPool> cotizacionCarateristica, int idPlan = 0)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);
            cotizacionCarateristica.ForEach(x =>
            {
                XElement raiz = new XElement(xns + "Caracteristicas");
                if (x.IdCotizacionCatPool > 0)
                {
                    XElement idcotizacatpool = new XElement(xns + "idcotizacatpool", x.IdCotizacionCatPool);
                    raiz.Add(idcotizacatpool);
                }
                if (idPlan > 0)
                {
                    XElement idplan = new XElement(xns + "idplan", idPlan);
                    raiz.Add(idplan);
                }
                XElement idcotizacion = new XElement(xns + "idcotizacion", x.IdCotizacion);
                XElement idcategoria = new XElement(xns + "idcategoria", x.IdCategoria);
                XElement cantidad = new XElement(xns + "cantidad", x.Cantidad);
                raiz.Add(idcotizacion);
                raiz.Add(idcategoria);
                raiz.Add(cantidad);
                xRoot.Add(raiz);
            });
            return xDoc;
        }
    }
}
