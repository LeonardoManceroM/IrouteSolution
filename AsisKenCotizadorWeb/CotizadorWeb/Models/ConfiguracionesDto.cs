using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class ConfiguracionesDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly ConfiguracionesDao configuracionesDao = new ConfiguracionesDao();

        public List<Configuraciones> ObtenerConfiguraciones()
        {
            List<Configuraciones> ListaConfiguraciones = new List<Configuraciones>();
            try
            {
                if (!isOnline)
                {
                    ListaConfiguraciones.Add(new Configuraciones
                    {
                        IdConfiguracion = 1,
                        DescConfiguracion = "Conf_Des_Contado",
                        Observacion = "Se resta",
                        Valor = 5,
                        Descripcion = "Valor descuento al cálculo de Periocidad de Contado"
                    });
                    ListaConfiguraciones.Add(new Configuraciones
                    {
                        IdConfiguracion = 2,
                        DescConfiguracion = "Conf_SSC",
                        Observacion = "Se suma",
                        Valor = 0.5m,
                        Descripcion = "Valor correspondiente al SSC (Seguro Social Campesino)."
                    });
                    ListaConfiguraciones.Add(new Configuraciones
                    {
                        IdConfiguracion = 3,
                        DescConfiguracion = "Conf_Edad_Cotiza",
                        Observacion = "Mayor a",
                        Valor = 18,
                        Descripcion = "Edad para Cotizar"
                    });
                    ListaConfiguraciones.Add(new Configuraciones
                    {
                        IdConfiguracion = 4,
                        DescConfiguracion = "Conf_edad_dep_max",
                        Observacion = "hasta",
                        Valor = 24,
                        Descripcion = "Máximo edad para cotizar dependiente"
                    });
                    ListaConfiguraciones.Add(new Configuraciones
                    {
                        IdConfiguracion = 5,
                        DescConfiguracion = "Conf_edad_niñosolo_max",
                        Observacion = "hasta",
                        Valor = 17,
                        Descripcion = "Máximo edad para cotizar niño solo"
                    });
                    ListaConfiguraciones.Add(new Configuraciones
                    {
                        IdConfiguracion = 6,
                        DescConfiguracion = "Conf_plan_comparar",
                        Observacion = "hasta",
                        Valor = 5,
                        Descripcion = "Cantidad de Planes Para Comparar"
                    });
                    Log.Info("Consuta configuraciones OffLine");
                }
                else
                {
                    ListaConfiguraciones = configuracionesDao.ListaConfiguraciones();
                    Log.Info("Consuta configuraciones OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaConfiguraciones;
        }

        public int IngresoConfiguracion(Configuraciones configuracion)
        {
            int idConfiguracion = 1;
            if (!isOnline)
            {
                Log.Info("IngresoConfiguracion OffLine");
            }
            else
            {
                idConfiguracion = configuracionesDao.IngresoConfiguracion(configuracion);
                Log.Info("IngresoConfiguracion OnLine");
            }
            
            return idConfiguracion;
        }

        public int ActualizaConfiguraciones(List<Configuraciones> configuraciones)
        {
            int retorno = 1;

            if (!isOnline)
            {
                Log.Info("ActualizaConfiguraciones OffLine");
            }
            else
            {
                retorno = configuracionesDao.ActualizaConfiguraciones(configuraciones);
                Log.Info("ActualizaConfiguraciones OnLine");
            }
            return retorno;
        }
    }
}