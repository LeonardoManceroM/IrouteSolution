using System.Data;

namespace Data.Entidades
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public static Rol ConsultaRolFromDataRecord(IDataRecord dr)
        {
            Rol rol = new Rol();
            rol.IdRol = int.Parse(dr["IdRol"].ToString());
            rol.Descripcion = dr["Rol"].ToString();
            return rol;
        }

    }
}
