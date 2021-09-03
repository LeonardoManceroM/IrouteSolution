using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CotizadorWeb.Models
{
    public class AnotherRateModelDto
    {


        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly AnotherRateModelDao AnotherRateModelsDao = new AnotherRateModelDao();

        public List<AnotherRateModel> ConsultaAnotherRateModel()
        {
            List<AnotherRateModel> ListaAnotherRateModel = new List<AnotherRateModel>();
            try
            {

                if (!isOnline)
                {
                    Log.Info("Consulta AnotherRateModel OffLine");
                }
                else
                {
                    ListaAnotherRateModel = AnotherRateModelsDao.ListaAnotherRateModel();
                    Log.Info("Consulta AnotherRateModel OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaAnotherRateModel;
        }



        public int IngAnotherRateModel(AnotherRateModel anotherRateModels)
        {
            int Id = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("Ingresar AnotherRateModel OffLine");
                }
                else
                {
                    AnotherRateModelsDao.IngresoAnotherRateModel(anotherRateModels);
                    Log.Info("Ingresar ForAgeModels OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return Id;
        }



        public int ActAnotherRateModel(AnotherRateModel anotherRateModels)
        {
            int Id = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("Actualizar AnotherRateModel OffLine");
                }
                else
                {
                    AnotherRateModelsDao.ActualizarAnotherRateModel(anotherRateModels);
                    Log.Info("Actualizar AnotherRateModel OnLine");
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