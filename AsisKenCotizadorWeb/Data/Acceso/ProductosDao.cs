using Data.Conexion;
using Data.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class ProductosDao
    {
        ConSql sql = new ConSql();

        public List<Productos> ListaProductos()
        {
            List<Productos> listaPlanes = new List<Productos>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_productos";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaPlanes.Add(Productos.ConsultaProductoDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return listaPlanes;
        }

    }
}
