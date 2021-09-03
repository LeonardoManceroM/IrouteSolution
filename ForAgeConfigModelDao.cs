using Data.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class ForAgeConfigModelDao
    {
        ConSql sql = new ConSql();

        public List<ForAgeConfigModel> ListaForAgeConfigModel()
        {
            List<ForAgeConfigModel> ListaForAgeConfigModel = new List<ForAgeConfigModel>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_forAgeConfigModel";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaForAgeConfigModel.Add(ForAgeConfigModel.ConForAgeConfigModelDR(dataReader));
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
            return ListaForAgeConfigModel;
        }

        public void IngresoForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "insert into tblageConfigModel(rangoMaximo,rangoMinimo,estado) values(@rangoMaximo,@rangoMinimo,@estado)";
                //sql.Comando.Parameters.AddWithValue("IdRango", ageConfigModel.IdRango);
                sql.Comando.Parameters.AddWithValue("RangoMaximo", ageConfigModel.RangoMaximo);
                sql.Comando.Parameters.AddWithValue("RangoMinimo", ageConfigModel.RangoMinimo);
                sql.Comando.Parameters.AddWithValue("Estado", ageConfigModel.Estado);
                sql.EjecutaQuery();
          
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

        }




        public void ActualizarForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "update tblageconfigmodel set rangoMaximo=@rangoMaximo,rangoMinimo=@rangoMinimo,estado=@estado where idRango=@idRango";
                sql.Comando.Parameters.AddWithValue("IdRango", ageConfigModel.IdRango);
                sql.Comando.Parameters.AddWithValue("RangoMaximo", ageConfigModel.RangoMaximo);
                sql.Comando.Parameters.AddWithValue("RangoMinimo", ageConfigModel.RangoMinimo);
                sql.Comando.Parameters.AddWithValue("Estado", ageConfigModel.Estado);
                sql.EjecutaQuery();
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

        }


        public void EliminarForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "update tblageconfigmodel set estado=0 where idRango=@idRango";
                sql.Comando.Parameters.AddWithValue("IdRango", ageConfigModel.IdRango);
                //sql.Comando.Parameters.AddWithValue("Estado", ageConfigModel.Estado);
                sql.EjecutaQuery();
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

        }
    }
}