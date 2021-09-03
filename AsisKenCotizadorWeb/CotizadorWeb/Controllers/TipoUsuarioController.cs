using CotizadorWeb.Models;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class TipoUsuarioController : ApiController
    {
        private readonly TipoUsuarioDto tipoUsr = new TipoUsuarioDto();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(tipoUsr.ObtenerTodos());
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
                return Ok(tipoUsr.ObtenerTipos(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        //[HttpPost]
        //public IHttpActionResult Post(TipoUsuarioDto tipo)
        //{
        //    Salida datosSalida = new Salida { Codigo = 1, Mensaje = "Ingreso c con exito" };
        //    tipoUsr.InsertarTipo(tipo);
        //    return Ok(datosSalida);
        //}
        //[HttpPut]
        //public IHttpActionResult Put(TipoUsuarioDto tipo)
        //{
        //    Salida datosSalida = new Salida { Codigo = 1, Mensaje = "Ingreso c con exito" };
        //    tipoUsr.ModificarTipo(tipo);
        //    return Ok(datosSalida);
        //}
        //[HttpDelete]
        //public IHttpActionResult Delete(int idtipo)
        //{
        //    Salida datosSalida = new Salida { Codigo = 1, Mensaje = "Ingreso c con exito" };
        //    tipoUsr.EliminarTipo(idtipo);
        //    return Ok(datosSalida);
        //}
    }
}
