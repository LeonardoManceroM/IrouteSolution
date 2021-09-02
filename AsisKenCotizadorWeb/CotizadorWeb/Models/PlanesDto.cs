using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class PlanesDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly PlanesDao planesDao = new PlanesDao();

        public List<Planes> ObtenerPlanes() { 
        
            List<Planes> ListaPlanes = new List<Planes>();
            try
            {
                if (!isOnline)
                {
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 1,
                        DescPlan = "CURAE PLENUS",
                        Descripcion = "Curae",
                        IdTipoTarifa = 1,
                        DescTipoTarifa = "Por Categoria",
                        //AplicaNinoSolo = true,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 2,
                        DescPlan = "EPSILON 80",
                        Descripcion = "Epsilon",
                        IdTipoTarifa = 2,
                        DescTipoTarifa = "Por Rango de Edad",
                        //AplicaNinoSolo = true,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 3,
                        DescPlan = "CURAE SUMA",
                        Descripcion = "Suma",
                        IdTipoTarifa = 3,
                        DescTipoTarifa = "Por Genero",
                        //AplicaNinoSolo = true,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 2,
                        DescProducto = "Pool",
                        IdPlan = 4,
                        DescPlan = "Pool 1",
                        Descripcion = "Opcion 1",
                        IdTipoTarifa = 1,
                        DescTipoTarifa = "Por Categoria",
                        //AplicaNinoSolo = false,
                        Estado = 1,
                        DescEstado = "Activo"
                    });

                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaPlanes = planesDao.ListaPlanes();
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return ListaPlanes;
        }

        public Planes ObtenerPlanesByIdPlan(int idPlan)
        {
            Planes plan = new Planes();
            List<Planes> ListaPlanes = new List<Planes>();

            try
            {
                if (!isOnline)
                {
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 1,
                        DescPlan = "CURAE PLENUS",
                        Descripcion = "Curae",
                        IdTipoTarifa = 1,
                        DescTipoTarifa = "Por Categoria",
                        //AplicaNinoSolo = true,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 2,
                        DescPlan = "EPSILON 80",
                        Descripcion = "Epsilon",
                        IdTipoTarifa = 2,
                        DescTipoTarifa = "Por Rango de Edad",
                        //AplicaNinoSolo = true,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 3,
                        DescPlan = "CURAE SUMA",
                        Descripcion = "Suma",
                        IdTipoTarifa = 3,
                        DescTipoTarifa = "Por Genero",
                        //AplicaNinoSolo = true,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    ListaPlanes.Add(new Planes
                    {
                        IdCobertura = 1,
                        DescCobertura = "Nacional",
                        IdProducto = 2,
                        DescProducto = "Pool",
                        IdPlan = 4,
                        DescPlan = "Pool 1",
                        Descripcion = "Opcion 1",
                        IdTipoTarifa = 1,
                        DescTipoTarifa = "Por Categoria",
                        //AplicaNinoSolo = false,
                        Estado = 1,
                        DescEstado = "Activo"
                    });
                    plan = ListaPlanes.FirstOrDefault(x => x.IdPlan == idPlan);
                    
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    plan = planesDao.ConsultaPlan(idPlan);
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return plan;
        }

        public bool ValidaPlan(int idPlan)
        {
            bool noExistePlanAnterior;
            try
            {
                if (!isOnline)
                {
                    Log.Info("ValidaPlan OffLine");
                    return true;
                }
                else
                {
                    noExistePlanAnterior = planesDao.ValidaPlanAnterior(idPlan);
                    Log.Info("ValidaPlan OnLine. " + noExistePlanAnterior);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return noExistePlanAnterior;
        }

        public int IngresoPlan(Planes plan)
        {
            int IdPlan = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("IngresoPlan OffLine");
                }
                else
                {
                    IdPlan = planesDao.IngresoPlan(plan);
                    Log.Info("IngresoPlan OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return IdPlan;
        }

        public int ActualizarPlan(Planes plan)
        {
            int retorno = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("ActualizarPlan OffLine");
                }
                else
                {
                    retorno = planesDao.ActualizarPlan(plan);
                    Log.Info("ActualizarPlan OnLine. " + retorno);  
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return retorno;
        }

    }
}