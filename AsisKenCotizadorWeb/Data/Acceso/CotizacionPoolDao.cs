using Data.Conexion;
using Data.Entidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class CotizacionPoolDao
    {
        public CotizacionesPool ObtenerCotizacionById(int idcotizacion) {
            CotizacionesPool cotizacion = new CotizacionesPool();
            try
            {
                using(var sql=new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_cotizacionpool";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idcotizacionpool", idcotizacion));
                    using(var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            cotizacion = CotizacionesPool.dataFromRecord(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cotizacion;
        }

        public int Guardar(CotizacionesPool cotizacion)
        {
            int guardado = 0;
            try
            {
                using(var sql=new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_cotizacionpool";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", cotizacion.IdUsuario));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_cliente", cotizacion.Cliente));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_actividad", cotizacion.Actividad));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_fechacotiza", cotizacion.FechaCotiza));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idplan", cotizacion.IdPlan));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", cotizacion.Estado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valormensual", cotizacion.ValorMensual));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valortrimestral", cotizacion.ValorTrimestral));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorsemestral", cotizacion.ValorSemestral));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valoranual", cotizacion.ValorContado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorcontado", cotizacion.ValorContado));
                    using(var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            guardado = int.Parse(reader[0].ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return guardado;
        }
        public bool Modificar(CotizacionesPool cotizacion)
        {
            bool retorno = false;
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_cotizacionpool";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idcotizacionpool", cotizacion.IdCotizacion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", cotizacion.IdUsuario));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_cliente", cotizacion.Cliente));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_actividad", cotizacion.Actividad));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_fechacotiza", cotizacion.FechaCotiza));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idplan", cotizacion.IdPlan));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", cotizacion.Estado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valormensual", cotizacion.ValorMensual));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valortrimestral", cotizacion.ValorTrimestral));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorsemestral", cotizacion.ValorSemestral));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valoranual", cotizacion.ValorContado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorcontado", cotizacion.ValorContado));
                    sql.EjecutaQuery();
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        //cotizacion categoria pool
        public List<CotizacionCategoriaPool> ConsultarCategoriaPool(int idCategoriaPool)
        {
            List<CotizacionCategoriaPool> cotizacion = new List<CotizacionCategoriaPool>();
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_categoriasPool";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idcotizacion", idCategoriaPool));
                    using(var reader=sql.EjecutaReader())
                    {
                        while (reader.Read())
                            cotizacion.Add(CotizacionCategoriaPool.FormDataReader(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cotizacion;
        }
        public bool IngresarCategoriaPool(List<CotizacionCategoriaPool> categoriasPool)
        {
            bool ingresado = false;
            try
            {
                var xmlcategoria = CotizacionCategoriaPool.CotizacionCategoriaXML(categoriasPool);
                using (var sql= new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_categoriasPool";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_lista", NpgsqlDbType.Xml) { Value = xmlcategoria.ToString() });
                    sql.EjecutaQuery();
                    ingresado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ingresado;
        }

        public bool ModificarCategoriaPool(List<CotizacionCategoriaPool> categoriasPool)
        {
            bool ingresado = false;
            try
            {
                var xmlcategoria = CotizacionCategoriaPool.CotizacionCategoriaXML(categoriasPool);
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_categoriasPool";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_lista", NpgsqlDbType.Xml) { Value = xmlcategoria.ToString() });
                    sql.EjecutaQuery();
                    ingresado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ingresado;
        }

        public GeneraCotizacionResultado GeneraCotizacionPool(GeneraCotizacionPool cotizacion)
        {
            GeneraCotizacionResultado resultado = new GeneraCotizacionResultado();
            ConSql sql = new ConSql();

            try
            {
                var xmlCategoriasPool = CotizacionCategoriaPool.CotizacionCategoriaXML(cotizacion.CategoriaPools, cotizacion.IdPlan);

                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_genera_cotizacion_pool"; 
                sql.Comando.Parameters.AddWithValue("p_cotizacion_id", cotizacion.IdCotizacion);
                sql.Comando.Parameters.AddWithValue("p_idplan", cotizacion.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_cliente", cotizacion.Cliente);
                sql.Comando.Parameters.AddWithValue("p_actividad", cotizacion.Actividad);
                sql.Comando.Parameters.AddWithValue("p_idusuario", cotizacion.IdUsuario);
                sql.Comando.Parameters.AddWithValue("p_guardar", cotizacion.GuardarCotizacion);
                sql.Comando.Parameters.AddWithValue("lista_pool", NpgsqlDbType.Xml, xmlCategoriasPool.ToString());

                var p_descplan = new NpgsqlParameter("p_descplan", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_idcotizacion = new NpgsqlParameter("p_idcotizacion", NpgsqlDbType.Integer) { Direction = ParameterDirection.Output };
                var p_fechacotizacion = new NpgsqlParameter("p_fechacotizacion", NpgsqlDbType.Date) { Direction = ParameterDirection.Output };
                var p_valormensual = new NpgsqlParameter("p_valormensual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valortrimestral = new NpgsqlParameter("p_valortrimestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorsemestral = new NpgsqlParameter("p_valorsemestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valoranual = new NpgsqlParameter("p_valoranual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorcontado = new NpgsqlParameter("p_valorcontado", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_agente = new NpgsqlParameter("p_agente", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_telefono = new NpgsqlParameter("p_telefono", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_agencia = new NpgsqlParameter("p_agencia", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_direccion = new NpgsqlParameter("p_direccion", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_region = new NpgsqlParameter("p_region", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_version_num = new NpgsqlParameter("p_version_num", NpgsqlDbType.Integer) { Direction = ParameterDirection.Output };
                var p_version_text = new NpgsqlParameter("p_version_text", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };

                sql.Comando.Parameters.Add(p_descplan);
                sql.Comando.Parameters.Add(p_idcotizacion);
                sql.Comando.Parameters.Add(p_fechacotizacion);
                sql.Comando.Parameters.Add(p_valormensual);
                sql.Comando.Parameters.Add(p_valortrimestral);
                sql.Comando.Parameters.Add(p_valorsemestral);
                sql.Comando.Parameters.Add(p_valoranual);
                sql.Comando.Parameters.Add(p_valorcontado);
                sql.Comando.Parameters.Add(p_agente);
                sql.Comando.Parameters.Add(p_telefono);
                sql.Comando.Parameters.Add(p_agencia);
                sql.Comando.Parameters.Add(p_direccion);
                sql.Comando.Parameters.Add(p_region);
                sql.Comando.Parameters.Add(p_version_num);
                sql.Comando.Parameters.Add(p_version_text);

                int respuesta = sql.EjecutaQuery();

                resultado.DescPlan = (string)sql.Comando.Parameters["p_descplan"].Value;
                resultado.IdCotizacion = Convert.ToInt32(sql.Comando.Parameters["p_idcotizacion"].Value);
                resultado.FechaCotizacion = Convert.ToDateTime(sql.Comando.Parameters["p_fechacotizacion"].Value);
                resultado.ValorMensual = Convert.ToDecimal(sql.Comando.Parameters["p_valormensual"].Value);
                resultado.ValorTrimestral = Convert.ToDecimal(sql.Comando.Parameters["p_valortrimestral"].Value);
                resultado.ValorSemestral = Convert.ToDecimal(sql.Comando.Parameters["p_valorsemestral"].Value);
                resultado.ValorAnual = Convert.ToDecimal(sql.Comando.Parameters["p_valoranual"].Value);
                resultado.ValorContado = Convert.ToDecimal(sql.Comando.Parameters["p_valorcontado"].Value);
                resultado.Agente = (string)sql.Comando.Parameters["p_agente"].Value;
                resultado.Telefono = (string)sql.Comando.Parameters["p_telefono"].Value;
                resultado.Agencia = (string)sql.Comando.Parameters["p_agencia"].Value;
                resultado.Direccion = (string)sql.Comando.Parameters["p_direccion"].Value;
                resultado.Region = (string)sql.Comando.Parameters["p_region"].Value;
                resultado.Version_Num = Convert.ToInt32(sql.Comando.Parameters["p_version_num"].Value);
                resultado.Version_Text = (string)sql.Comando.Parameters["p_version_text"].Value;
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
            return resultado;
        }
    }
}
