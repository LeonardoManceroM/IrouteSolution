using CotizadorWeb.Models;
using Data.Entidades;
using log4net;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class CorreosArchivosController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly EnvioCorreoDto envioDao = new EnvioCorreoDto();

        [HttpPost]
        [Route("api/EnvioCotizacionAdjuntos")]
        public IHttpActionResult EnvioCotizacionAdjuntos(CorreoRequest body)
        {
            string DirectorioArchivo = ConfigurationManager.AppSettings["ruta"];
            try
            {
                var correo = new EnvioCorreo
                {
                    Asunto = body.Asunto,
                    Contenido = body.Contenido,
                    Destinatario = body.Destinatario,
                    Remitente = ConfigurationManager.AppSettings["CorreoRemitente"]
                };
                if ((body?.ArchivoBase64?.Trim() ?? "") != "")
                {
                    byte[] fileBytes = Convert.FromBase64String(body.ArchivoBase64);
                    string pathFile = HttpContext.Current.Server.MapPath(Path.Combine(DirectorioArchivo, ConfigurationManager.AppSettings["patron_incial"] + Convert.ToString(DateTime.Now.Year) + body.NombreArchivo + "." + body.ExtensionArchivo));
                    File.WriteAllBytes(pathFile, fileBytes);
                    if (envioDao.EnvioCotizacion(pathFile, correo))
                        return Ok(new ErrorGenerico { Mensaje = "Correo Enviado" });
                    else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Correo no Enviado" });
                }
                return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Correo no Enviado porque no hay archivos Adjuntos" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/EnvioCorreo")]
        public IHttpActionResult EnvioCotizacion(EnvioCorreo correo)
        {
            try
            {
               bool send = envioDao.EnvioCotizacion(correo);
               if(send)
                return Ok(new ErrorGenerico { Mensaje="Correo Enviado" });
               else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Correo no Enviado" });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
    }
}
