using Data.Conexion;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Acceso
{
    public class CotizacionDependienteDao
    {
        public List<CotizacionDependiente> Todos()
        {
            List<CotizacionDependiente> cotizacion = new List<CotizacionDependiente>();
            try
            {
                using(var sql=new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_cotizacionDependiente";
                    using(var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            cotizacion.Add(CotizacionDependiente.ConsultaFromDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return cotizacion;
        }
        public List<CotizacionDependiente> ObtenerByIdCotizacion(int idCotizacion)
        {
            List<CotizacionDependiente> cotizacion = new List<CotizacionDependiente>();
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_cotizacionDependiente";
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_idcotizacion", idCotizacion));
                    using (var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            cotizacion.Add(CotizacionDependiente.ConsultaFromDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return cotizacion;
        }
        public bool Guardar(CotizacionDependiente cotizacion)
        {
            bool guardado = false;
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_cotizacionDependiente";
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_idcotizacion", cotizacion.IdCotizacion));
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_edad", cotizacion.Edad));
                    sql.EjecutaQuery();
                    guardado = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return guardado;
        }
        public bool Modificar(CotizacionDependiente cotizacion)
        {
            bool modificar = false;
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_cotizacionDependiente";
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_idcotdep", cotizacion.IdCotizacionDependiente));
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_idcotizacion", cotizacion.IdCotizacion));
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_edad", cotizacion.Edad));
                    sql.EjecutaQuery();
                    modificar = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return modificar;
        }
    }
}
