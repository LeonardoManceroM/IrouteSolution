using Npgsql;
using System.Configuration;
namespace Data.Conexion
{
    public class Base
    {
        public NpgsqlConnection GetConexion()
        {
            try
            {
                var sql = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;
                return new NpgsqlConnection(sql);
            }
            catch
            {
                throw;
            }
        }
    }
}
