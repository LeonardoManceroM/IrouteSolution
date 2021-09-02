using CotizadorWeb.Models;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class TarifasController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly TarifasDto tarifasDto = new TarifasDto();

        [HttpGet]
        [Route("api/GetTiposTarifa")]
        public IHttpActionResult GetTiposTarifa()
        {
            List<TiposTarifa> ListaTiposTarifas;
            try
            {
                ListaTiposTarifas = tarifasDto.ObtenerTiposTarifas();
                if(ListaTiposTarifas.Count <= 0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "No se encontraron Formas de Tarifacion." });
                }

                Log.Info("Consulta Tipos Tarifas con exito.");
                return Ok(ListaTiposTarifas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetTarifaCategoria")]
        public IHttpActionResult GetTarifaCategoria(int idPlan)
        {
            List<TarifasCategoria> ListaTarifasCategorias;
            try
            {
                ListaTarifasCategorias = tarifasDto.ObtenerTarifasCategoriaPlan(idPlan);

                Log.Info("Consulta Tipos Tarifas con exito.");
                return Ok(ListaTarifasCategorias);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngTarifaCategorias")]
        public IHttpActionResult IngTarifaCategorias(List<TarifasCategoria> PTarifasCategorias)
        {
            try
            {
                int respuesta = tarifasDto.IngresoTarifasCategoria(PTarifasCategorias);
                Log.Info("Ingreso de categorias con exito. " + respuesta);
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso de categorias con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActTarifaCategorias")]
        public IHttpActionResult ActTarifaCategorias(List<TarifasCategoria> PTarifasCategorias)
        {
            try
            {
                int retorno = tarifasDto.ActualizaTarifaCategoria(PTarifasCategorias);
                Log.Info("Actualizacion de categorias con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion categorias con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetTarifaNSoloPlan")]
        public IHttpActionResult GetTarifaNSoloPlan(int idPlan)
        {
            TarifasDto tarifaNSolo;
            try
            {
                tarifaNSolo = tarifasDto.ObtenerTarifaNiñoSoloPlan(idPlan);
                
                Log.Info("Consulta Tarifas Niño Solo con exito. ");
                return Ok(tarifaNSolo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngTarifasNSolo")]
        public IHttpActionResult IngTarifasNSolo(TarifaNiñoSolo PTarifaNSolo)
        {
            try
            {
                int idRespuesta = tarifasDto.IngresaTarifaNiñoSoloPlan(PTarifaNSolo);
                
                Log.Info("Ingreso de tarifa niño solo con exito");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActTarifasNSolo")]
        public IHttpActionResult ActTarifasNSolo(TarifaNiñoSolo PTarifaNSolo)
        {
            try
            {
                int retorno = tarifasDto.ActualizaNiñoSolo(PTarifaNSolo);

                Log.Info("Actualizacion Tarifa Niño solo con exito. " +retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito." });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetHeaderTarifa")]
        public IHttpActionResult GetHeaderTarifa(int idPlan)
        {
            HeaderTarifa headerTarifas;
            try
            {
                headerTarifas = tarifasDto.ObtenerCabecerasTarifasPlan(idPlan);

                Log.Info("Consulta de Cabeceras de Tarifas con exito");
                return Ok(headerTarifas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetTarifaEdadPlan")]
        public IHttpActionResult GetTarifaEdadPlan(int idPlan)
        {
            TarifaEdad tarifaEdad;
            try
            {
                tarifaEdad = tarifasDto.ObtenerTarifaEdadPlan(idPlan);
                
                Log.Info("Consulta de Tarifas por Rango de Edad con exito");
                return Ok(tarifaEdad);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngTarifaEdad")]
        public IHttpActionResult IngTarifaEdad(TarifaEdad PTarifaEdad)
        {
            try
            {
                int respuesta = tarifasDto.IngresoTarifaEdad(PTarifaEdad);
                
                Log.Info("Ingreso de tarifa por Edad con exito. " + respuesta);
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActTarifaEdad")]
        public IHttpActionResult ActTarifaEdad(TarifaEdad PTarifaEdad)
        {
            try
            {
                int retorno = tarifasDto.ActualizaTarifaEdad(PTarifaEdad);
                
                Log.Info("Actualizacion de tarifa por Edad con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualiza con exito" });
            }
             catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetTarifasGenerosPlan")]
        public IHttpActionResult GetTarifasGenerosPlan(int idPlan)
        {
            List<TarifaGenero> ListaTarifaGeneros;
            try
            {
                ListaTarifaGeneros = tarifasDto.ObtenerTarifasGenerosPlan(idPlan);

                Log.Info("Consulta de Tarifas por Genero con exito");
                return Ok(ListaTarifaGeneros);
            } 
            catch(Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngTarifasGenero")]
        public IHttpActionResult IngTarifasGenero(List<TarifaGenero> PTarifasGenero)
        {
            try
            {
                int respuesta = tarifasDto.IngresoTarifasGenero(PTarifasGenero);

                Log.Info("Ingreso de tarifas por Genero con exito. " + respuesta);
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso de tarifas por Genero con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActTarifasGenero")]
        public IHttpActionResult ActTarifasGenero(List<TarifaGenero> PTarifasGenero)
        {
            try
            {
                int retorno = tarifasDto.ActualizaTarifasGenero(PTarifasGenero);

                Log.Info("Actualizacion de tarifas por Genero con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion de tarifas por Genero con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetTarifaDependientePlan")]
        public IHttpActionResult GetTarifaDependientePlan(int idPlan)
        {
            List<TarifaGenDependiente> ListaTarifaGenDependientes;
            try
            {
                ListaTarifaGenDependientes = tarifasDto.ObtenerTarifaDependientePlan(idPlan);
               
                return Ok(ListaTarifaGenDependientes);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngTarifaDependientes")]
        public IHttpActionResult IngTarifaDependientes(List<TarifaGenDependiente> PTarifasGenDependientes)
        {
            try
            {
                int respuesta = tarifasDto.IngresoTarifaGDependientes(PTarifasGenDependientes);

                Log.Info("Ingreso de tarifas por Genero dependientes con exito." + respuesta);
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso de tarifas por Genero dependientes con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActTarifaDependientes")]
        public IHttpActionResult ActTarifaDependientes(List<TarifaGenDependiente> PTarifasGenDependientes)
        {
            try
            {
                int retorno = tarifasDto.ActualizaTarifaGDependientes(PTarifasGenDependientes);

                Log.Info("Actualizacion de tarifas por Genero dependientes con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion de tarifas por Genero dependientes con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetTarifasPoolPlan")]
        public IHttpActionResult GetTarifasPoolPlan(int idPlan)
        {
            List<TarifaPool> ListaTarifaPools;
            try
            {
                ListaTarifaPools = tarifasDto.ObtenerTarifasPool(idPlan);

                Log.Info("Consulta Tarifas Pool con exito.");
                return Ok(ListaTarifaPools);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngTarifasPool")]
        public IHttpActionResult IngTarifasPool(List<TarifaPool> PTarifasPool)
        {
            try
            {
                int respuesta = tarifasDto.IngresoTarifasPool(PTarifasPool);
                Log.Info("Ingreso de Tarifas Pool con exito. "+ respuesta);
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso de tarifas Pool con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActTarifasPool")]
        public IHttpActionResult ActTarifasPool(List<TarifaPool> PTarifasPool)
        {
            try
            {
                int retorno = tarifasDto.ActualizaTarifasPool(PTarifasPool);
                Log.Info("Actualizacion de Tarifas Pool con exito. " + retorno);
                return Ok( new Salida { Codigo = 1, Mensaje = "Actualizacion de Tarifas Pool con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        
    }
}
