using System.Data;

namespace Data.Entidades
{
    public class TipoUsuario
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }

        public static TipoUsuario ConsultaFormDataRecord(IDataRecord dr)
        {
            TipoUsuario tipoUsuario = new TipoUsuario
            {
                Descripcion = dr["descripcion"].ToString(),
                IdTipo=int.Parse(dr["idtipousuario"].ToString())
            };
            return tipoUsuario;
        }
    }
}
