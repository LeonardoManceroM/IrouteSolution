using Data.Conexion;
using Data.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class CategoriasDao
    {
        ConSql sql = new ConSql();

        public List<Categorias> ListaCategorias()
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_categorias";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaCategorias.Add(Categorias.ConsultaCategoriasDR(dataReader));
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
            return listaCategorias;
        }
    }
}
