using System.Data;

namespace Data.Entidades
{
    public class Planes
    {
        public int IdCobertura { get; set; }
        public string DescCobertura { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int IdPlan { get; set; }
        public string DescPlan { get; set; }
        public string Descripcion { get; set; }
        public bool ConBeneficios { get; set; }
        public int IdTipoTarifa { get; set; }
        public string DescTipoTarifa { get; set; }
        // 1 - 2 - 3
        public int Estado { get; set; }
        //Activo - Inactivo - En Desarrollo
        public string DescEstado { get; set; }
        public bool isBorrador { get; set; }
        public int PlanAnterior { get; set; }
        public bool ObligaMaternidad { get; set; }
        public int EdadMaxMaternidad { get; set; }
        public bool AplicaBeneficioAdicional { get; set; }
        public bool TarifaDependientes { get; set; }
        public int TipoPlantilla { get; set; }
        public int IdRegion { get; set; }
        public string Region { get; set; }
        public int VersionNum { get; set; }
        public string VersionText { get; set; }

        public static Planes ConsultaPlanesDR(IDataRecord dataR)
        {
            Planes planes = new Planes();
            planes.IdCobertura = int.Parse(dataR["idcobertura"].ToString());
            planes.DescCobertura = dataR["cobertura"].ToString();
            planes.IdProducto = int.Parse(dataR["idproducto"].ToString());
            planes.DescProducto = dataR["producto"].ToString();
            planes.IdPlan = int.Parse(dataR["idplan"].ToString());
            planes.DescPlan = dataR["plan"].ToString();
            planes.IdTipoTarifa = int.Parse(dataR["idtipotarifa"].ToString());
            planes.DescTipoTarifa = dataR["desctipotarifa"].ToString();
            planes.Descripcion = dataR["descripcion"].ToString();
            planes.ConBeneficios = bool.Parse(dataR["aplicabeneficio"].ToString());
            planes.Estado = int.Parse(dataR["estado"].ToString());
            planes.ObligaMaternidad = bool.Parse(dataR["maternidadobligatorio"].ToString());
            planes.EdadMaxMaternidad = int.Parse(dataR["edadmaximamaternidad"].ToString());
            planes.AplicaBeneficioAdicional = bool.Parse(dataR["aplicabeneficioadicional"].ToString());
            planes.IdRegion = int.Parse(dataR["idregion"].ToString());
            planes.Region = dataR["region"].ToString();
            planes.VersionNum = int.Parse(dataR["version_num"].ToString());
            planes.VersionText = dataR["version_text"].ToString();

            return planes;
        }

        public static Planes ConsultaPlanesByIdDR(IDataRecord dataR)
        {
            Planes planes = new Planes();
            planes.IdCobertura = int.Parse(dataR["idcobertura"].ToString());
            planes.DescCobertura = dataR["cobertura"].ToString();
            planes.IdProducto = int.Parse(dataR["idproducto"].ToString());
            planes.DescProducto = dataR["producto"].ToString();
            planes.IdPlan = int.Parse(dataR["idplan"].ToString());
            planes.DescPlan = dataR["plan"].ToString();
            planes.IdTipoTarifa = int.Parse(dataR["idtipotarifa"].ToString());
            planes.DescTipoTarifa = dataR["desctipotarifa"].ToString();
            planes.Descripcion = dataR["descripcion"].ToString();
            planes.ConBeneficios = bool.Parse(dataR["aplicabeneficio"].ToString());
            planes.Estado = int.Parse(dataR["estado"].ToString());
            planes.PlanAnterior = int.Parse(dataR["plan_anterior"].ToString());
            planes.isBorrador = planes.Estado == 3 ? true : false;
            planes.ObligaMaternidad = bool.Parse(dataR["maternidadobligatorio"].ToString());
            planes.EdadMaxMaternidad = int.Parse(dataR["edadmaximamaternidad"].ToString());
            planes.TarifaDependientes = bool.Parse(dataR["aplicadependientes"].ToString());
            planes.TipoPlantilla = int.Parse(dataR["tipoplantilla"].ToString());
            planes.IdRegion = int.Parse(dataR["idregion"].ToString());
            planes.Region = dataR["region"].ToString();
            planes.VersionNum = int.Parse(dataR["version_num"].ToString());
            planes.VersionText = dataR["version_text"].ToString();
            return planes;
        }
    }
}
