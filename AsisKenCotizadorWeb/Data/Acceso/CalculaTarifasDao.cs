using Data.Conexion;
using Data.Entidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace Data.Acceso
{
    public class CalculaTarifasDao
    {
        ConSql sql = new ConSql();

        public CalculaTarifasResultado Calcular(CalculaTarifas calculaTarifas)
        {
            CalculaTarifasResultado resultado = new CalculaTarifasResultado();

            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_calcula_tarifas";
                sql.Comando.Parameters.AddWithValue("p_idplan", calculaTarifas.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_tit_beneficio", calculaTarifas.TitularBeneficio);
                sql.Comando.Parameters.AddWithValue("p_tit_edad", calculaTarifas.TitularEdad);
                sql.Comando.Parameters.AddWithValue("p_tit_genero", calculaTarifas.TitularGenero);
                sql.Comando.Parameters.AddWithValue("p_tit_maternidad", calculaTarifas.TitularMaternidad);
                sql.Comando.Parameters.AddWithValue("p_con_edad", calculaTarifas.ConyugueEdad);
                sql.Comando.Parameters.AddWithValue("p_con_genero", calculaTarifas.ConyugueGenero);
                sql.Comando.Parameters.AddWithValue("p_dependientes", calculaTarifas.Dependientes);
                sql.Comando.Parameters.AddWithValue("p_coberturas_adi", calculaTarifas.CoberturasAdicionales);
                sql.Comando.Parameters.AddWithValue("p_contpersonas", calculaTarifas.ContadorPersonas);

                var p_valormensual = new NpgsqlParameter("p_valormensual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valortrimestral = new NpgsqlParameter("p_valortrimestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorsemestral = new NpgsqlParameter("p_valorsemestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valoranual = new NpgsqlParameter("p_valoranual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorcontado = new NpgsqlParameter("p_valorcontado", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };

                sql.Comando.Parameters.Add(p_valormensual);
                sql.Comando.Parameters.Add(p_valortrimestral);
                sql.Comando.Parameters.Add(p_valorsemestral);
                sql.Comando.Parameters.Add(p_valoranual);
                sql.Comando.Parameters.Add(p_valorcontado);

                int respuesta = sql.EjecutaQuery();

                resultado.ValorMensual = Convert.ToDecimal(sql.Comando.Parameters["p_valormensual"].Value);
                resultado.ValorTrimestral = Convert.ToDecimal(sql.Comando.Parameters["p_valortrimestral"].Value);
                resultado.ValorSemestral = Convert.ToDecimal(sql.Comando.Parameters["p_valorsemestral"].Value);
                resultado.ValorAnual = Convert.ToDecimal(sql.Comando.Parameters["p_valoranual"].Value);
                resultado.ValorContado = Convert.ToDecimal(sql.Comando.Parameters["p_valorcontado"].Value);
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

        public CalculaTarifasResultado CalcularPool(List<TarifaPool> listaTarifasPools)
        {
            sql = new ConSql();
            CalculaTarifasResultado resultado = new CalculaTarifasResultado();

            try
            {
                XDocument xml = TarifaPool.ListaTarifasPoolXML(listaTarifasPools);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_calcula_tarifas_pool";
                sql.Comando.Parameters.AddWithValue("lista_pool", NpgsqlDbType.Xml, xml.ToString());

                var p_valormensual = new NpgsqlParameter("p_valormensual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valortrimestral = new NpgsqlParameter("p_valortrimestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorsemestral = new NpgsqlParameter("p_valorsemestral", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valoranual = new NpgsqlParameter("p_valoranual", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };
                var p_valorcontado = new NpgsqlParameter("p_valorcontado", NpgsqlDbType.Numeric) { Direction = ParameterDirection.Output };

                sql.Comando.Parameters.Add(p_valormensual);
                sql.Comando.Parameters.Add(p_valortrimestral);
                sql.Comando.Parameters.Add(p_valorsemestral);
                sql.Comando.Parameters.Add(p_valoranual);
                sql.Comando.Parameters.Add(p_valorcontado);

                int retorno = sql.EjecutaQuery();

                resultado.ValorMensual = Convert.ToDecimal(sql.Comando.Parameters["p_valormensual"].Value);
                resultado.ValorTrimestral = Convert.ToDecimal(sql.Comando.Parameters["p_valortrimestral"].Value);
                resultado.ValorSemestral = Convert.ToDecimal(sql.Comando.Parameters["p_valorsemestral"].Value);
                resultado.ValorAnual = Convert.ToDecimal(sql.Comando.Parameters["p_valoranual"].Value);
                resultado.ValorContado = Convert.ToDecimal(sql.Comando.Parameters["p_valorcontado"].Value);
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
