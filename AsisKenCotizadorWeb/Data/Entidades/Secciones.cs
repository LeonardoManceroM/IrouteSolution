using System.Data;

namespace Data.Entidades
{
    public class Secciones
    {
        public int IdSeccion { get; set; }
        public string Seccion { get; set; }
        public int Estado { get; set; }
        public string EstadoDesc { get { return Estado == 1 ? "Activo" : "Inactivo"; } }

        public static Secciones ConSeccionesDR(IDataRecord dataR)
        {
            Secciones secciones = new Secciones();
            secciones.IdSeccion = int.Parse(dataR["idseccion"].ToString());
            secciones.Seccion = dataR["seccion"].ToString();
            secciones.Estado = int.Parse(dataR["estado"].ToString());
            return secciones;
        }
    }
}
