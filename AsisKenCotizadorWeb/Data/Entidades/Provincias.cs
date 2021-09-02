using System.Data;

namespace Data.Entidades
{
    public class Provincias
    {
        public int ProvinciaID { get; set; }
        public string Descripcion { get; set; }

        public static Provincias ConProvinciasDR(IDataRecord dataR)
        {
            Provincias elemento = new Provincias();
            elemento.ProvinciaID = int.Parse(dataR["idprovincia"].ToString());
            elemento.Descripcion = dataR["descripcion"].ToString();
            return elemento;
        }
    }
}
