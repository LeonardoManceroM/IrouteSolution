using System;
using System.Data;

namespace Data.Entidades
{
    public class Regiones
    {
        public int RegionID { get; set; }
        public string Descripcion { get; set; }

        public static Regiones ConRegionesDR(IDataRecord dataR)
        {
            Regiones elemento = new Regiones();
            elemento.RegionID = int.Parse(dataR["idregion"].ToString());
            elemento.Descripcion = dataR["descripcion"].ToString();
            return elemento;
        }
    }
}
