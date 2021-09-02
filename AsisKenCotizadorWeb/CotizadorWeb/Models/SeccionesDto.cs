using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CotizadorWeb.Models
{
    public class SeccionesDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly SeccionesDao seccionesDao = new SeccionesDao();
        /*
        public List<Seccion> ObtenerSecciones()
        {
            List<Seccion> lista = new List<Seccion>();
            try
            {
                if (!isOnline)
                {
                    Log.Info("Consuta configuraciones OffLine");
                    lista.Add(new Seccion() { SeccionID = 1, Nombre = "Cobertura", TipoPlan = "I", Estado = 1 });
                    lista.Add(new Seccion() { SeccionID = 2, Nombre = "Beneficios", TipoPlan = "I", Estado = 1 });
                    lista.Add(new Seccion() { SeccionID = 3, Nombre = "Coberturas Adicionales", TipoPlan = "I", Estado = 1 });
                    lista.Add(new Seccion() { SeccionID = 4, Nombre = "Seccion Prueba", TipoPlan = "I", Estado = 0 });
                    lista.Add(new Seccion() { SeccionID = 5, Nombre = "Coberturas", TipoPlan = "P", Estado = 1 });
                }
                else
                {
                    lista = seccionesDao.ListaSecciones();
                    Log.Info("Consuta configuraciones OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public int GuardarSeccion(Seccion item)
        {
            int idSeccion = 0;
            if (!isOnline)
            {
                idSeccion = 1;
                Log.Info("IngresoConfiguracion OffLine");
            }
            else
            {
                idSeccion = seccionesDao.GuardarSeccion(item);
                Log.Info("IngresoConfiguracion OnLine");
            }

            return idSeccion;
        }
        */
    }
}