using Data.Conexion;
using Data.Entidades;
using log4net;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Data.Acceso
{
    public class RolDao
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<Rol> ObtenerTodos()
        {
            var rol = new List<Rol>();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_rol";
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            rol.Add(Rol.ConsultaRolFromDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return rol;
        }

        public Rol ObtenerById(int idRol)
        {
            Rol estado = new Rol();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_rol";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idrol", idRol));
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            estado = Rol.ConsultaRolFromDataRecord(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return estado;
        }
    }
}
