using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class ProvinciaDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ProvinciaDao provinciasDao = new ProvinciaDao();

        public List<Provincias> ObtenerProvincias()
        {
            List<Provincias> list = new List<Provincias>();
            try
            {
                if (isOnline)
                {
                    list = provinciasDao.ListaProvincias();
                    Log.Info("Consulta OnLine");
                }
                else
                {
                    list.Add(new Provincias() { ProvinciaID = 1, Descripcion = "Guayas" });
                    list.Add(new Provincias() { ProvinciaID = 2, Descripcion = "Pichincha" });
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