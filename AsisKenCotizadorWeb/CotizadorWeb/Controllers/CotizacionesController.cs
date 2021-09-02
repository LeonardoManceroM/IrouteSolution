using CotizadorWeb.Models;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class CotizacionesController : ApiController
    {
        private readonly CotizacionesDto cotizacionesDto = new CotizacionesDto();
        private readonly CotizacionesPoolDto cotizacionesPoolDto = new CotizacionesPoolDto();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly PlanesDto planesDto = new PlanesDto();
        private readonly CalculaTarifasDto calculaTarifasDto = new CalculaTarifasDto();
        private readonly ConfiguracionesDto configuracionesDto = new ConfiguracionesDto();
        private static readonly string CompNoAplicaText = ConfigurationManager.AppSettings["CompNoAplicaText"];


        [HttpGet]
        //[Route("api/GetCotizacionTodos")]
        public IHttpActionResult GetCotizacionTodos(int idUsuario)
        {
            try
            {
                return Ok(cotizacionesDto.ObtenerTodos(idUsuario));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        public IHttpActionResult GetCotizacion(int id)
        {
            try
            {
                return Ok(cotizacionesDto.Obtener(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        /*
        [HttpPost]
        public IHttpActionResult Post(CotizacionesDto cotizacion)
        {
            try
            {
                int id = cotizacionesDto.Insertar(cotizacion);
                if (id > 0)
                {
                    datosSalida.Mensaje = "Ingresado con exito";
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al ingresar" });
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }

        [HttpPut]
        public IHttpActionResult Put(CotizacionesDto cotizacion)
        {
            try
            {
                int id = cotizacionesDto.Modificar(cotizacion);
                if (id > 0)
                {
                    datosSalida.Mensaje = "Modificado con exito";;
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al modificar" });
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        */
        
        
        //COTIZACIONES POOL
        [HttpGet]
        [Route("api/GetCotizacionPool")]
        public IHttpActionResult GetCotizacionPool(int idCotizacion)
        {
            try { return Ok(cotizacionesPoolDto.ObtenerCotizacionesPool(idCotizacion)); }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }

        }

        /*
        [HttpPost]
        [Route("api/IngCotizacionPool")]
        public IHttpActionResult IngCotizacionPool(CotizacionesPool PCotizacionesPool)
        {
            try
            {
                int IdCotizacion = cotizacionesPoolDto.IngresoCotizacionesPool(PCotizacionesPool);
                if (IdCotizacion > 0)
                {
                    datosSalida.Mensaje = "Ingresado con exito";
                }
                else
                {
                    datosSalida.Mensaje = "Error al insertar";
                    return Content(HttpStatusCode.BadRequest, datosSalida);
                    
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ActCotizacionPool")]
        public IHttpActionResult ActCotizacionPool(CotizacionesPool PCotizacionesPool)
        {
            try
            {
                int IdPlan = cotizacionesPoolDto.ActualizaCotizacionesPool(PCotizacionesPool);
                if(IdPlan>0)
                {
                    datosSalida.Mensaje = "Modificado con exito";
                }
                else
                {
                    datosSalida.Mensaje = "Error al modificar";
                    return Content(HttpStatusCode.BadRequest, datosSalida);
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetCotizacionCategoriasPool")]
        public IHttpActionResult GetCotizacionCategoriasPool(int idCotizacion)
        {
            try
            {
                return Ok(cotizacionesPoolDto.ObtenerCotizacionCategoriaPool(idCotizacion));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/IngCotizaCategoriasPool")]
        public IHttpActionResult IngCotizaCategoriasPool(List<CotizacionCategoriaPool> PCotizacionCategoriaPools)
        {
            try
            {
                if(cotizacionesPoolDto.IngresoCotizacionCategoriaPool(PCotizacionCategoriaPools))
                {
                    datosSalida.Mensaje = "Ingresado con exito";
                }
                else
                {
                    datosSalida.Mensaje = "Error al insertar";
                    return Content(HttpStatusCode.BadRequest, datosSalida);
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/ActCotizaCategoriasPool")]
        public IHttpActionResult ActCotizaCategoriasPool(List<CotizacionCategoriaPool> PCotizacionCategoriaPools)
        {
            try
            {
                bool respuesta = cotizacionesPoolDto.ActualizaCotizacionCategoriaPool(PCotizacionCategoriaPools);
                if(respuesta)
                {
                    datosSalida.Mensaje = "Modificado con exito";
                }
                else
                {
                    datosSalida.Mensaje = "Error al modificar";
                    return Content(HttpStatusCode.BadRequest, datosSalida);
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        */

        //################### CALCULAR TARIFAS
        [HttpPut]
        [Route("api/GetCalculaTarifas")]
        public IHttpActionResult GetCalculaTarifas(CalculaTarifas calculaTarifas)
        {
            CalculaTarifasResultado calculaTarifasResultado;
            int contPersonas = 0;
            Planes planes;
            List<Configuraciones> ListaConfiguraciones;
            int edadCotiza= 0, edad_dep_max = 0, edadniñosolo = 0;

            try
            {
                ListaConfiguraciones = configuracionesDto.ObtenerConfiguraciones();
                edadCotiza = Decimal.ToInt32(ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_Edad_Cotiza").Valor);
                edad_dep_max = Decimal.ToInt32(ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_edad_dep_max").Valor);
                edadniñosolo = Decimal.ToInt32(ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_edad_niñosolo_max").Valor);

                //Validaciones titular
                if (calculaTarifas.TitularBeneficio)
                {
                    contPersonas += 1;

                    if (string.IsNullOrEmpty(Convert.ToString(calculaTarifas.TitularEdad)) || Convert.ToString(calculaTarifas.TitularEdad) == "0")
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar la edad del Titular" });
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(calculaTarifas.TitularGenero)))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar el genero del Titular" });
                    }
                    if (calculaTarifas.TitularEdad < edadCotiza)
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Titular debe ser mayor a " + edadCotiza + " años" });
                    }
                    //validar edades hijos
                    foreach (int hijos in calculaTarifas.Dependientes)
                    {
                        contPersonas += 1;
                        if (hijos > edad_dep_max)
                        {
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El límite de edad para cotizar dependientes es " + edad_dep_max + " años." });
                        }
                    }

                    //consulto los datos del plan
                    planes = planesDto.ObtenerPlanesByIdPlan(calculaTarifas.IdPlan);

                    if (planes.ObligaMaternidad && !calculaTarifas.TitularMaternidad)
                    {
                        if (planes.EdadMaxMaternidad != 0 && calculaTarifas.TitularGenero == "F" && calculaTarifas.TitularEdad <= planes.EdadMaxMaternidad)
                        {
                            calculaTarifas.TitularMaternidad = true;
                        }
                        if (planes.EdadMaxMaternidad != 0 && calculaTarifas.ConyugueGenero== "F" && calculaTarifas.ConyugueEdad <= planes.EdadMaxMaternidad)
                        {
                            calculaTarifas.TitularMaternidad = true;
                        }
                    }

                    //Validacion maternidad
                    if (calculaTarifas.TitularMaternidad)
                    {
                        if (calculaTarifas.TitularGenero != "F")
                        {
                            //validar solo para titular solo
                            // (!planes.ObligaMaternidad && contPersonas == 1)
                            if(calculaTarifas.ConyugueGenero != "F")
                                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Atención! No puede seleccionar maternidad para un titular de genero masculino" });
                        }

                        //validar la edad maxima para aplicar maternidad
                        if (planes.EdadMaxMaternidad != 0)
                        {

                            if (calculaTarifas.TitularGenero == "F" && calculaTarifas.TitularEdad > planes.EdadMaxMaternidad)
                            {
                                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El beneficio de maternidad no aplica en este rango de edad" });
                            }
                            if (calculaTarifas.ConyugueGenero == "F" && calculaTarifas.ConyugueEdad > planes.EdadMaxMaternidad)
                            {
                                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El beneficio de maternidad no aplica en este rango de edad" });
                            }
                        }
                    }

                    if (calculaTarifas.ConyugueEdad > 0)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(calculaTarifas.ConyugueGenero)))
                        {
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar el genero del Cónyugue" });
                        }
                        contPersonas += 1;
                    }

  
                }
                //Niños solos
                else
                {
                    foreach (int nsolos in calculaTarifas.Dependientes)
                    {
                        contPersonas += 1;
                        if (nsolos > edadniñosolo)
                        {
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El límite de edad para cotizar niño solo es " + edadniñosolo + " años." });
                        }
                        calculaTarifas.TitularEdad = 0;
                        calculaTarifas.TitularGenero = "";
                        calculaTarifas.ConyugueEdad = 0;
                        calculaTarifas.ConyugueGenero = "";
                    }
                    if (contPersonas <= 0)
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar Edad de Niño solo." });
                    }
                }
                calculaTarifas.ContadorPersonas = contPersonas;

                calculaTarifasResultado = calculaTarifasDto.CalculaTarifas(calculaTarifas);

                Log.Info("Calcula Tarifas con exito. ");
                return Ok(calculaTarifasResultado);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico {Mensaje = exp.Message});
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/GetCalculaTarifasPool")]
        public IHttpActionResult GetCalculaTarifasPool(List<TarifaPool> listaTarifaPools)
        {
            CalculaTarifasResultado calculaTarifasResultado;
            int cantidadMin = 0;
            try
            {
                foreach (var items in listaTarifaPools.ToArray())
                {
                    cantidadMin += items.CantidadMin;
                }

                if (cantidadMin < 5)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Atencion! La cantidad de titulares no puede ser menor a 5." });
                }

                calculaTarifasResultado = calculaTarifasDto.CalculaTarifasPool(listaTarifaPools);

                Log.Info("Calcula Tarifas Pool con exito. ");
                return Ok(calculaTarifasResultado);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = exp.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        //################## COTIZACION INDIVIDUAL
        [HttpPost]
        [Route("api/GeneraCotizacionesIndividual")]
        public IHttpActionResult GeneraCotizacionesIndividual(GeneraCotizacionIndividual cotizacion)
        {
            int contPersonas = 0;
            SeccionCotizacionIndDto cotizacionDto;
            Planes planes;
            List<Configuraciones> ListaConfiguraciones;
            int edadCotiza = 0, edad_dep_max = 0, edadniñosolo = 0;

            try
            {
                ListaConfiguraciones = configuracionesDto.ObtenerConfiguraciones();
                edadCotiza = Decimal.ToInt32(ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_Edad_Cotiza").Valor);
                edad_dep_max = Decimal.ToInt32(ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_edad_dep_max").Valor);
                edadniñosolo = Decimal.ToInt32(ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_edad_niñosolo_max").Valor);

                if (string.IsNullOrEmpty(Convert.ToString(cotizacion.IdCotizacion)))
                {
                    cotizacion.IdCotizacion = 0;
                }

                if (cotizacion.TitularBeneficio)
                {
                    contPersonas += 1;

                    if (string.IsNullOrEmpty(Convert.ToString(cotizacion.TitularEdad)) || Convert.ToString(cotizacion.TitularEdad) == "0")
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar la edad del Titular" });
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(cotizacion.TitularNacimiento)))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar la fecha de Nacimiento Titular" });
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(cotizacion.TitularGenero)))
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar el genero del Titular" });
                    }
                    if (cotizacion.TitularEdad < edadCotiza)
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Titular debe ser mayor a " + edadCotiza + " años" });
                    }
                    //validar edades hijos
                    foreach (int hijos in cotizacion.Dependientes)
                    {
                        contPersonas += 1;
                        if (hijos > edad_dep_max)
                        {
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El límite de edad para cotizar dependientes es " + edad_dep_max + " años." });
                        }
                    }

                    //consulto los datos del plan
                    planes = planesDto.ObtenerPlanesByIdPlan(cotizacion.IdPlan);

                    if (planes.ObligaMaternidad && !cotizacion.TitularMaternidad)
                    {
                        if (planes.EdadMaxMaternidad != 0 && cotizacion.TitularGenero == "F" && cotizacion.TitularEdad <= planes.EdadMaxMaternidad)
                        {
                            cotizacion.TitularMaternidad = true;
                        }
                        if (planes.EdadMaxMaternidad != 0 && cotizacion.ConyugueGenero == "F" && cotizacion.ConyugueEdad <= planes.EdadMaxMaternidad)
                        {
                            cotizacion.TitularMaternidad = true;
                        }
                        Log.Info("Obliga maternidad. " + cotizacion.TitularMaternidad);
                    }

                    //Validacion maternidad
                    if (cotizacion.TitularMaternidad)
                    {
                        if (cotizacion.TitularGenero != "F")
                        {
                            Log.Info("Validacion maternidad. " + cotizacion.ConyugueGenero);
                            //validar solo para titular solo
                            // (!planes.ObligaMaternidad && contPersonas == 1)
                            if (cotizacion.ConyugueGenero != "F")
                                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Atención! No puede seleccionar maternidad para un titular de genero masculino" });
                        }

                        //validar la edad maxima para aplicar maternidad
                        if (planes.EdadMaxMaternidad != 0)
                        {

                            if (cotizacion.TitularGenero == "F" && cotizacion.TitularEdad > planes.EdadMaxMaternidad)
                            {
                                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El beneficio de maternidad no aplica en este rango de edad" });
                            }
                            if (cotizacion.ConyugueGenero == "F" && cotizacion.ConyugueEdad > planes.EdadMaxMaternidad)
                            {
                                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El beneficio de maternidad no aplica en este rango de edad" });
                            }
                        }
                    }
                    if (cotizacion.ConyugueEdad > 0)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(cotizacion.ConyugueGenero)))
                        {
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar el genero del Cónyugue" });
                        }
                        contPersonas += 1;
                    }
                }
                //Niños solos
                else
                {
                    foreach (int nsolos in cotizacion.Dependientes)
                    {
                        contPersonas += 1;
                        if (nsolos > edadniñosolo)
                        {
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! El límite de edad para cotizar niño solo es " + edadniñosolo + " años." });
                        }
                        cotizacion.TitularEdad = 0;
                        cotizacion.TitularGenero = "";
                        cotizacion.ConyugueEdad = 0;
                        cotizacion.ConyugueGenero = "";
                    }
                    if (contPersonas <= 0)
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "¡Atención! Debe ingresar Edad de Niño solo." });
                    }
                }
                cotizacion.ContadorPersonas = contPersonas;

                cotizacionDto = cotizacionesDto.GenereCotizacion(cotizacion);

                Log.Info("GeneraCotizacionesIndividuals con exito. ");
                return Ok(cotizacionDto);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = exp.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
     
        }

        //################## COTIZACION POOL
        [HttpPost]
        [Route("api/GeneraCotizacionesPool")]
        public IHttpActionResult GeneraCotizacionesPool(GeneraCotizacionPool cotizacion)
        {
            SeccionCotizacionPoolDto cotizacionDto;
            int cantidadMin = 0;
            try
            {
                foreach (var items in cotizacion.CategoriaPools)
                {
                    cantidadMin += items.Cantidad;
                }
                
                if (cantidadMin < 5)
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Atencion! La cantidad de titulares no puede ser menor a 5." });
                }

                cotizacionDto = cotizacionesPoolDto.GeneraCotizacionPool(cotizacion, false);

                Log.Info("GeneraCotizacionesPool con exito. ");
                return Ok(cotizacionDto);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = exp.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/ConsultaCotizacion")]
        public IHttpActionResult ConsultaCotizacion(int idCotizacion, bool isPool)
        {
            SeccionCotizaciones cotizacionDto;
            try
            {
                cotizacionDto = cotizacionesDto.ConsultaCotizacionId(idCotizacion, isPool, false);

                Log.Info("Consulta Cotizacion con exito. ");
                return Ok(cotizacionDto);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = exp.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/CompararPlanes")]
        public IHttpActionResult CompararPlanes(CompararPlanes comparar)
        {
            string method = "CompararPlanes";
            SeccionCompararIndDto cotizacionDto = new SeccionCompararIndDto();
            try
            {
                //cotizacionDto = cotADO.CompararPlanes(comparar);  // 07-Dec-020 se comenta el llamado previo.
                // 0.- Validaciones
                if (comparar == null)
                {
                    string message = "Cuerpo de la peticion vacia";
                    Log.Error(method + ": " + message);
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = message });
                }
                else if (comparar.IdCotizacion <= 0)
                {
                    string message = "El valor de la cotizacion base no es valido";
                    Log.Error(method + ": " + message);
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = message });
                }
                else if ((comparar.IdPlan?.Length ?? 0) == 0)
                {
                    string message = "Debe ingresar los planes con los cuales desea hacer la comparacion";
                    Log.Error(method + ": " + message);
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = message });
                }

                // 1.- Consultar Cotizacion Inicial
                Log.Debug("Consultando cotizacion inicial.");
                SeccionCotizaciones cotizacionInicial = cotizacionesDto.ConsultaCotizacionId(comparar.IdCotizacion, false, true);

                // 2.- Generar Cotizaciones Planes a comparar
                Log.Debug("Generando cotizaciones de planes adicionales.");
                List<SeccionCotizaciones> planesAdicionales = new List<SeccionCotizaciones>();
                for (var i = 0; i < comparar.IdPlan.Length; i++)
                {
                    SeccionCotizacionIndDto cotizacion = cotizacionesDto.GenereCotizacion(
                        new GeneraCotizacionIndividual()
                        {
                            IdPlan = comparar.IdPlan[i],
                            Cliente = cotizacionInicial.Cliente,
                            CoberturasAdicionales = cotizacionInicial.IdBeneficiosAdicionales,
                            CatBeneficiosAdicionales = cotizacionInicial.IdCatalogosBeneficios,
                            ContadorPersonas = (cotizacionInicial.Dependientes?.Length ?? 0) + (cotizacionInicial.ConyugueEdad > 0 ? 1 : 0) + 1,
                            ConyugueEdad = cotizacionInicial.ConyugueEdad,
                            ConyugueFechaNacimiento = cotizacionInicial.ConyugueFechaNacimiento,
                            ConyugueGenero = cotizacionInicial.ConyugueGenero,
                            Dependientes = cotizacionInicial.Dependientes,
                            Estado = cotizacionInicial.EstadoCotizacion,
                            IdUsuario = cotizacionInicial.IdUsuario,
                            TitularEdad = cotizacionInicial.TitularEdad,
                            TitularGenero = cotizacionInicial.TitularGenero,
                            TitularMaternidad = cotizacionInicial.TitularMaternidad,
                            TitularNacimiento = cotizacionInicial.TitularNacimiento,
                            TitularBeneficio = cotizacionInicial.TitularBeneficio
                        }
                    );
                    SeccionCotizaciones cotizacionTmp = cotizacionesDto.ConsultaCotizacionId(cotizacion.IdCotizacion, false, true);
                    planesAdicionales.Add(cotizacionTmp);
                }

                // 3.- Consolidar Cotizaciones en cotizacionDto
                Log.Debug("Generando cotizaciones de planes adiconales.");
                cotizacionDto.Agencia = cotizacionInicial.Agencia;
                cotizacionDto.Agente = cotizacionInicial.Agente;
                cotizacionDto.Cliente = cotizacionInicial.Cliente;
                cotizacionDto.ConyugueEdad = cotizacionInicial.ConyugueEdad;
                cotizacionDto.Dependientes = cotizacionInicial.Dependientes;
                cotizacionDto.Direccion = cotizacionInicial.Direccion;
                cotizacionDto.FechaCotizacion = DateTime.Now;
                cotizacionDto.IdCotizacion = new List<int> { cotizacionInicial.IdCotizacion };
                planesAdicionales.ForEach(p => cotizacionDto.IdCotizacion.Add(p.IdCotizacion));
                cotizacionDto.IdUsuario = cotizacionInicial.IdUsuario;
                cotizacionDto.NombrePlan = new List<string> { cotizacionInicial.NombrePlan + " - " + cotizacionInicial.Region };
                planesAdicionales.ForEach(p => cotizacionDto.NombrePlan.Add(p.NombrePlan + " - " + p.Region));
                cotizacionDto.Telefono = cotizacionInicial.Telefono;
                cotizacionDto.TitularEdad = cotizacionInicial.TitularEdad;

                cotizacionDto.Caracteristicas = new List<SeccionCompararBloqueDto>();
                SeccionCompararBloqueDto seccion;
                cotizacionInicial.SeccionBloquesPlantillas.ForEach(s =>
                {
                    seccion = new SeccionCompararBloqueDto();
                    seccion.IdSeccion = s.IdSeccion;
                    seccion.Seccion = s.Seccion;
                    seccion.CompararCaracteristicas = new List<SeccionCompararBody>();
                    s.Plantillas.ForEach(p =>
                    {
                        SeccionCompararBody bodyComparacion = new SeccionCompararBody();
                        bodyComparacion.IdSeccion = p.IdSeccion;
                        bodyComparacion.IdPlantillaC = p.IdPlantillaC;
                        bodyComparacion.IdCaracteristica = p.IdCaracteristica;
                        bodyComparacion.Descripcion = p.Descripcion;
                        bodyComparacion.AplicaMaternidad = p.AplicaMaternidad;
                        bodyComparacion.AplicaNSolo = p.AplicaNSolo;
                        bodyComparacion.Valor = new List<string>();
                        bodyComparacion.Valor.Add(p.Valor.Trim().Length == 0 ? CompNoAplicaText : p.Valor);
                        seccion.CompararCaracteristicas.Add(bodyComparacion);
                    });
                    cotizacionDto.Caracteristicas.Add(seccion);
                });
                for (var i = 0; i < planesAdicionales.Count; i++)
                {
                    SeccionCotizaciones a = planesAdicionales.ToArray()[i];

                    // Si el plan adicional no contiene una seccion existente en la cotizacion base
                    // los valores de las caracteristicas se llenan con {CompNoAplicaText}
                    cotizacionDto.Caracteristicas.ForEach(c => {
                        if (a.SeccionBloquesPlantillas.Find(s => s.IdSeccion == c.IdSeccion) == null)
                        {
                            c.CompararCaracteristicas.ForEach(item => item.Valor.Add(CompNoAplicaText));
                        }
                    });

                    a.SeccionBloquesPlantillas.ForEach(s =>
                    {
                        SeccionCompararBloqueDto cSeccion = cotizacionDto.Caracteristicas.Find(c => c.IdSeccion == s.IdSeccion);
                        // Si la seccion del plan adicional no existe en la cotizacion base
                        // se agrega la seccion a la comparacion con valor de {CompNoAplicaText} por defecto
                        if (cSeccion == null)
                        {
                            seccion = new SeccionCompararBloqueDto();
                            seccion.IdSeccion = s.IdSeccion;
                            seccion.Seccion = s.Seccion;
                            seccion.CompararCaracteristicas = new List<SeccionCompararBody>();
                            s.Plantillas.ForEach(p =>
                            {
                                SeccionCompararBody bodyComparacion = new SeccionCompararBody();
                                bodyComparacion.IdSeccion = p.IdSeccion;
                                bodyComparacion.IdPlantillaC = p.IdPlantillaC;
                                bodyComparacion.IdCaracteristica = p.IdCaracteristica;
                                bodyComparacion.Descripcion = p.Descripcion;
                                bodyComparacion.AplicaMaternidad = p.AplicaMaternidad;
                                bodyComparacion.AplicaNSolo = p.AplicaNSolo;
                                bodyComparacion.Valor = new List<string>();
                                for (int j = 0; j <= i; j++)
                                {
                                    bodyComparacion.Valor.Add(CompNoAplicaText);
                                }
                                seccion.CompararCaracteristicas.Add(bodyComparacion);
                            });
                            cotizacionDto.Caracteristicas.Add(seccion);
                            cSeccion = seccion;
                        }

                        // Si la cotizacion base contiene una caracteristica que que no se encuentra en el plan adicional se agrega
                        // el valor por defecto
                        cSeccion.CompararCaracteristicas.ForEach(c => {
                            if (s.Plantillas.Find(p => p.IdPlantillaC == c.IdPlantillaC) == null)
                            {
                                c.Valor.Add(CompNoAplicaText);
                            }
                        });

                        s.Plantillas.ForEach(p => {
                            SeccionCompararBody caracteristica = cSeccion.CompararCaracteristicas.Find(
                                c => c.IdPlantillaC == p.IdPlantillaC);

                            // Si la cotizacion base no contiene una caracteristica presente en los planes adicionales se agrega
                            // la caracteristica y se coloca los valores por defecto
                            if (caracteristica == null)
                            {
                                caracteristica = new SeccionCompararBody();
                                caracteristica.IdSeccion = p.IdSeccion;
                                caracteristica.IdPlantillaC = p.IdPlantillaC;
                                caracteristica.IdCaracteristica = p.IdCaracteristica;
                                caracteristica.Descripcion = p.Descripcion;
                                caracteristica.AplicaMaternidad = p.AplicaMaternidad;
                                caracteristica.AplicaNSolo = p.AplicaNSolo;
                                caracteristica.Valor = new List<string>();
                                for (int j = 0; j <= i; j++)
                                {
                                    caracteristica.Valor.Add(CompNoAplicaText);
                                }
                                cSeccion.CompararCaracteristicas.Add(caracteristica);
                            }

                            if (p.IdCaracteristica == 0)
                                caracteristica.Valor.Add(CompNoAplicaText);
                            else
                                caracteristica.Valor.Add(p.Valor.Trim().Length == 0 ? CompNoAplicaText : p.Valor);
                        });
                    });
                }

                cotizacionDto.Totales = new List<CalculaTarifasResultado> { cotizacionInicial.TarifasResultado };
                planesAdicionales.ForEach(p => cotizacionDto.Totales.Add(p.TarifasResultado));

                cotizacionDto.Conf_Observaciones_Pdf = cotizacionInicial.Conf_Observaciones_Pdf;

                // 4.- Devolver Comparacion
                Log.Info("Genera comparacion individual con exito. ");
                return Ok(cotizacionDto);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = exp.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message + " | Stacktrace: " + ex.StackTrace });
            }
        }

        [HttpPost]
        [Route("api/CompararPlanesPool")]
        public IHttpActionResult CompararPlanesPool(CompararPlanes comparar)
        {
            string method = "CompararPlanesPool";
            SeccionCompararPoolDto cotizacionDto = new SeccionCompararPoolDto();
            try
            {
                //cotizacionDto = cotizacionesDto.CompararPlanesPool(comparar);

                // 0.- Validaciones
                if (comparar == null)
                {
                    string message = "Cuerpo de la peticion vacia";
                    Log.Error(method + ": " + message);
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = message });
                }
                else if (comparar.IdCotizacion <= 0)
                {
                    string message = "El valor de la cotizacion base no es valido";
                    Log.Error(method + ": " + message);
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = message });
                }
                else if ((comparar.IdPlan?.Length ?? 0) == 0)
                {
                    string message = "Debe ingresar los planes con los cuales desea hacer la comparacion";
                    Log.Error(method + ": " + message);
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = message });
                }

                // 1.- Consultar Cotizacion Inicial
                Log.Debug("Consultando cotizacion inicial.");
                SeccionCotizaciones cotizacionInicial = cotizacionesDto.ConsultaCotizacionId(comparar.IdCotizacion, true, true);

                // 2.- Generar Cotizaciones Planes a comparar
                Log.Debug("Generando cotizaciones de planes adicionales.");
                List<SeccionCotizacionPoolDto> planesAdicionales = new List<SeccionCotizacionPoolDto>();
                for (var i = 0; i < comparar.IdPlan.Length; i++)
                {
                    SeccionCotizacionPoolDto cotizacion = cotizacionesPoolDto.GeneraCotizacionPool(
                    new GeneraCotizacionPool() {
                        IdCotizacion = 0,
                        IdPlan = comparar.IdPlan[i],
                        Cliente = cotizacionInicial.Cliente,
                        Estado = cotizacionInicial.EstadoCotizacion,
                        IdUsuario = cotizacionInicial.IdUsuario,
                        Actividad = cotizacionInicial.Actividad,
                        CategoriaPools = new List<CotizacionCategoriaPool>(cotizacionInicial.CategoriasPools)
                    }, true);
                    planesAdicionales.Add(cotizacion);
                }

                // 3.- Consolidar Cotizaciones en cotizacionDto
                Log.Debug("Generando cotizaciones de planes adicionales.");
                cotizacionDto.Agencia = cotizacionInicial.Agencia;
                cotizacionDto.Actividad = cotizacionInicial.Actividad;
                cotizacionDto.Agente = cotizacionInicial.Agente;
                cotizacionDto.Cliente = cotizacionInicial.Cliente;
                cotizacionDto.Direccion = cotizacionInicial.Direccion;
                cotizacionDto.FechaCotizacion = DateTime.Now;
                cotizacionDto.IdCotizacion = new List<int> { cotizacionInicial.IdCotizacion };
                planesAdicionales.ForEach(p => cotizacionDto.IdCotizacion.Add(p.IdCotizacion));
                cotizacionDto.IdUsuario = cotizacionInicial.IdUsuario;
                cotizacionDto.NombrePlan = new List<string> { cotizacionInicial.NombrePlan + " - " + cotizacionInicial.Region};
                planesAdicionales.ForEach(p => cotizacionDto.NombrePlan.Add(p.NombrePlan + " - " + p.Region));
                cotizacionDto.Telefono = cotizacionInicial.Telefono;

                cotizacionDto.Caracteristicas = new List<SeccionCompararBloqueDto>();
                SeccionCompararBloqueDto seccion;
                cotizacionInicial.SeccionBloquesPlantillas.ForEach(s =>
                {
                    seccion = new SeccionCompararBloqueDto();
                    seccion.IdSeccion = s.IdSeccion;
                    seccion.Seccion = s.Seccion;
                    seccion.CompararCaracteristicas = new List<SeccionCompararBody>();
                    s.Plantillas.ForEach(p =>
                    {
                        SeccionCompararBody bodyComparacion = new SeccionCompararBody();
                        bodyComparacion.IdSeccion = p.IdSeccion;
                        bodyComparacion.IdPlantillaC = p.IdPlantillaC;
                        bodyComparacion.IdCaracteristica = p.IdCaracteristica;
                        bodyComparacion.Descripcion = p.Descripcion;
                        bodyComparacion.AplicaMaternidad = p.AplicaMaternidad;
                        bodyComparacion.AplicaNSolo = p.AplicaNSolo;
                        bodyComparacion.Valor = new List<string>();
                        bodyComparacion.Valor.Add(p.Valor);
                        seccion.CompararCaracteristicas.Add(bodyComparacion);
                    });
                    cotizacionDto.Caracteristicas.Add(seccion);
                });
                planesAdicionales.ForEach(a => a.SeccionBloquesPlantillas.ForEach(s =>
                    s.Plantillas.ForEach(p => cotizacionDto.Caracteristicas.ForEach(e =>
                    {
                        SeccionCompararBody caracteristica = e.CompararCaracteristicas.Find(
                            c => c.IdSeccion == p.IdSeccion
                                && c.IdPlantillaC == p.IdPlantillaC);
                        if (p.IdCaracteristica == 0 && caracteristica != null) caracteristica.Valor.Add("");
                        else if (caracteristica != null) caracteristica.Valor.Add(p.Valor);
                    }))));

                cotizacionDto.Totales = new List<CalculaTarifasResultado> { cotizacionInicial.TarifasResultado };
                planesAdicionales.ForEach(p => cotizacionDto.Totales.Add(p.TarifasResultado));

                cotizacionDto.Conf_Observaciones_Pdf = cotizacionInicial.Conf_Observaciones_Pdf;

                // 4.- Devolver Comparacion
                Log.Info("Genera comparacion pool con exito. ");
                return Ok(cotizacionDto);
            }
            catch (Npgsql.PostgresException exp)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = exp.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message + " | Stacktrace: " + ex.StackTrace });
            }

        }
    }
}
