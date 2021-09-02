using System.Data;

namespace Data.Entidades
{
    public class TiposTarifa
    {
        public int IdTipoTarifa { get; set; }
        public string DescTipoTarifa { get; set; }

        public static TiposTarifa ConTiposTarifasDR(IDataRecord dataR)
        {
            TiposTarifa tiposTarifa = new TiposTarifa();
            tiposTarifa.IdTipoTarifa = int.Parse(dataR["idtipotarifa"].ToString());
            tiposTarifa.DescTipoTarifa = dataR["descripcion"].ToString();
            return tiposTarifa;
        }

    }
}
