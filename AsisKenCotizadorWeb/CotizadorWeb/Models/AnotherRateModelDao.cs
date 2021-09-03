using Data.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class AnotherRateModelDao
    {

        ConSql sql = new ConSql();

        public List<AnotherRateModel> ListaAnotherRateModel()
        {
            List<AnotherRateModel> ListaAnotherRateModel = new List<AnotherRateModel>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_AnotherRateModel";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaAnotherRateModel.Add(AnotherRateModel.ConAnotherRateModelDR(dataReader));
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
            return ListaAnotherRateModel;
        }

        public void IngresoAnotherRateModel(AnotherRateModel anotherRateModels)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "insert into tblanotherratemodel(edad,dependientes,ninosSolos) values(@edad,@dependientes,@ninosSolos)";
                //sql.Comando.Parameters.AddWithValue("id", anotherRateModels.id);
                sql.Comando.Parameters.AddWithValue("edad", anotherRateModels.edad);
                sql.Comando.Parameters.AddWithValue("dependientes", anotherRateModels.dependientes);
                sql.Comando.Parameters.AddWithValue("ninosSolos", anotherRateModels.ninosSolos);
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




        public void ActualizarAnotherRateModel(AnotherRateModel anotherRateModels)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "update tblanotherratemodel set edad=@edad,dependientes=@dependientes,ninosSolos=@ninosSolos where id=@id";
                sql.Comando.Parameters.AddWithValue("id", anotherRateModels.id);
                sql.Comando.Parameters.AddWithValue("dependientes", anotherRateModels.dependientes);
                sql.Comando.Parameters.AddWithValue("edad", anotherRateModels.edad);
                sql.Comando.Parameters.AddWithValue("ninosSolos", anotherRateModels.ninosSolos);
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