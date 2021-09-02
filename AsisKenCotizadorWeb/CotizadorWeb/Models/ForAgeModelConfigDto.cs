using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CotizadorWeb.Models
{
    public class ForAgeModelConfigDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly ForAgeConfigModelDao AgeConfigModelDao = new ForAgeConfigModelDao();

        public List<ForAgeConfigModel> ConsultaForAgeConfigModel()
        {
            List<ForAgeConfigModel> ListaForAgeConfigModel = new List<ForAgeConfigModel>();
            try
            {

                if (!isOnline)
                {
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaForAgeConfigModel = AgeConfigModelDao.ListaForAgeConfigModel();
                    Log.Info("Consulta ListaForAgeModel OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaForAgeConfigModel;
        }


        public int IngresarForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            int Id = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("Ingresar ForAgeConfigModel OffLine");
                }
                else
                {
                    AgeConfigModelDao.IngresoForAgeConfigModel(ageConfigModel);
                    Log.Info("Ingresar ForAgeConfigModel OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return Id;
        }



        public int ActualizarForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            int Id = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("Actualizar ForAgeModels OffLine");
                }
                else
                {
                    AgeConfigModelDao.ActualizarForAgeConfigModel(ageConfigModel);
                    Log.Info("Actualizar ForAgeModels OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return Id;
        }
    }
}