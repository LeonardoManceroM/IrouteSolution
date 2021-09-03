using CotizadorWeb.Models;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class MenuController : ApiController
    {
        private readonly MenuDto menuADO = new MenuDto();
        [HttpGet]
        //[Route("api/ObtenerByRol")]
        public IHttpActionResult ObtenerByRol(int idRol)
        {
            try
            {
                return Ok(menuADO.Obtener(idRol));
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        
    }
}
