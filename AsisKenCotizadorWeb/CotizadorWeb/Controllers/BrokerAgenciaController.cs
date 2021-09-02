using CotizadorWeb.Models;
using Data.Entidades;
using System;
using System.Net;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class BrokerAgenciaController : ApiController
    {
        private readonly BrokerAgenciaDto agen = new BrokerAgenciaDto();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(agen.ObtenerTodos());
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
                return Ok(agen.ObtenerAgencia(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/ObtenerByEstado")]
        public IHttpActionResult ObtenerByEstado(bool idestado)
        {
            try
            {
                return Ok(agen.ObtenerByEstado(idestado));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [HttpPost]
        public IHttpActionResult Post(BrokerAgenciaDto agencia)
        {
            try
            {
                var id = agen.Insertar(agencia);

                if (id == -1)
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El correo ya se encuentra registrado" });
                else if (id == -2)
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El RUC ya se encuentra Registrado" });
                else if (id > 0)
                    return Ok(new Salida { Codigo = 1, Mensaje = "Ingreso con exito" });
                else
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al ingresar" });

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
           
        }
        [HttpPut]
        public IHttpActionResult Put(BrokerAgenciaDto agencia)
        {
            try
            {
                var id = agen.Modificar(agencia);

                if (id == -1)
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El correo ya se encuentra registrado" });
                //else if (id == -2)
                    //return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El RUC ya se encuentra Registrado" });
                else if (id > 0)
                    return Ok(new Salida { Codigo = 1, Mensaje = "modificado con exito" });
                else
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al modificar" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
        
    }
}
