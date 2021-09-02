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
    public class MantenimientoPlanController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly PlanesDto planesDto = new PlanesDto();
        private readonly BeneficiosAdiDto beneficiosAdiDto = new BeneficiosAdiDto();
        private readonly CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
        private readonly ProductoDto productoDto = new ProductoDto();

        [HttpGet]
        [Route("api/GetProductos")]
        public IHttpActionResult GetProductos()
        {
            List<Productos> ListaProductos;
            try
            {
                ListaProductos = productoDto.ListaProductos();
                

                Log.Info("Consulta productos con exito.");
                return Ok(ListaProductos);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetPlanes")]
        public IHttpActionResult GetPlanes()
        {
            List<Planes> ListaPlanes;
            try
            {
                ListaPlanes = planesDto.ObtenerPlanes();
                //if (ListaPlanes.Count <= 0)
                //{
                //    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "No se encontraron planes." });
                //}

                Log.Info("Consulta Planes con exito.");
                return Ok(ListaPlanes);

            } catch(Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetPlanById")]
        public IHttpActionResult GetPlanById(int idPlan)
        {
            Planes planById;
            try
            {
                planById = planesDto.ObtenerPlanesByIdPlan(idPlan);
                if (string.IsNullOrEmpty(planById.DescPlan))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "No se encontró plan." });
                }

                Log.Info("Consulta de plan con exito.");
                return Ok(planById);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        //Valida si existe plan borrador asociado para no permitir editar
        [HttpGet]
        [Route("api/ValidaPlan")]
        public IHttpActionResult ValidaPlan(int idPlan)
        {
            bool NoExistePlanBorrador;
            try
            {
                NoExistePlanBorrador = planesDto.ValidaPlan(idPlan);

                Log.Info("ValidaPlan con exito.");
                return Ok(NoExistePlanBorrador);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        //Ingresa un plan nuevo y plan nuevo basado en existente
        //isBorrador Ingresa un plan Borrador con la version anterior
        [HttpPost]
        [Route("api/IngPlan")]
        public IHttpActionResult IngPlan(Planes plan)
        {
            try
            {
                if (plan.IdPlan > 0)
                {
                    plan.PlanAnterior = plan.IdPlan;
                    if (string.IsNullOrEmpty(plan.DescPlan))
                    {
                        plan.DescPlan = "";
                    }
                    if (string.IsNullOrEmpty(plan.Descripcion))
                    {
                        plan.Descripcion = "";
                    }
                }
                else
                //Plan nuevo con datos ingresados por el administrador
                {
                    if (string.IsNullOrEmpty(Convert.ToString(plan.IdProducto)) || Convert.ToString(plan.IdProducto) == "0")
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el producto" });
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(plan.IdTipoTarifa)) || Convert.ToString(plan.IdTipoTarifa) == "0")
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el tipo de tarifa" });
                    }
                    if (string.IsNullOrEmpty(plan.DescPlan))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Nombre del Plan" });
                    }
                    if (string.IsNullOrEmpty(plan.Descripcion))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar una Descripcion del Plan" });
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(plan.EdadMaxMaternidad)))
                    {
                        plan.EdadMaxMaternidad = 0;
                    }
                }
                //Todos se crean en estado borrador
                plan.Estado = 3;

                int IdPlan = planesDto.IngresoPlan(plan);

                Log.Info("IngresoPlan=> " + IdPlan);
                return Ok(new SalidaPlan { IdPlan = IdPlan });
                //return Ok(new  "{Idplan: "+ IdPlan+ "}");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        

        [HttpPut]
        [Route("api/ActPlan")]
        public IHttpActionResult ActualizarPlan(Planes plan)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(plan.IdPlan)) || Convert.ToString(plan.IdPlan) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el IdPlan" });
                }
                
                if (plan.isBorrador && plan.Estado == 3)
                {
                    //indica que voy a actualizar los datos del plan
                    if (string.IsNullOrEmpty(plan.DescPlan))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Nombre del Plan a Actualizar" });
                    }
                    if (string.IsNullOrEmpty(plan.Descripcion))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar la Descripcion del Plan a actualizar" });
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(plan.EdadMaxMaternidad)))
                    {
                        plan.EdadMaxMaternidad = 0;
                    }
                    Log.Info("Actualizacion de datos del Plan con exito.");
                }

                Log.Info("Actualizacion de estado del Plan con exito." + plan.Estado);
                
                if (string.IsNullOrEmpty(plan.DescPlan))
                {
                    plan.DescPlan = "";
                }
                if (string.IsNullOrEmpty(plan.Descripcion))
                {
                    plan.Descripcion = "";
                }
                if (string.IsNullOrEmpty(Convert.ToString(plan.EdadMaxMaternidad)))
                {
                    plan.EdadMaxMaternidad = 0;
                }

                int retorno = planesDto.ActualizarPlan(plan);

                Log.Info("Actualizacion de Plan con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion de Plan con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        

        [HttpGet]
        [Route("api/GetCaracteristicas")]
        public IHttpActionResult GetCaracteristicas(int idPlan)
        {
            List<SeccionBloqueDto> ListaCaracteristicas;
            try
            {
                ListaCaracteristicas = caracteristicasDto.ObtenerCaracteristicasPlan(idPlan);
                /*if (ListaCaracteristicas.Count <= 0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "No se encontraron caracteristicas asociados al Plan." });
                    //return Ok(datosSalida = new Salida { Codigo = 0, Mensaje = "No se encontraron caracteristicas asociados al Plan." });
                }*/

                Log.Info("Consulta de Caracteristicas con exito.");
                return Ok(ListaCaracteristicas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
                //return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/GetCaracteristicasNew")]
        public IHttpActionResult GetCaracteristicasNew(int idPlan)
        {
            List<Caracteristicas> ListaCaracteristicas;
            try
            {
                ListaCaracteristicas = caracteristicasDto.ObtenerCaracteristicasNew(idPlan);
                
                Log.Info("Consulta de Caracteristicas con exito.");
                return Ok(ListaCaracteristicas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
                //return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/IngCaracteristicas")]
        public IHttpActionResult IngCaracteristicas(List<Caracteristicas> PCaracteristicas)
        {
            try
            {
                int retorno = caracteristicasDto.IngresoCaracteristicas(PCaracteristicas);

                Log.Info("IngCaracteristicas con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ActCaracteristicas")]
        public IHttpActionResult ActCaracteristicas(List<Caracteristicas> PCaracteristicas)
        {
            try
            {
                int retorno = caracteristicasDto.ActualizaCaracteristicas(PCaracteristicas);

                Log.Info("Actualizacion de caracteristicas con exito. " + retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualiza de caracteristicas con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetBeneficioPlan")]
        public IHttpActionResult GetBeneficioPlan(int IdPlan)
        {
            List<BeneficioPlan> ListaBeneficiosPlan;
            try
            {
                ListaBeneficiosPlan = beneficiosAdiDto.ObtenerBeneficioPlan(IdPlan);

                //if (ListaBeneficiosPlan.Count <= 0)
                //{
                //    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "No se encontraron beneficios Adicionales asociados al Plan." });
                //}

                Log.Info("Consulta Beneficios Adicionales por Plan con exito.");
                return Ok(ListaBeneficiosPlan);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        ///
        [HttpGet]
        [Route("api/GetSecciones")]
        public IHttpActionResult GetSecciones()
        {
            List<Secciones> lSeccionesPlantillasC;
            try
            {
                lSeccionesPlantillasC = caracteristicasDto.ConSecciones();

                Log.Info("GetSecciones con exito.");
                return Ok(lSeccionesPlantillasC);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetPlantillasCaracteristicas")]
        public IHttpActionResult GetPlantillasCaracteristicas(int tipoPlantilla)
        {
            List<PlantillasCaracteristicas> lPlantillasCaracteristicas;
            try
            {
                lPlantillasCaracteristicas = caracteristicasDto.ConPlantillasCaracteristicas(tipoPlantilla);

                Log.Info("GetPlantillasCaracteristicas con exito.");
                return Ok(lPlantillasCaracteristicas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/IngPlantillasCaracteristicas")]
        public IHttpActionResult IngPlantillasCaracteristicas(PlantillasCaracteristicas plantillasC)
        {
            try
            {
                
                if (string.IsNullOrEmpty(Convert.ToString(plantillasC.IdSeccion)) || Convert.ToString(plantillasC.IdSeccion) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el id de la Seccion." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(plantillasC.TipoPlantilla)) || Convert.ToString(plantillasC.TipoPlantilla) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el tipo de plantilla." });
                }
                if (string.IsNullOrEmpty(plantillasC.Descripcion))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar la descripcion de la Plantillas." });
                }

                int idPlantilla = caracteristicasDto.IngresoPlantillasCaract(plantillasC);

                Log.Info("IngPlantillasCaracteristicas con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = idPlantilla });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ActPlantillasCaracteristicas")]
        public IHttpActionResult ActPlantillasCaracteristicas(PlantillasCaracteristicas plantillasC)
        {

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(plantillasC.IdPlantillaCaract)) || Convert.ToString(plantillasC.IdPlantillaCaract) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el Id de la Caracteristica." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(plantillasC.IdSeccion)) || Convert.ToString(plantillasC.IdSeccion) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el id de la Seccion." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(plantillasC.TipoPlantilla)) || Convert.ToString(plantillasC.TipoPlantilla) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el tipo de Plantilla." });
                }
                if (string.IsNullOrEmpty(plantillasC.Descripcion))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar la descripcion de la Plantillas." });
                }

                int retorno = caracteristicasDto.ActualizaPlantillasCaract(plantillasC);
                Log.Info("ActPlantillasCaracteristicas con exito. " + retorno);

                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

    }

}
