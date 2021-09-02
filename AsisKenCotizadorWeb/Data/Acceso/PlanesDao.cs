using Data.Conexion;
using Data.Entidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class PlanesDao
    {
        ConSql sql = new ConSql();

        public List<Planes> ListaPlanes()
        {
            List<Planes> listaPlanes = new List<Planes>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_planes";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaPlanes.Add(Planes.ConsultaPlanesDR(dataReader));
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
            return listaPlanes;
        }

        public Planes ConsultaPlan(int idPlan)
        {
            Planes plan = new Planes();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_planbyid";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        plan = Planes.ConsultaPlanesByIdDR(dataReader);
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
            return plan;
        }

        public int IngresoPlan(Planes planes)
        {
            int idPlan = 0;

            sql = new ConSql();
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_planes";
                sql.Comando.Parameters.AddWithValue("p_idproducto", planes.IdProducto);
                sql.Comando.Parameters.AddWithValue("p_idtipotarifa", planes.IdTipoTarifa);
                sql.Comando.Parameters.AddWithValue("p_plan", planes.DescPlan);
                sql.Comando.Parameters.AddWithValue("p_descripcion", planes.Descripcion);
                sql.Comando.Parameters.AddWithValue("p_aplicabeneficio", planes.ConBeneficios);
                sql.Comando.Parameters.AddWithValue("p_estado", planes.Estado);
                sql.Comando.Parameters.AddWithValue("p_plananterior", planes.PlanAnterior);
                sql.Comando.Parameters.AddWithValue("p_obligamaternidad", planes.ObligaMaternidad);
                sql.Comando.Parameters.AddWithValue("p_edadmaxmaternidad", planes.EdadMaxMaternidad);
                sql.Comando.Parameters.AddWithValue("p_planasociado", planes.isBorrador);
                sql.Comando.Parameters.AddWithValue("p_beneficiosadicionales", planes.AplicaBeneficioAdicional); 
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", planes.TipoPlantilla);
                sql.Comando.Parameters.AddWithValue("p_idregion", planes.IdRegion);
                sql.Comando.Parameters.AddWithValue("p_versiontext", planes.VersionText ?? planes.VersionNum.ToString());
                var p_idplan = new NpgsqlParameter("p_idplan", NpgsqlDbType.Integer)
                {
                    Direction = ParameterDirection.Output
                };
                sql.Comando.Parameters.Add(p_idplan);
                idPlan = sql.EjecutaQuery();

                idPlan = Convert.ToInt32(sql.Comando.Parameters["p_idplan"].Value);
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
            return idPlan;
        }

        public int ActualizarPlan(Planes plan)
        {

            sql = new ConSql();
            int retorno = 0;
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_plan";
                sql.Comando.Parameters.AddWithValue("p_idplan", plan.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_idtipotarifa", plan.IdTipoTarifa);
                sql.Comando.Parameters.AddWithValue("p_estado", plan.Estado);
                sql.Comando.Parameters.AddWithValue("p_borrador", plan.isBorrador);
                sql.Comando.Parameters.AddWithValue("p_idproducto", plan.IdProducto);
                //nuevos parametros de actualizacion
                sql.Comando.Parameters.AddWithValue("p_plan", plan.DescPlan);
                sql.Comando.Parameters.AddWithValue("p_descripcion", plan.Descripcion);
                sql.Comando.Parameters.AddWithValue("p_aplicabeneficio", plan.ConBeneficios);
                sql.Comando.Parameters.AddWithValue("p_obligamaternidad", plan.ObligaMaternidad);
                sql.Comando.Parameters.AddWithValue("p_edadmaxmaternidad", plan.EdadMaxMaternidad);
                sql.Comando.Parameters.AddWithValue("p_beneficiosadicionales", plan.AplicaBeneficioAdicional);
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", plan.TipoPlantilla);
                sql.Comando.Parameters.AddWithValue("p_idregion", plan.IdRegion);
                sql.Comando.Parameters.AddWithValue("p_versiontext", plan.VersionText ?? "");

                retorno = sql.EjecutaQuery();
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
            return retorno;
        }

        public bool ValidaPlanAnterior(int idPlan)
        {
            bool noExistePlanAnterior = false;

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_validaplan";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        noExistePlanAnterior = bool.Parse(dataReader[0].ToString());
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
            return noExistePlanAnterior;

        }
    }
}
