using Data.Conexion;
using Data.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class ProvinciaDao
    {
        ConSql sql = new ConSql();


        public List<Provincias> ListaProvincias()
        {
            List<Provincias> lista = new List<Provincias>();
            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_provincias";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add(Provincias.ConProvinciasDR(dataReader));
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
