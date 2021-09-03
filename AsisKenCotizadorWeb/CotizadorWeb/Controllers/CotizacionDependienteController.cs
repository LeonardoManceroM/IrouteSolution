using CotizadorWeb.Models;
using Data.Entidades;
using log4net;
using System;
using System.Net;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class CotizacionDependienteController : ApiController
    {
        private readonly CotizacionDependienteDto depADO = new CotizacionDependienteDto();
        private readonly ErrorGenerico datosSalida = new ErrorGenerico();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(depADO.ObtenerTodos());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        public IHttpActionResult Get(int idCotizacion)
        {
            try
            {
                return Ok(depADO.Obtener(idCotizacion));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [HttpPost]
        public IHttpActionResult Post(CotizacionDependienteDto dependitente)
        {
            try
            {
                if (depADO.Insertar(dependitente))
                {
                    datosSalida.Mensaje = "Ingresado con exito";
                }
                else
                {
                    datosSalida.Mensaje = "Error al ingresar";
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
        public IHttpActionResult Put(CotizacionDependienteDto dependitente)
        {
            try
            {
                if (depADO.Modificar(dependitente))
                {
                    datosSalida.Mensaje = "Ingresado con exito";
                }
                else
                {
                    datosSalida.Mensaje = "Error al ingresar";
                    return Content(HttpStatusCode.BadRequest, datosSalida);
                }
                return Ok(datosSalida);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
    }
}
