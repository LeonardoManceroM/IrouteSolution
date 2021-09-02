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
    public class EstadoDao
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<Estado> ObtenerTodosEstado()
        {
            var estados = new List<Estado>();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_estado";
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            estados.Add(Estado.ConsultaEstadoFromDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return estados;
        }

        public Estado ObtenerEstadoById(int idEstado)
        {
            Estado estado = new Estado();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_estado";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idestado", idEstado));
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            estado = Estado.ConsultaEstadoFromDataRecord(reader);
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
        public bool Insertar(Estado estado)
        {
            bool guardado = false;
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_estado";
                    //sql.Comando.Parameters.Add(new NpgsqlParameter("var_idestado", estado.IdEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_descripcion", estado.Descripcion));
                    sql.EjecutaQuery();
                    guardado = true;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return guardado;
        }
        public bool Modificar(Estado estado)
        {
            bool modificado = false;
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_estado";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idestado", estado.IdEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_descripcion", estado.Descripcion));
                    sql.EjecutaQuery();
                    modificado = true;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return modificado;
        }
    }
}
