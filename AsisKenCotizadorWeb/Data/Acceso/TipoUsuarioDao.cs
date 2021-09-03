using Data.Conexion;
using Data.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class TipoUsuarioDao
    {
        public List<TipoUsuario> ObtenerTodos()
        {
            List<TipoUsuario> tipoUsuarios = new List<TipoUsuario>();
            try
            {
                using(var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_tiposuario";
                    using (var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            tipoUsuarios.Add(TipoUsuario.ConsultaFormDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipoUsuarios;
        }
        public TipoUsuario ObtenerById(int IdTipoUsuario)
        {
            TipoUsuario tipo = new TipoUsuario();
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_tiposuario";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idtipo_usuario", IdTipoUsuario));
                    using (var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            tipo = TipoUsuario.ConsultaFormDataRecord(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipo;
        }
    }
   
}
