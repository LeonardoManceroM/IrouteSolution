using CotizadorWeb.Models;
using Data.Acceso;
using Data.Entidades;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace CotizadorWeb.Controllers
{
    public class UsuarioController : ApiController
    {
        public readonly UsuarioDto usr = new UsuarioDto();
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(usr.ObtenerTodos());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError,new ErrorGenerico { Mensaje=ex.Message});
            }
            
        }
        
        [HttpGet]
        //https://localhost:44343/api/Usuario?idUsuario=1
        public IHttpActionResult GetUsuario(int idUsuario)
        {
            try
            {
                return Ok(usr.ObtenerUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
        
        [HttpGet]
        [Route("api/RecuperarContrasena")]
        public IHttpActionResult RecuperarContrasena(string mail)
        {
            try
            {
                if (usr.RecuperarContrasenia(mail))
                    return Ok(new ErrorGenerico {Mensaje = "mail Correcto" });
                else
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "mail Invalido" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }

        [HttpPost]
        [Route("api/ValidaIngreso")]
        public IHttpActionResult ValidaIngreso(UsuarioDto user)
        {
            try
            {
                var regex = new Regex(@"[a-zA-z0-9]");
                var valido = regex.IsMatch(user.Identificacion);
                if (valido)
                {
                    var usuario = usr.ValidaIngreso(user.Identificacion, user.Clave);
                    if (usuario.IdUsuario > 0)
                    {
                        if (!usuario.EstadoAgencia)
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Atencion! Su Broker asociado se encuentra Inactivo." });
                        else if (usuario.IdEstado == 1)
                            return Ok(usuario);
                        else if (usuario.IdEstado == 3)
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El Usuario se encuentra Denegado." });
                        else
                            return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El Usuario no se encuentra activo." });
                    }
                    else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Usuario o Contraseña incorrecta" });
                }
                else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Formato Inválido" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        
        [HttpGet]
        [Route("api/ValidaMail")]
        public IHttpActionResult ValidaMail(string mail)
        {
            try
            {
                return Ok(usr.ValidaMail(mail));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        
        [HttpGet]
        [Route("api/GetMail")]
        public IHttpActionResult GetMail(string mail)
        {
            try
            {
                return Ok(usr.ObtenerMail(mail));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        
        [HttpGet]
        [Route("api/GetUsarioByEstado")]
        public IHttpActionResult GetUsarioByEstado(int estado)
        {
            try
            {
                return Ok(usr.ObtenerUsuarioByEstado(estado));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        
        [HttpGet]
        [Route("api/GetUsarioByBroker")]
        public IHttpActionResult GetUsarioByBroker(int broker)
        {
            try
            {
                return Ok(usr.ObtenerUsuarioByBroker(broker));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
            
        }
        //para valdar a un usuario si es permitido el aprobarlo o no
        [HttpGet]
        [Route("api/UsuarioValido")]
        public IHttpActionResult UsuarioValido(string identificacion)
        {
            try
            {
                return Ok(usr.UsuarioValido(identificacion));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [HttpPost]
        public IHttpActionResult Post(UsuarioDto usuario)
        {
            Salida datosSalida = new Salida();
            try
            {
                if (usuario.FechaNacimineto != null)
                {
                    int insertado = usr.InsertarUsuario(usuario);
                    if (insertado == -2)
                    {
                       // datosSalida.Mensaje = "La Identificación ya se encuentra Registrada";
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "La Identificación ya se encuentra Registrada" });
                    }
                    else if (insertado == -1)
                    {
                        //datosSalida.Mensaje = "El correo ya se encuentra registrado";
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El correo ya se encuentra registrado" });
                    }
                    else if (insertado == -3)
                    {
                        //datosSalida.Mensaje = "El teléfono ya se encuentra registrado";
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "El teléfono ya se encuentra registrado" });
                    }
                    else
                    {
                        datosSalida.Codigo = 1;
                        datosSalida.Mensaje = "Insertado Correctamente";
                    }
                }
                else
                {
                    //datosSalida.Mensaje = "No se ha ingresado fecha";
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "No se ha ingresado fecha" });
                }
                return Ok(datosSalida);

            }catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [HttpPut]
        public IHttpActionResult Put(UsuarioDto usuario)
        {
            ErrorGenerico datosSalida = new ErrorGenerico();
            Salida exito = new Salida();
            try
            {
                if (usuario.FechaNacimineto != null)
                {
                    int modificado = usr.ModificarUsuario(usuario);
                    if (modificado == -1)
                    {
                        datosSalida.Mensaje = "El Telefono ya se encuentra registrado";
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = datosSalida.Mensaje });
                    }
                    else
                   if (modificado == 0)
                    {
                        datosSalida.Mensaje = "El correo ya se encuentra registrado";
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = datosSalida.Mensaje });
                    }
                    else
                    {
                        exito.Codigo = 1;
                        exito.Mensaje = "Actualizado Correctamente";

                    }
                }
                else
                {
                    datosSalida.Mensaje = "No se ha ingresado fecha";
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = datosSalida.Mensaje });
                }
                return Ok(exito);
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        //para Actualiza el estado del usuario
        [Route("api/ActualizaEstado")]
        [HttpPut]

        public IHttpActionResult ActualizaEstado(UsuarioDto usuario)
        {
            Salida exito = new Salida();
            try
            {
                if(usr.ModificarEstado(usuario.IdUsuario,usuario.IdEstado, usuario.ObservacionEstado))
                {
                    exito.Mensaje = "Actualizado con éxito";
                    exito.Codigo = 1;
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al Actualizar" });
                }
                return Ok(exito);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [Route("api/ActualizaClave")]
        [HttpPut]
        public IHttpActionResult ActualizaClave(UsuarioContraseniaDto usu)
        {
            Salida exito = new Salida();

            try
            {
                UsuarioDto usuario = usr.ObtenerUsuario(usu.IdUsuario);
                if (usuario.Clave.Equals(usu.ClaveActual))
                {
                    usuario.Clave = usu.ClaveNueva;
                    bool modificado = usr.ActualizarContrasenia(usu.IdUsuario, usu.ClaveNueva);
                    if (modificado)
                    {
                        exito.Mensaje = "Actualizado Correctamente";
                        exito.Codigo = 1;
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al Actualizar" });
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Clave actual no coincide" });
                }
                
                return Ok(exito);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
		
		[Route("api/AprobacionUsuario")]
        [HttpPost]
        public IHttpActionResult AprobacionUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                if (usr.ModificarEstado(usuarioDto.IdUsuario, 1, "aprobado"))//el idEstado se le setea en 1 porque debe estar activo
                {
                    UsuarioDao usuarioDao = new UsuarioDao();
                    if (usuarioDao.EnvioMailUsuarioRemitente(new Usuario
                                                                {
                                                                    Identificacion = usuarioDto.Identificacion,
                                                                    Correo = usuarioDto.Correo
                                                                }) == 1)
                        return Ok(new ErrorGenerico { Mensaje = "usuario Aprobado" });
                    else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al envio de mail, pero el usuario fue aprobado" });

                }
                else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al Aprobar Usuario" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
        [Route("api/DenegarUsuario")]
        [HttpPost]
        public IHttpActionResult DenegarUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                if (usr.ModificarEstado(usuarioDto.IdUsuario, 3, usuarioDto.ObservacionEstado))//el idEstado se le setea en 3 porque debe estar denegado
                {
                    UsuarioDao usuarioDao = new UsuarioDao();
                    if (usuarioDao.EnvioMailUsuarioDenegado(new Usuario
                    {
                        Identificacion = usuarioDto.Identificacion,
                        Correo = usuarioDto.Correo,
                        ObservacionEstado=usuarioDto.ObservacionEstado
                    }) == 1)
                        return Ok(new ErrorGenerico { Mensaje = "Usuario Denegado" });
                    else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error en envio de mail, sin embargo el usuario fue denegado" });

                }
                else return Content(HttpStatusCode.BadRequest, new ErrorGenerico { Mensaje = "Error al Denegar Usuario" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ErrorGenerico { Mensaje = ex.Message });
            }
        }
    }
}
