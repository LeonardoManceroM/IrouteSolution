using Data.Conexion;
using Data.Entidades;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class SeccionesDao
    {
        ConSql sql = new ConSql();
        /*
        public List<Seccion> ListaSecciones()
        {
            List<Seccion> lista = new List<Seccion>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_secciones";
                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add(Seccion.ConsultaElementoDR(dataReader));
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


        public int GuardarSeccion(Seccion elemento)
        {
            int id = 0;
            sql = new ConSql();

            try
            {
                if(elemento.SeccionID > 0)
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_seccion";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idseccion", elemento.SeccionID));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_nombre", elemento.Nombre));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", elemento.Estado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_tipoplan", elemento.TipoPlan));
                    using (IDataReader dataReader = sql.EjecutaReader())
                    {
                        while (dataReader.Read())
                        {
                             id = int.Parse(dataReader["id"].ToString());
                        }
                    }
                }
                else
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_seccion";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_nombre", elemento.Nombre));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_tipoplan", elemento.TipoPlan));
                    using (IDataReader dataReader = sql.EjecutaReader())
                    {
                        while (dataReader.Read())
                        {
                            id = int.Parse(dataReader["id"].ToString());
                        }
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
            return id;
        }
        */
    }
}
