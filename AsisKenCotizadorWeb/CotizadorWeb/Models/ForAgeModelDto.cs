using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CotizadorWeb.Models
{
    public class ForAgeModelDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly ForAgeModelDao AgeModelDao = new ForAgeModelDao();
        
        
        
        
        
        public List<ForAgeModel> ConsultaForAgeModel()
        {
            List<ForAgeModel> ListaForAgeModel = new List<ForAgeModel>();
            try
            {

                if (!isOnline)
                {
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaForAgeModel = AgeModelDao.ListaForAgeModel();
                    Log.Info("Consulta ListaForAgeModel OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaForAgeModel;
        }


        public int IngForAgeModel(ForAgeModel ageModel)
        {
            int Id = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("Ingresar ForAgeModels OffLine");
                }
                else
                {
                    AgeModelDao.IngresoForAgeModel(ageModel);
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



        public int ActForAgeModel(ForAgeModel ageModel)
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
                    AgeModelDao.ActualizarForAgeModel(ageModel);
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