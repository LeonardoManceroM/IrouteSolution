using Data.Conexion;
using Data.Entidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class CotizacionDao
    {
        ConSql sql = new ConSql();
        public List<Cotizaciones> Todos()
        {
            List<Cotizaciones> cotizacion = new List<Cotizaciones>();
            sql = new ConSql();
            
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_cotizacion";
                using (var reader = sql.EjecutaReader())
                {
                    while (reader.Read())
                        cotizacion.Add(Cotizaciones.FromDataRecord(reader));
                }
            }
            catch (Exception ex)
            {
                sql.CerrarConexion();
                throw ex;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return cotizacion;
        }

        public Cotizaciones ObtenerById(int idCotizacion)
        {
            Cotizaciones cotizacion = new Cotizaciones();
            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_cotizacion";
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_idcotizacion", idCotizacion));
                using (var reader = sql.EjecutaReader())
                {
                    while (reader.Read())
                        cotizacion = Cotizaciones.FromDataRecord(reader);
                }

            }
            catch (Exception ex)
            {
                sql.CerrarConexion();
                throw ex;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return cotizacion;
        }

        public int Guardar(Cotizaciones cotizacion)
        {
            int guardar = 0;
            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_cotizacion";
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", cotizacion.IdUsuario));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_idplan", cotizacion.IdPlan));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_cliente", cotizacion.Cliente));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_fechacotiza", cotizacion.FechaCotizacion));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", cotizacion.Estado));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titularfechanac", cotizacion.TitularNacimiento));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titulargenero", cotizacion.TitularGenero));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titularedad", cotizacion.TitularEdad));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titularmaternidad", cotizacion.TitularMaternidad));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_conyuguefechanac", cotizacion.ConyugueFechaNacimiento));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_conyuguegenero", cotizacion.ConyugueGenero));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_conyugueedad", cotizacion.ConyugueEdad));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valormensual", cotizacion.ValorMensual));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valortrimestral", cotizacion.ValorTrimestral));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorsemestral", cotizacion.ValorSemestral));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valoranual", cotizacion.ValorAnual));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorcontado", cotizacion.ValorContado));
                using (var reader = sql.EjecutaReader())
                {
                    while (reader.Read())
                        guardar = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                sql.CerrarConexion();
                throw ex;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return guardar;
        }

        public int Modificar(Cotizaciones cotizacion)
        {
            int modificar = 0;
            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_cotizacion";
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_idcotizacion", cotizacion.IdContizacion));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", cotizacion.IdUsuario));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_idplan", cotizacion.IdPlan));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_cliente", cotizacion.Cliente));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_fechacotiza", cotizacion.FechaCotizacion));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_estado", cotizacion.Estado));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titularfechanac", cotizacion.TitularNacimiento));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titulargenero", cotizacion.TitularGenero));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titularedad", cotizacion.TitularEdad));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_titularmaternidad", cotizacion.TitularMaternidad));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_conyuguefechanac", cotizacion.ConyugueFechaNacimiento));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_conyuguegenero", cotizacion.ConyugueGenero));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_conyugueedad", cotizacion.ConyugueEdad));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valormensual", cotizacion.ValorMensual));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valortrimestral", cotizacion.ValorTrimestral));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorsemestral", cotizacion.ValorSemestral));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valoranual", cotizacion.ValorAnual));
                sql.Comando.Parameters.Add(new NpgsqlParameter("var_valorcontado", cotizacion.ValorContado));
                sql.EjecutaQuery();
                modificar = cotizacion.IdContizacion;

            }
            catch (Exception ex)
            {
                sql.CerrarConexion();
                throw ex;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return modificar;
        }

        public GeneraCotizacionResultado GeneraCotizacion(GeneraCotizacionIndividual cotizacion)
        {
            GeneraCotizacionResultado resultado = new GeneraCotizacionResultado();

            ConSql sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_genera_cotizacion";
                sql.Comando.Parameters.AddWithValue("p_cotizacion_id", cotizacion.IdCotizacion);
                sql.Comando.Parameters.AddWithValue("p_idplan", NpgsqlDbType.Bigint, cotizacion.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_cliente", cotizacion.Cliente);
                sql.Comando.Parameters.AddWithValue("p_tit_beneficio", cotizacion.TitularBeneficio);
                sql.Comando.Parameters.AddWithValue("p_tit_edad", NpgsqlDbType.Bigint, cotizacion.TitularEdad);
                sql.Comando.Parameters.AddWithValue("p_tit_genero", cotizacion.TitularGenero);
                sql.Comando.Parameters.AddWithValue("p_tit_maternidad", cotizacion.TitularMaternidad);
                sql.Comando.Parameters.AddWithValue("p_tit_nacimiento", cotizacion.TitularNacimiento);
                sql.Comando.Parameters.AddWithValue("p_con_edad", NpgsqlDbType.Bigint, cotizacion.ConyugueEdad);
                sql.Comando.Parameters.AddWithValue("p_con_genero", cotizacion.ConyugueGenero);
                sql.Comando.Parameters.AddWithValue("p_con_nacimineto", cotizacion.ConyugueFechaNacimiento);
                sql.Comando.Parameters.AddWithValue("p_dependientes", cotizacion.Dependientes);
                sql.Comando.Parameters.AddWithValue("p_coberturas_adi", cotizacion.CoberturasAdicionales);
                sql.Comando.Parameters.AddWithValue("p_beneficios_cat", cotizacion.CatBeneficiosAdicionales);
                sql.Comando.Parameters.AddWithValue("p_contpersonas", cotizacion.ContadorPersonas);
                sql.Comando.Parameters.AddWithValue("p_idusuario", NpgsqlDbType.Bigint, cotizacion.IdUsuario);
                sql.Comando.Parameters.AddWithValue("p_estado", cotizacion.Estado);
                sql.Comando.Parameters.AddWithValue("p_guardar", cotizacion.GuardarCotizacion);

                var p_descplan = new NpgsqlParameter("p_descplan", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_idcotizacion = new NpgsqlParameter("p_idcotizacion", NpgsqlDbType.Integer) { Direction = ParameterDirection.Output };
                var p_fechacotizacion = new NpgsqlParameter("p_fechacotizacion", NpgsqlDbType.Date) { Direction = ParameterDirection.Output };
                var p_valormensual = new NpgsqlParameter("p_valor_mensual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valortrimestral = new NpgsqlParameter("p_valor_trimestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorsemestral = new NpgsqlParameter("p_valor_semestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valoranual = new NpgsqlParameter("p_valor_anual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorcontado = new NpgsqlParameter("p_valor_contado", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_agente = new NpgsqlParameter("p_agente", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_telefono = new NpgsqlParameter("p_telefono", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_agencia = new NpgsqlParameter("p_agencia", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_direccion = new NpgsqlParameter("p_direccion", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };
                var p_region = new NpgsqlParameter("p_region", NpgsqlDbType.Text) { Direction = ParameterDirection.Output };

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

                int respuesta = sql.EjecutaQuery();

                resultado.DescPlan = (string)sql.Comando.Parameters["p_descplan"].Value;
                resultado.IdCotizacion = Convert.ToInt32(sql.Comando.Parameters["p_idcotizacion"].Value);
                resultado.FechaCotizacion = Convert.ToDateTime(sql.Comando.Parameters["p_fechacotizacion"].Value);
                resultado.ValorMensual = Convert.ToDecimal(sql.Comando.Parameters["p_valor_mensual"].Value);
                resultado.ValorTrimestral = Convert.ToDecimal(sql.Comando.Parameters["p_valor_trimestral"].Value);
                resultado.ValorSemestral = Convert.ToDecimal(sql.Comando.Parameters["p_valor_semestral"].Value);
                resultado.ValorAnual = Convert.ToDecimal(sql.Comando.Parameters["p_valor_anual"].Value);
                resultado.ValorContado = Convert.ToDecimal(sql.Comando.Parameters["p_valor_contado"].Value);
                resultado.Agente = (string)sql.Comando.Parameters["p_agente"].Value;
                resultado.Telefono = (string)sql.Comando.Parameters["p_telefono"].Value;
                resultado.Agencia = (string)sql.Comando.Parameters["p_agencia"].Value;
                resultado.Direccion = (string)sql.Comando.Parameters["p_direccion"].Value;
                resultado.Region = (string)sql.Comando.Parameters["p_region"].Value;
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

        public List<ConsultaCotizacion> ConsultaCotizacionByID(int idCotizacion, bool isPool)
        {
            List<ConsultaCotizacion> cotizacion = new List<ConsultaCotizacion>();
            ConSql sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_cotizacion";
                sql.Comando.Parameters.Add(new NpgsqlParameter("p_idcotizacion", idCotizacion));
                sql.Comando.Parameters.Add(new NpgsqlParameter("p_planpool", isPool));
                using (var reader = sql.EjecutaReader())
                {
                    while (reader.Read())
                        cotizacion.Add(ConsultaCotizacion.ConsultaCotizacionDr(reader));
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
            return cotizacion;
        }

    }
}
