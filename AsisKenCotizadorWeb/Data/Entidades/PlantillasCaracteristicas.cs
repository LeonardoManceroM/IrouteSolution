using System.Data;

namespace Data.Entidades
{
    public class PlantillasCaracteristicas
    {
        public int IdPlantillaCaract { get; set; }
        public int IdSeccion { get; set; }
        public string Seccion { get; set; }
        public string Descripcion { get; set; }
        public int TipoPlantilla { get; set; }

        public static PlantillasCaracteristicas ConPlantillasCaracteristicasDR(IDataRecord dataR)
        {
            PlantillasCaracteristicas plantillasC = new PlantillasCaracteristicas();
            plantillasC.IdSeccion = int.Parse(dataR["idseccion"].ToString());
            plantillasC.Seccion = dataR["seccion"].ToString();
            plantillasC.IdPlantillaCaract = int.Parse(dataR["idplantillac"].ToString());
            plantillasC.Descripcion = dataR["descripcion"].ToString();
            return plantillasC;
        }
    }
}