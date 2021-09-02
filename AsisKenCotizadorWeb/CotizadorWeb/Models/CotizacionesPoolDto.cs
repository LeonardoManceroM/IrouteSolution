using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class CotizacionesPoolDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CotizacionPoolDao cotizacionPoolDao = new CotizacionPoolDao();
        private readonly CaracteristicasDao caracteristicasDao = new CaracteristicasDao();
        private readonly ConfiguracionesDto configuracionesDto = new ConfiguracionesDto();

        public List<CotizacionesPool> ObtenerCotizacionesPool(int idCotizacion)
        {
            List<CotizacionesPool> ListaCotizacionesPool = new List<CotizacionesPool>();
            try
            {
                if (!isOnline)
                {
                    ListaCotizacionesPool.Add(new CotizacionesPool
                    {
                        IdCotizacion = 1,
                        IdUsuario = 1,
                        IdPlan = 4,
                        Cliente = "Johanna Guano",
                        Actividad = "Comercio",
                        FechaCotiza = DateTime.Now,
                        Estado = true,
                        DescEstado = "Activo",
                        ValorMensual = 60,
                        ValorTrimestral = 180,
                        ValorSemestral = 360,
                        ValorAnual = 720,
                        ValorContado = 720,
                        NombrePlan = "POOL 1",
                        DescEstadoPlan = "Activo"
                    });
                    ListaCotizacionesPool.Add(new CotizacionesPool
                    {
                        IdCotizacion = 2,
                        IdUsuario = 1,
                        IdPlan = 4,
                        Cliente = "SANA SANA",
                        Actividad = "Comercio",
                        FechaCotiza = DateTime.Now,
                        Estado = true,
                        DescEstado = "Activo",
                        ValorMensual = 60,
                        ValorTrimestral = 180,
                        ValorSemestral = 360,
                        ValorAnual = 720,
                        ValorContado = 720,
                        NombrePlan = "POOL 1",
                        DescEstadoPlan = "Activo"
                    });
                }
                else
                    ListaCotizacionesPool.Add(cotizacionPoolDao.ObtenerCotizacionById(idCotizacion));
                
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return ListaCotizacionesPool;
        }

        public int IngresoCotizacionesPool(CotizacionesPool cotizacionesPool)
        {
            int respuesta=0;
            try
            {
                respuesta = cotizacionPoolDao.Guardar(cotizacionesPool);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return respuesta;
        }

        public int ActualizaCotizacionesPool(CotizacionesPool cotizacionesPool)
        {
            int retorno=0;
            try
            {
                cotizacionPoolDao.Modificar(cotizacionesPool);
                retorno = cotizacionesPool.IdCotizacion;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex); ;
            }
            return retorno;
        }

        //CANTIDAD DE PERSONAS INGRESADAS EN CADA CATEGORIA
        public List<CotizacionCategoriaPool> ObtenerCotizacionCategoriaPool(int idCotizacion)
        {
            List<CotizacionCategoriaPool> ListaCantCotizaCategoriaPool = new List<CotizacionCategoriaPool>();
            try
            {
                if (!isOnline)
                {
                    ListaCantCotizaCategoriaPool.Add(new CotizacionCategoriaPool
                    {
                        IdCotizacionCatPool= 1,
                        IdCotizacion = 1,
                        IdCategoria = 1,
                        Cantidad = 5
                    });
                    ListaCantCotizaCategoriaPool.Add(new CotizacionCategoriaPool
                    {
                        IdCotizacionCatPool = 2,
                        IdCotizacion = 1,
                        IdCategoria = 3,
                        Cantidad = 5
                    });
                    ListaCantCotizaCategoriaPool.Add(new CotizacionCategoriaPool
                    {
                        IdCotizacionCatPool = 3,
                        IdCotizacion = 1,
                        IdCategoria = 5,
                        Cantidad = 9
                    });
                }
                else
                {
                    ListaCantCotizaCategoriaPool = cotizacionPoolDao.ConsultarCategoriaPool(idCotizacion);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return ListaCantCotizaCategoriaPool;
        }

        public bool IngresoCotizacionCategoriaPool(List<CotizacionCategoriaPool> cotizacionCategoriaPools)
        {
            bool respuesta = false;
            try
            {
                respuesta = cotizacionPoolDao.IngresarCategoriaPool(cotizacionCategoriaPools);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            

            return respuesta;
        }

        public bool ActualizaCotizacionCategoriaPool(List<CotizacionCategoriaPool> cotizacionCategoriaPools)
        {
            bool respuesta = false;
            try
            {
                respuesta = cotizacionPoolDao.ModificarCategoriaPool(cotizacionCategoriaPools);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return respuesta;
            ;
        }

        public SeccionCotizacionPoolDto GeneraCotizacionPool(GeneraCotizacionPool datosCotizacionpool, bool comparar)
        {
            List<Caracteristicas> ListaCaracteristicasPlan = new List<Caracteristicas>();
            var CaracteristicasSeccion = new List<SeccionBloqueDto>();
            var CaracteristicasP = new List<SeccionCaracteristicasDto>();
            var DatosCotizacion = new SeccionCotizacionPoolDto();
            GeneraCotizacionResultado cotizacionResultado = new GeneraCotizacionResultado();
            List<Configuraciones> ListaConfiguraciones;

            try
            {
                if (!isOnline)
                {
                    Log.Info("GeneraCotizacionPool OffLine");
                }
                else
                {
                    ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicasByPlan(datosCotizacionpool.IdPlan);

                    ListaCaracteristicasPlan.ForEach(x => {

                        CaracteristicasP.Add(new SeccionCaracteristicasDto
                        {
                            IdSeccion = x.IdSeccion,
                            IdPlantillaC = x.IdPlantillaC,
                            Descripcion = x.Descripcion,
                            IdCaracteristica = x.IdCaracteristica,
                            IdPlan = x.IdPlan,
                            Valor = x.Valor,
                            AplicaMaternidad = x.AplicaMaternidad,
                            AplicaNSolo = x.AplicaNSolo,
                            Estado = x.Estado,
                        });
                    });

                    ListaCaracteristicasPlan.ForEach(x => {
                        if (!CaracteristicasSeccion.Exists(y => y.IdSeccion.Equals(x.IdSeccion)))
                        {
                            CaracteristicasSeccion.Add(new SeccionBloqueDto
                            {
                                IdSeccion = x.IdSeccion,
                                Seccion = x.Seccion,
                                Plantillas = CaracteristicasP.FindAll(z => z.IdSeccion.Equals(x.IdSeccion))
                            });
                        }
                    });

                    //Consultar la observacion final del PDF.
                    ListaConfiguraciones = configuracionesDto.ObtenerConfiguraciones();
                    string observacionFinPdf = (ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_Observaciones_Pdf").Descripcion);


                    //Armar cabecera
                    cotizacionResultado = cotizacionPoolDao.GeneraCotizacionPool(datosCotizacionpool);
                    DatosCotizacion = new SeccionCotizacionPoolDto
                    {
                        NombrePlan = cotizacionResultado.DescPlan,
                        IdCotizacion = cotizacionResultado.IdCotizacion,
                        FechaCotizacion = cotizacionResultado.FechaCotizacion,
                        Cliente = datosCotizacionpool.Cliente,
                        Actividad = datosCotizacionpool.Actividad,
                        CategoriasPools = datosCotizacionpool.CategoriaPools,
                        IdUsuario = datosCotizacionpool.IdUsuario,
                        Agente = cotizacionResultado.Agente,
                        Telefono = cotizacionResultado.Telefono,
                        Agencia = cotizacionResultado.Agencia,
                        Direccion = cotizacionResultado.Direccion,
                        SeccionBloquesPlantillas = CaracteristicasSeccion,
                        Region = cotizacionResultado.Region,
                        VersionPlan = cotizacionResultado.Version_Num,
                        VersionPlanTexto = cotizacionResultado.Version_Text,
                        TarifasResultado = new CalculaTarifasResultado
                        {
                            ValorMensual = cotizacionResultado.ValorMensual,
                            ValorTrimestral = cotizacionResultado.ValorTrimestral,
                            ValorSemestral = cotizacionResultado.ValorSemestral,
                            ValorAnual = cotizacionResultado.ValorAnual,
                            ValorContado = cotizacionResultado.ValorContado
                        },
                        Conf_Observaciones_Pdf = observacionFinPdf
                    };

                    Log.Info("GeneraCotizacionPool OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DatosCotizacion;
        }


    }
}