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
    public class ConfiguracionesController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly BeneficiosAdiDto beneficiosAdiDto = new BeneficiosAdiDto();
        private readonly CategoriasDto categoriasDto = new CategoriasDto();
        private readonly ConfiguracionesDto configuracionesDto = new ConfiguracionesDto();
        private readonly ProvinciaDto provinciasDto = new ProvinciaDto();
        private readonly RegionDto regionesDto = new RegionDto();
        private readonly ForAgeModelDto ageModelDto = new ForAgeModelDto();
        private readonly ForAgeModelConfigDto ageConfigModelDto = new ForAgeModelConfigDto();
        private readonly AnotherRateModelDto AnotherRateModelsDto = new AnotherRateModelDto();

        [HttpGet]
        [Route("api/GetBeneficiosAdicionales")]
        public IHttpActionResult GetBeneficiosAdicionales()
        {
            List<BeneficiosAdicionales> ListaBeneficiosAd;
            try
            {
                ListaBeneficiosAd = beneficiosAdiDto.ObtenerBeneficios();

                Log.Info("Consulta Beneficios Adicionales con exito.");
                return Ok(ListaBeneficiosAd);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/IngBeneficio")]
        public IHttpActionResult IngBeneficio(BeneficiosAdicionales beneficiosA)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(beneficiosA.IdPlan)) || Convert.ToString(beneficiosA.IdPlan) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el plan." });
                }
                if (string.IsNullOrEmpty(beneficiosA.DescBeneficio))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el nombre del Beneficio." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(beneficiosA.Costo)) || Convert.ToString(beneficiosA.Costo) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el valor del Beneficio." });
                }
                if (string.IsNullOrEmpty(beneficiosA.Descripcion))
                {
                    beneficiosA.Descripcion = "";
                }
                if (string.IsNullOrEmpty(beneficiosA.Observacion))
                {
                    beneficiosA.Observacion = "";
                }

                int IdBeneficio = beneficiosAdiDto.IngBeneficioAdicional(beneficiosA);

                Log.Info("IngBeneficio con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = IdBeneficio });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ActBeneficio")]
        public IHttpActionResult ActBeneficio(BeneficiosAdicionales beneficiosA)
        {

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(beneficiosA.IdBeneficio)) || Convert.ToString(beneficiosA.IdBeneficio) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el Id del Beneficio Adicional." });
                }

                int retorno = beneficiosAdiDto.ActualizaBeneficioAdicional(beneficiosA);
                Log.Info("ActBeneficio con exito. " + retorno);

                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        

        [HttpGet]
        [Route("api/GetCategorias")]
        public IHttpActionResult GetCategorias()
        {
            List<Categorias> ListaCategorias;

            try
            {
                ListaCategorias = categoriasDto.ObtenerCategorias();

                Log.Info("Consulta de Categorias con exito.");
                return Ok(ListaCategorias);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetConfiguraciones")]
        public IHttpActionResult GetConfiguraciones()
        {
            List<Configuraciones> ListaConfiguraciones;
            try
            {
                ListaConfiguraciones = configuracionesDto.ObtenerConfiguraciones();

                Log.Info("Consulta de Configuraciones con exito.");
                return Ok(ListaConfiguraciones);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/IngConfiguraciones")]
        public IHttpActionResult IngConfiguraciones(Configuraciones PConfiguracion)
        {
            try
            {
                int IdConf = configuracionesDto.IngresoConfiguracion(PConfiguracion);

                Log.Info("Ingreso de configuracion con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso de configuracion con exito", IdIngreso = IdConf });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActConfiguraciones")]
        public IHttpActionResult ActConfiguraciones(List<Configuraciones> PConfiguraciones)
        {
            try
            {
                int retorno = configuracionesDto.ActualizaConfiguraciones(PConfiguraciones);

                Log.Info("Actualizacion de configuracion con exito. "+ retorno);
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion de configuracion con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetCatalogosBeneficios")]
        public IHttpActionResult GetCatalogosBeneficios()
        {
            List<BeneficiosAdicionales> ListaBeneficiosAd;
            try
            {
                ListaBeneficiosAd = beneficiosAdiDto.ConsultaCatalogosBeneficios();

                Log.Info("ConsultaCatalogosBeneficios con exito.");
                return Ok(ListaBeneficiosAd);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/IngCatalogoBeneficio")]
        public IHttpActionResult IngCatalogoBeneficio(BeneficiosAdicionales beneficiosA)
        {
            try
            {
                if (string.IsNullOrEmpty(beneficiosA.DescBeneficio))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el nombre del Beneficio." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(beneficiosA.Costo)) || Convert.ToString(beneficiosA.Costo) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el valor del Beneficio." });
                }

                int IdBeneficio = beneficiosAdiDto.InsertaCatalogoBeneficio(beneficiosA);

                Log.Info("InsertaCatalogoBeneficio con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = IdBeneficio });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ActCatalogoBeneficio")]
        public IHttpActionResult ActCatalogoBeneficio(BeneficiosAdicionales beneficiosA)
        {

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(beneficiosA.IdCatalogoBeneficio)) || Convert.ToString(beneficiosA.IdCatalogoBeneficio) == "0")
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el Id del Catalogo Beneficio ." });
                }

                int retorno = beneficiosAdiDto.ActualizaCatalogoBeneficio(beneficiosA);
                Log.Info("ActualizaCatalogoBeneficio con exito. " + retorno);

                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetProvincias")]
        public IHttpActionResult GetProvincias()
        {
            List<Provincias> lista;
            try
            {
                lista = provinciasDto.ObtenerProvincias();

                Log.Info("ConsultaCatalogosBeneficios con exito.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetRegiones")]
        public IHttpActionResult GetRegiones()
        {
            List<Regiones> lista;
            try
            {
                lista = regionesDto.ObtenerRegiones();

                Log.Info("ConsultaCatalogosBeneficios con exito.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        //[HttpGet]
        //[Route("api/GetSecciones")]
        //public IHttpActionResult GetSecciones()
        //{
        //    SeccionesDto seccionesDto = new SeccionesDto();
        //    List<Seccion> lista;
        //    try
        //    {
        //        lista = seccionesDto.ObtenerSecciones();
        //        Log.Info("Consulta secciones con exito.");
        //        return Ok(lista);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
        //    }
        //}


        //[HttpPost]
        //[Route("api/GuardarSeccion")]
        //public IHttpActionResult GuardarSeccion(Seccion seccion)
        //{
        //    SeccionesDto seccionesDto = new SeccionesDto();
        //    try
        //    {
        //        int idSeccion = seccionesDto.GuardarSeccion(seccion);
        //        Log.Info("Guardado de seccion con exito.");
        //        return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = idSeccion });
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
        //    }
        //}

        //[HttpGet]
        //[Route("api/GetCaracteristicas")]
        //public IHttpActionResult GetCaracteristicas(string tipoPlan, int seccionId, int estado)
        //{
        //    SeccionesDto seccionesDto = new SeccionesDto();
        //    List<Seccion> lista;
        //    try
        //    {
        //        lista = seccionesDto.ObtenerSecciones();
        //        Log.Info("Consulta secciones con exito.");
        //        return Ok(lista);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
        //    }
        //}


        //[HttpPost]
        //[Route("api/GuardarCaracteristica")]
        //public IHttpActionResult GuardarCaracteristica(Seccion seccion)
        //{
        //    SeccionesDto seccionesDto = new SeccionesDto();
        //    try
        //    {
        //        if (seccion == null)
        //        {
        //            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
        //        }
        //        else if((seccion.Nombre ?? "").Trim().Length == 0)
        //        {
        //            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El campo nombre es requerido." });
        //        }
        //        else if ((seccion.TipoPlan ?? "").Trim().Length == 0)
        //        {
        //            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El campo tipo plan es requerido." });
        //        }
        //        else
        //        {
        //            int idSeccion = seccionesDto.GuardarSeccion(seccion);
        //            Log.Info("Guardado de seccion con exito.");
        //            return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = idSeccion });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
        //    }
        //}


        [HttpPost]
        [Route("api/GuardarCaracteristicasSecciones")]
        public IHttpActionResult GuardarCaracteristicasSecciones(List<SeccionCaracteristicas> secciones)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (secciones == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if (secciones.Count ==  0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la peticion no es válido." });
                }
                else
                {
                    string mensaje = caracteristicasDto.GuardarCaracteristicasSecciones(secciones);
                    Log.Info("Guardado de seccion con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = mensaje, IdIngreso = mensaje.Equals("SUCCESS") ? 1 : 0 });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/ConsultarCaracteristicasSecciones")]
        public IHttpActionResult ConsultarCaracteristicasSecciones(bool isPool)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                List<SeccionCaracteristicas> seccionCaracteristicas = caracteristicasDto.ConsultarCaracteristicasSecciones(isPool ? 3 : 1);
                Log.Info("Guardado de seccion con exito.");
                return Ok(seccionCaracteristicas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/ConsultarCatalogoCaracteristicas")]
        public IHttpActionResult ConsultarCatalogoCaracteristicas(int estado)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                List<CatalogoCaracteristica> seccionCaracteristicas = caracteristicasDto.ConsultarCatalogoCaracteristicas(estado);
                Log.Info("Consulta de caracteristicas con exito.");
                return Ok(seccionCaracteristicas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/ConsultarCaracteristicasDisponibles")]
        public IHttpActionResult ConsultarCaracteristicasDisponibles(bool isPool)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                List<CatalogoCaracteristica> seccionCaracteristicas = caracteristicasDto.ConsultarCaracteristicasDisponibles(isPool);
                Log.Info("Consulta de caracteristicas con exito.");
                return Ok(seccionCaracteristicas);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/GuardarCatalogoCaracteristicas")]
        public IHttpActionResult GuardarCatalogoCaracteristicas(CatalogoCaracteristica caracteristica)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (caracteristica == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if ((caracteristica.Caracteristica?.Trim() ?? "").Equals(""))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El nombre de la caracteristica no es válida." });
                }
                else
                {
                    int idCaracteristica = caracteristicasDto.GuardarCatalogoCaracteristicas(caracteristica);
                    Log.Info("Guardado de caracteristica con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = idCaracteristica > 0 ? "SUCCESS" : "FAIL", IdIngreso = idCaracteristica });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/ConsultarCatalogoSecciones")]
        public IHttpActionResult ConsultarCatalogoSecciones(int estado)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                List<Secciones> seccionCatalogos = caracteristicasDto.ConsultarCatalogoSecciones(estado);
                Log.Info("Consulta de secciones con exito.");
                return Ok(seccionCatalogos);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/GuardarCatalogoSecciones")]
        public IHttpActionResult GuardarCatalogoSecciones(Secciones seccion)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (seccion == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if ((seccion.Seccion?.Trim() ?? "").Equals(""))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El nombre de la seccion no es válida." });
                }
                else
                {
                    int idSeccion = caracteristicasDto.GuardarCatalogoSecciones(seccion);
                    Log.Info("Guardado de seccion con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = idSeccion > 0 ? "SUCCESS" : "FAIL", IdIngreso = idSeccion });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        // Mantenedor de Rango de Edades Generales
        [HttpGet]
        [Route("api/ForAgeRange")]
        // Si el IdRango es igual a 0 devuelve sin aplicar filtro por IdRango
        // Si el Estado es igual a -1 devuelve sin aplicar filtro por estado
        public IHttpActionResult ConsultarRangoEdad(int IdRango = 0, int Estado = -1)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                List<RateConfigModel> rangos = new List<RateConfigModel>();
                rangos.Add(new RateConfigModel() { Id = 1, ValorMinimo = 0, ValorMaximo = 5, Rango="0-5", Estado=1 });
                if(IdRango == 0)
                {
                    rangos.Add(new RateConfigModel() { Id = 2, ValorMinimo = 6, ValorMaximo = 15, Rango = "6-15", Estado = 1 });
                }
                //List<RateConfigModel> rangos = caracteristicasDto.ConsultarRangoEdadl(IdRango);
                Log.Info("Consulta de secciones con exito.");
                return Ok(rangos);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/ForAgeRange")]
        public IHttpActionResult AgregarRangoEdad(RateConfigModel rate)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (rate == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if ((rate.Rango?.Trim() ?? "").Equals(""))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El valor del rango no es válido." });
                }
                else
                {
                    int idRango = 1;
                    //int idRango = caracteristicasDto.AgregarRangoEdad(rate);
                    Log.Info("Guardado de rango con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = idRango > 0 ? "SUCCESS" : "FAIL", IdIngreso = idRango });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ForAgeRange")]
        public IHttpActionResult ModificarRangoEdad(RateConfigModel rate)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (rate == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if ((rate.Rango?.Trim() ?? "").Equals(""))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El valor del rango no es válido." });
                }
                else
                {
                    int idRango = 1;
                    //int idRango = caracteristicasDto.UpdateRangoEdad(rate);
                    Log.Info("Guardado de rango con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = idRango > 0 ? "SUCCESS" : "FAIL", IdIngreso = idRango });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        // Mantenedor de Rango de Edades Dependientes Ninos Solos
        [HttpGet]
        [Route("api/ForAnotherAgeRange")]
        // Si el IdRango es igual a 0 devuelve sin aplicar filtro por IdRango
        // Si el Estado es igual a -1 devuelve sin aplicar filtro por estado
        public IHttpActionResult ConsultarOtroEdad(int Id = 0, int Estado = -1)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                List<AnotherRateConfigModel> rangos = new List<AnotherRateConfigModel>();
                rangos.Add(new AnotherRateConfigModel() { Id = 1, ValorMinimo = 0, ValorMaximo = 5, Rango = "0-5", Estado = 1 });
                if (Id == 0)
                {
                    rangos.Add(new AnotherRateConfigModel() { Id = 2, ValorMinimo = 6, ValorMaximo = 15, Rango = "6-15", Estado = 1 });
                }
                //List<RateConfigModel> rangos = caracteristicasDto.ConsultarRangoEdadl(IdRango);
                Log.Info("Consulta de secciones con exito.");
                return Ok(rangos);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/ForAnotherAgeRange")]
        public IHttpActionResult AgregarOtroEdad(AnotherRateConfigModel rate)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (rate == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if ((rate.Rango?.Trim() ?? "").Equals(""))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El valor del rango no es válido." });
                }
                else
                {
                    int idRango = 1;
                    //int idRango = caracteristicasDto.AgregarRangoEdad(rate);
                    Log.Info("Guardado de rango con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = idRango > 0 ? "SUCCESS" : "FAIL", IdIngreso = idRango });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ForAnotherAgeRange")]
        public IHttpActionResult ModificarOtroEdad(AnotherRateConfigModel rate)
        {
            CaracteristicasDto caracteristicasDto = new CaracteristicasDto();
            try
            {
                if (rate == null)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El cuerpo de la petición no es válido." });
                }
                else if ((rate.Rango?.Trim() ?? "").Equals(""))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El valor del rango no es válido." });
                }
                else
                {
                    int idRango = 1;
                    //int idRango = caracteristicasDto.UpdateRangoEdad(rate);
                    Log.Info("Guardado de rango con exito.");
                    return Ok(new Salida { Codigo = 1, Mensaje = idRango > 0 ? "SUCCESS" : "FAIL", IdIngreso = idRango });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        //Se realizaron los metodos de INGRESO, CONSULTAR Y ACTUALIZAR DE EL MODELO ForAgeModel
        //Autor: Leonardo Mancero M.

        [HttpGet]
        [Route("api/ForAgeModel")]
        public IHttpActionResult GetForAgeModel()
        {
            List<ForAgeModel> ListaForAgeModel;
            try
            {
                ListaForAgeModel = ageModelDto.ConsultaForAgeModel();

                Log.Info("ConsultaForAgeModel con exito.");
                return Ok(ListaForAgeModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }



        [HttpPost]
        [Route("api/IngForageModel")]
        public IHttpActionResult IngForAgeModel(ForAgeModel ageModel)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(ageModel.edad)) )
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar la Edad." });
                }
               
                if (string.IsNullOrEmpty(Convert.ToString(ageModel.femeninoConMaternidad)) )
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar si es femenino con Maternidad." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageModel.femeninoSinMaternidad)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar si es femenino sin Maternidad." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(ageModel.masculino)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar si es femenino sin Maternidad." });
                }


                int Id = ageModelDto.IngForAgeModel(ageModel);

                Log.Info("IngForAgeModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }



        [HttpPut]
        [Route("api/ActForageModel")]
        public IHttpActionResult ActForAgeModel(ForAgeModel ageModel)
        {
            try
            {
                if (ageModel.id==0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar codigo a modificar" });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageModel.edad)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar la Edad." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageModel.femeninoConMaternidad)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar si es femenino con Maternidad." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageModel.femeninoSinMaternidad)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar si es femenino sin Maternidad." });
                }
                if (string.IsNullOrEmpty(Convert.ToString(ageModel.masculino)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar si es femenino sin Maternidad." });
                }


                int Id = ageModelDto.ActForAgeModel(ageModel);

                Log.Info("ActForAgeModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        //Se realizaron los metodos de INGRESO, CONSULTAR Y ACTUALIZAR DE EL MODELO ForAgeConfigModel
        //Autor: Leonardo Mancero M.

        [HttpGet]
        [Route("api/ForAgeConfigModel")]
        public IHttpActionResult GetForAgeConfigModel()
        {
            List<ForAgeConfigModel> ListaForAgeConfigModel;
            try
            {
                ListaForAgeConfigModel = ageConfigModelDto.ConsultaForAgeConfigModel();

                Log.Info("ConsultaForAgeConfigModel con exito.");
                return Ok(ListaForAgeConfigModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngForageConfigModel")]
        public IHttpActionResult IngForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(ageConfigModel.RangoMaximo)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Rango Maximo." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageConfigModel.RangoMinimo)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Rango Minimo." });
                }

              
                if (string.IsNullOrEmpty(Convert.ToString(ageConfigModel.Estado)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar el Estado." });
                }


                int Id = ageConfigModelDto.IngresarForAgeConfigModel(ageConfigModel);

                Log.Info("ForAgeConfigModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }



        [HttpPut]
        [Route("api/ActForageConfigModel")]
        public IHttpActionResult ActForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            try
            {
                if (ageConfigModel.IdRango == 0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar codigo a modificar" });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageConfigModel.RangoMaximo)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el Rango Maximo." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageConfigModel.RangoMinimo)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el Rango Minimo." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(ageConfigModel.Estado)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar el Estado." });
                }
                


                int Id = ageConfigModelDto.ActualizarForAgeConfigModel(ageConfigModel);

                Log.Info("ForAgeConfigModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }



        [HttpPut]
        [Route("api/EliForageConfigModel")]
        public IHttpActionResult EliForAgeConfigModel(ForAgeConfigModel ageConfigModel)
        {
            try
            {
                if (ageConfigModel.IdRango == 0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar codigo a modificar" });
                }

                
                int Id = ageConfigModelDto.EliminarForAgeConfigModel(ageConfigModel);

                Log.Info("ForAgeConfigModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Eliminado con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        //Se realizaron los metodos de INGRESO, CONSULTAR Y ACTUALIZAR DE EL MODELO ForAgeConfigModel
        //Autor: Leonardo Mancero M.


        [HttpGet]
        [Route("api/AnotherRateModel")]
        public IHttpActionResult GetAnotherRateModel()
        {
            List<AnotherRateModel> ListaAnotherRateModel;
            try
            {
                ListaAnotherRateModel = AnotherRateModelsDto.ConsultaAnotherRateModel();

                Log.Info("ConsultaAnotherRateModel con exito.");
                return Ok(ListaAnotherRateModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/IngAnotherRateModel")]
        public IHttpActionResult IngAnotherRateModel(AnotherRateModel anotherRateModels)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(anotherRateModels.edad)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Edad." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(anotherRateModels.dependientes)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Dependientes." });
                }


                if (string.IsNullOrEmpty(Convert.ToString(anotherRateModels.ninosSolos)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar valor en Niños Solos." });
                }


                int Id = AnotherRateModelsDto.IngAnotherRateModel(anotherRateModels);

                Log.Info("AnotherRateModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }



        [HttpPut]
        [Route("api/ActAnotherRateModel")]
        public IHttpActionResult ActAnotherRateModel(AnotherRateModel anotherRateModels)
        {
            try
            {
                if (anotherRateModels.id == 0)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar codigo a modificar" });
                }

                if (string.IsNullOrEmpty(Convert.ToString(anotherRateModels.edad)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar la Edad." });
                }

                if (string.IsNullOrEmpty(Convert.ToString(anotherRateModels.dependientes)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe ingresar Dependientes." });
                }


                if (string.IsNullOrEmpty(Convert.ToString(anotherRateModels.ninosSolos)))
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Debe de Ingresar valor en Niños Solos." });
                }



                int Id = AnotherRateModelsDto.ActAnotherRateModel(anotherRateModels);

                Log.Info("AnotherRateModel con exito.");
                return Ok(new Salida { Codigo = 1, Mensaje = "Actualizacion con exito", IdIngreso = Id });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

    }
}