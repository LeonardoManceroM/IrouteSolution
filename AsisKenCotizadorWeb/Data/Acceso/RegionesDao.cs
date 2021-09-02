using Data.Conexion;
using Data.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class RegionesDao
    {
        ConSql sql = new ConSql();

        public List<Regiones> ListaRegiones()
        {
            List<Regiones> lista = new List<Regiones>();
            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_regiones";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add(Regiones.ConRegionesDR(dataReader));
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

            return lista;
        }
    }
}
