using Data.Conexion;
using Data.Entidades;
using log4net;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Data.Acceso
{
    public class AgenciaDao
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<Agencia> ObtenerTodos()
        {
            var agencia = new List<Agencia>();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_agencia";
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            agencia.Add(Agencia.ConsultaAgenciaFromDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return agencia.OrderBy(x=>x.IdBroker).ToList();
        }

        public Agencia ObtenerById(int idAgencia)
        {
            Agencia agencia = new Agencia();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_agencia";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idagencia", idAgencia));
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            agencia = Agencia.ConsultaAgenciaFromDataRecord(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return agencia;
        }
        public int Insertar(Agencia agencia)
        {
            int insertado = 0;
            try
            {
                using(var sql=new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_agencia";
                    //sql.Comando.Parameters.Add(new NpgsqlParameter("var_idtipousuario", agencia.IdTipo));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_broker", agencia.Broker));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_direccion", agencia.Direccion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", agencia.Estado));
                    //
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_telefono", agencia.Telefono));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_descripcion", agencia.Descripcion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_mail", agencia.Mail));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_ruc", agencia.Ruc));
                    using (var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            insertado = int.Parse(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return insertado;
        }
        public int Modificar(Agencia agencia)
        {
            int insertado = 0;
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_agencia";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idbroker", agencia.IdBroker));
                    //sql.Comando.Parameters.Add(new NpgsqlParameter("var_idtipousuario", agencia.IdTipo));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_broker", agencia.Broker));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_direccion", agencia.Direccion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", agencia.Estado));
                    //
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_telefono", agencia.Telefono));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_descripcion", agencia.Descripcion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_mail", agencia.Mail));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_ruc", agencia.Ruc));
                    sql.EjecutaQuery();
                    insertado = agencia.IdBroker;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return insertado;
        }
    }
}
