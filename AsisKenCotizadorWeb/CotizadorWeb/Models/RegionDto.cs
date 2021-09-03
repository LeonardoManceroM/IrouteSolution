using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class RegionDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegionesDao regionesDao = new RegionesDao();

        public List<Regiones> ObtenerRegiones()
        {
            List<Regiones> list = new List<Regiones>();
            try
            {
                if (isOnline)
                {
                    list = regionesDao.ListaRegiones();
                    Log.Info("Consulta OnLine");
                }
                else
                {
                    list.Add(new Regiones() { RegionID = 1, Descripcion = "Costa" });
                    list.Add(new Regiones() { RegionID = 2, Descripcion = "Sierra" });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return list;
        }
    }
}