using CotizadorWeb.Models;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class RolController : ApiController
    {
        private readonly RolDto rolADO = new RolDto();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(rolADO.ObtenerTodos());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(rolADO.Obtener(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = ex.Message });
            }
           
        }
        [HttpPost]
        public IHttpActionResult Post(RolDto rol)
        {
            Salida datosSalida = new Salida { Codigo = 1, Mensaje = "Ingreso c con exito" };
            rolADO.Insertar(rol);
            return Ok(datosSalida);
        }
        [HttpPut]
        public IHttpActionResult Put(RolDto rol)
        {
            Salida datosSalida = new Salida { Codigo = 1, Mensaje = "Ingreso c con exito" };
            rolADO.Modificar(rol);
            return Ok(datosSalida);
        }
    }
}
