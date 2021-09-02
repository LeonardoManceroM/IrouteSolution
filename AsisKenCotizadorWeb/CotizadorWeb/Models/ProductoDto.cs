using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class ProductoDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly ProductosDao productosDao = new ProductosDao();
        public List<Productos> ListaProductos()
        {

            List<Productos> listaProductos = new List<Productos>();
            try
            {
                if (!isOnline)
                {
                    
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    listaProductos = productosDao.ListaProductos();
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return listaProductos;
        }
    }
}