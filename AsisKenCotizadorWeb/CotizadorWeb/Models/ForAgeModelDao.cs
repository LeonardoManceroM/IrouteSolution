using Data.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class ForAgeModelDao
    {
        ConSql sql = new ConSql();




        //Consulta todos los datos de la tabla TblForAgeModel
        public List<ForAgeModel> ListaForAgeModel()
        {
            List<ForAgeModel> ListaForAgeModel = new List<ForAgeModel>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_forAgeModel";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaForAgeModel.Add(ForAgeModel.ConForAgeModelDR(dataReader));
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
            return ListaForAgeModel;
        }

        public void IngresoForAgeModel(ForAgeModel ageModel)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "insert into tblageModel(edad,femeninoSinMaternidad,femeninoConMaternidad,masculino) values(@edad,@femeninoconmaternidad,@femeninosinmaternidad,@masculino)";
                sql.Comando.Parameters.AddWithValue("edad", ageModel.edad);
                sql.Comando.Parameters.AddWithValue("femeninoconmaternidad", ageModel.femeninoConMaternidad);
                sql.Comando.Parameters.AddWithValue("femeninosinmaternidad", ageModel.femeninoSinMaternidad);
                sql.Comando.Parameters.AddWithValue("masculino", ageModel.masculino);
                sql.EjecutaQuery();

                //using (IDataReader dataReader = sql.EjecutaReader())
                //{
                //    while (dataReader.Read())
                //    {
                //        id = int.Parse(dataReader[0].ToString());
                //    }
                //}

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




        public void ActualizarForAgeModel(ForAgeModel ageModel)
        {
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.Text;
                sql.Comando.CommandText = "update tblagemodel set edad= @edad,femeninoconmaternidad=@femeninoconmaternidad,femeninosinmaternidad=@femeninosinmaternidad,masculino=@masculino where id=@id";
                sql.Comando.Parameters.AddWithValue("edad", ageModel.edad);
                sql.Comando.Parameters.AddWithValue("femeninoconmaternidad", ageModel.femeninoConMaternidad);
                sql.Comando.Parameters.AddWithValue("femeninosinmaternidad", ageModel.femeninoSinMaternidad);
                sql.Comando.Parameters.AddWithValue("masculino", ageModel.masculino);
                sql.Comando.Parameters.AddWithValue("id", ageModel.id);
                sql.EjecutaQuery();

                //using (IDataReader dataReader = sql.EjecutaReader())
                //{
                //    while (dataReader.Read())
                //    {
                //        id = int.Parse(dataReader[0].ToString());
                //    }
                //}

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