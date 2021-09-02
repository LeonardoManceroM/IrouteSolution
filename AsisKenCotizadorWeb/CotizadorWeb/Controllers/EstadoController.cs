using CotizadorWeb.Models;
using Data.Entidades;
using System;
using System.Net;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class EstadoController : ApiController
    {
        private readonly EstadoDto est = new EstadoDto();
        //Salida datosSalida = new Salida();
        
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(est.ObtenerTodos());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
           
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(est.Obtener(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
        [HttpPost]
        public IHttpActionResult Post(EstadoDto estado)
        {
            try
            {
                if (est.Insertar(estado))
                {
                    return Ok(new ErrorGenerico { Mensaje = "Ingresado Con exito" });
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Problemas al ingresar" });
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
        [HttpPut]
        public IHttpActionResult Put(EstadoDto estado)
        {
            try
            {
                ErrorGenerico datosSalida ;
                if (est.Modificar(estado))
                {
                    datosSalida = new ErrorGenerico { Mensaje = "Ingreso  con exito" };
                    return Ok(datosSalida); 
                }
                else 
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al ingresar" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
    }
}
