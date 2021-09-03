using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class UsuarioDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private readonly UsuarioDao usuarioDao = new UsuarioDao();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public int IdUsuario { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        //public int IdTipo { get; set; }//ojo
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public int IdBroker { get; set; }
        public string Telefono { get; set; }
        public char Genero { get; set; }//M Hombre F mujer
        public DateTime FechaNacimineto { get; set; }
        public int IdEstado { get; set; }
        public int IdRol { get; set; }
        public string ObservacionEstado { get; set; }//el motivo en caso de que sea desaprobado
        public string DescripcionEstado { get; set; }
        public string NombreAgencia { get; set; }
        public bool EstadoAgencia { get; set; }
        public int IdProvincia { get; set; }
        public string Provincia { get; set; }
        public string DireccionAgencia { get; set; }

        public List<UsuarioDto> ObtenerTodos()
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            EstadoDto estado = new EstadoDto();
            BrokerAgenciaDto agencia = new BrokerAgenciaDto();
            try
            {
                if (!_onLine)
                {
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983,1,13),
                        Genero='M',
                        IdBroker=1,
                        Identificacion="0922749692",
                        IdEstado=1,
                        IdRol=1,
                        //IdTipo=1,
                        IdUsuario=1,
                        Nombres="Jorge",
                        ObservacionEstado="",
                        Telefono="0996179219",
                        TipoIdentificacion="CED",
                        DescripcionEstado=estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia=agencia.ObtenerAgencia(1).Broker
                    }) ;
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                }
                else
                {
                    usuarioDao.ObtenerTodos().ForEach(x =>
                    {
                        usuarios.Add(new UsuarioDto
                        {
                            Apellidos = x.Apellidos,
                            Clave = x.Clave,
                            Correo = x.Correo,
                            DescripcionEstado = x.DescripcionEstado,
                            Direccion = x.Direccion,
                            FechaNacimineto = x.FechaNacimineto,
                            Genero = x.Genero,
                            IdBroker = x.IdBroker,
                            Identificacion = x.Identificacion,
                            IdEstado = x.IdEstado,
                            IdRol = x.IdRol,
                            //IdTipo = x.IdTipo,
                            IdUsuario = x.IdUsuario,
                            Nombres = x.Nombres,
                            ObservacionEstado = x.ObservacionEstado,
                            Telefono = x.Telefono,
                            TipoIdentificacion = x.TipoIdentificacion,
                            NombreAgencia=x.NombreAgencia,
                            DireccionAgencia=x.DireccionAgencia
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;

            }
            return usuarios;
        }
        public UsuarioDto ObtenerUsuario(int idUsuario)
        {
            UsuarioDto usuario = new UsuarioDto();
            EstadoDto estado = new EstadoDto();
            BrokerAgenciaDto agencia = new BrokerAgenciaDto();
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuario = usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                }
                else
                {
                    var usuarioBD = usuarioDao.ObtenerById(idUsuario);
                    if (usuarioBD != null)
                    {
                        usuario.IdUsuario = usuarioBD.IdUsuario;
                        usuario.Apellidos = usuarioBD.Apellidos;
                        usuario.Clave = usuarioBD.Clave;
                        usuario.Correo = usuarioBD.Correo;
                        usuario.DescripcionEstado = usuarioBD.DescripcionEstado;
                        usuario.Direccion = usuarioBD.Direccion;
                        usuario.FechaNacimineto = usuarioBD.FechaNacimineto;
                        usuario.Genero = usuarioBD.Genero;
                        usuario.IdBroker = usuarioBD.IdBroker;
                        usuario.Identificacion = usuarioBD.Identificacion;
                        usuario.IdEstado = usuarioBD.IdEstado;
                        usuario.IdRol = usuarioBD.IdRol;
                        //usuario.IdTipo = usuarioBD.IdTipo;
                        usuario.NombreAgencia = usuarioBD.NombreAgencia;
                        usuario.Nombres = usuarioBD.Nombres;
                        usuario.ObservacionEstado = usuarioBD.ObservacionEstado;
                        usuario.Telefono = usuarioBD.Telefono;
                        usuario.TipoIdentificacion = usuarioBD.TipoIdentificacion;
                        usuario.DireccionAgencia = usuarioBD.DireccionAgencia;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return usuario;
        }
        public UsuarioDto ValidaIngreso(string identificacion, string pass)
        {
            UsuarioDto usuario = new UsuarioDto();
            EstadoDto estado = new EstadoDto();
            BrokerAgenciaDto agencia = new BrokerAgenciaDto();
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuario = usuarios.FirstOrDefault(x => x.Identificacion.Equals(identificacion) && x.Clave.Equals(pass));
                    //valida = usuario.Identificacion == identificacion && usuario.Clave == pass;
                }
                else
                {
                    var usuarioBd = usuarioDao.ValidaUsuarioIngreso(identificacion, pass);
                        //usuarioDao.ObtenerTodos().FirstOrDefault(x=>x.Identificacion.Equals(identificacion) && x.Clave.Equals(pass));
                    if (usuarioBd!=null)
                    {
                        usuario.IdUsuario = usuarioBd.IdUsuario;
                        usuario.Apellidos = usuarioBd.Apellidos;
                        usuario.Clave = usuarioBd.Clave;
                        usuario.Correo = usuarioBd.Correo;
                        usuario.DescripcionEstado = usuarioBd.DescripcionEstado;
                        usuario.Direccion = usuarioBd.Direccion;
                        usuario.FechaNacimineto = usuarioBd.FechaNacimineto;
                        usuario.Genero = usuarioBd.Genero;
                        usuario.IdBroker = usuarioBd.IdBroker;
                        usuario.Identificacion = usuarioBd.Identificacion;
                        usuario.IdEstado = usuarioBd.IdEstado;
                        usuario.IdRol = usuarioBd.IdRol;
                        //usuario.IdTipo = usuarioBd.IdTipo;
                        usuario.NombreAgencia = usuarioBd.NombreAgencia;
                        usuario.Nombres = usuarioBd.Nombres;
                        usuario.ObservacionEstado = usuarioBd.ObservacionEstado;
                        usuario.Telefono = usuarioBd.Telefono;
                        usuario.TipoIdentificacion = usuarioBd.TipoIdentificacion;
                        usuario.EstadoAgencia = usuarioBd.EstadoAgencia;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            usuario.Clave = "";
            return usuario;
        }
        public bool ValidaMail(string mail)
        {
            bool valida = false;
            UsuarioDto usuario = new UsuarioDto();
            EstadoDto estado = new EstadoDto();
            BrokerAgenciaDto agencia = new BrokerAgenciaDto();
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuario = usuarios.FirstOrDefault(x => x.Correo == mail);
                    valida = usuario.Correo == mail;
                }
                else
                {
                    var usuarioBd= usuarioDao.ObtenerTodos().FirstOrDefault(x => x.Correo.Equals(mail));
                    if (usuarioBd!=null)
                        valida = usuarioBd.Correo == mail;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return valida;
        }
        public bool RecuperarContrasenia(string mail)
        {
            bool exitoso = false;
            string clave = "";
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED"
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED"
                    });
                    clave = usuarios.FirstOrDefault(x => x.Correo.Equals(mail)).Clave;
                    //envio de correo con la clave
                    exitoso = true;
                }
                else
                {
                    var usu = usuarioDao.ObtenerTodos().FirstOrDefault(x => x.Correo.Equals(mail));
                    if (usu != null)
                    {
                        clave = usu.Clave;
                        usuarioDao.EnvioMailUsuarioContrasenia(usu);
                        exitoso = true;
                        //envio de correo
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return exitoso;
        }
        public bool UsuarioValido(string identificacion)
        {
            bool valido = false;
            UsuarioDto usuario = new UsuarioDto();
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED"
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED"
                    });
                    valido = !usuarios.Exists(x => x.Identificacion.Equals(identificacion));
                }
                else
                    valido = !usuarioDao.ObtenerTodos().Exists(x => x.Identificacion.Equals(identificacion));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return valido;
        }
        public UsuarioDto ObtenerMail(string email)
        {
            UsuarioDto usuario = new UsuarioDto();
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED"
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED"
                    });
                    usuario = usuarios.FirstOrDefault(x => x.Correo.Equals(email));
                }
                else
                {
                    var usuarioBd = usuario.usuarioDao.ObtenerTodos().FirstOrDefault(x => x.Correo.Equals(email));
                    if (usuarioBd!=null)
                    {
                        usuario.IdUsuario = usuarioBd.IdUsuario;
                        usuario.Apellidos = usuarioBd.Apellidos;
                        usuario.Clave = usuarioBd.Clave;
                        usuario.Correo = usuarioBd.Correo;
                        usuario.DescripcionEstado = usuarioBd.DescripcionEstado;
                        usuario.Direccion = usuarioBd.Direccion;
                        usuario.FechaNacimineto = usuarioBd.FechaNacimineto;
                        usuario.Genero = usuarioBd.Genero;
                        usuario.IdBroker = usuarioBd.IdBroker;
                        usuario.Identificacion = usuarioBd.Identificacion;
                        usuario.IdEstado = usuarioBd.IdEstado;
                        usuario.IdRol = usuarioBd.IdRol;
                        //usuario.IdTipo = usuarioBd.IdTipo;
                        usuario.NombreAgencia = usuarioBd.NombreAgencia;
                        usuario.Nombres = usuarioBd.Nombres;
                        usuario.ObservacionEstado = usuarioBd.ObservacionEstado;
                        usuario.Telefono = usuarioBd.Telefono;
                        usuario.TipoIdentificacion = usuarioBd.TipoIdentificacion;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return usuario;
        }

        public List<UsuarioDto> ObtenerUsuarioByEstado(int idEstado)
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
           
            try
            {
                if (!_onLine)
                {
                    EstadoDto estado = new EstadoDto();
                    BrokerAgenciaDto agencia = new BrokerAgenciaDto();
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                }
                else
                {
                    var usuariosBd = usuarioDao.ObtenerTodos().FindAll(x => x.IdEstado.Equals(idEstado));
                    if (usuariosBd != null)
                        usuariosBd.ForEach(x =>
                        {
                            usuarios.Add(new UsuarioDto
                            {
                                Apellidos = x.Apellidos,
                                Clave = x.Clave,
                                Correo = x.Correo,
                                DescripcionEstado = x.DescripcionEstado,
                                Direccion = x.Direccion,
                                FechaNacimineto = x.FechaNacimineto,
                                Genero = x.Genero,
                                IdBroker = x.IdBroker,
                                Identificacion = x.Identificacion,
                                IdEstado = x.IdEstado,
                                IdRol = x.IdRol,
                                //IdTipo = x.IdTipo,
                                IdUsuario = x.IdUsuario,
                                NombreAgencia = x.NombreAgencia,
                                Nombres = x.Nombres,
                                ObservacionEstado = x.ObservacionEstado,
                                Telefono = x.Telefono,
                                TipoIdentificacion = x.TipoIdentificacion,
                                DireccionAgencia = x.DireccionAgencia
                            });
                        });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return usuarios;
        }
        public List<UsuarioDto> ObtenerUsuarioByBroker(int broker)
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            EstadoDto estado = new EstadoDto();
            BrokerAgenciaDto agencia = new BrokerAgenciaDto();
            try
            {
                if (!_onLine)
                {
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Uzca",
                        Clave = "123",
                        Correo = "jorge.uzca@iroute.com.ec",
                        Direccion = "sauces7",
                        FechaNacimineto = new DateTime(1983, 1, 13),
                        Genero = 'M',
                        IdBroker = 1,
                        Identificacion = "0922749692",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Jorge",
                        ObservacionEstado = "",
                        Telefono = "0996179219",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                    usuarios.Add(new UsuarioDto
                    {
                        Apellidos = "Guano",
                        Clave = "123",
                        Correo = "johanna.guano@iroute.com.ec",
                        Direccion = "suburbio",
                        FechaNacimineto = new DateTime(1991, 4, 15),
                        Genero = 'F',
                        IdBroker = 1,
                        Identificacion = "0922749632",
                        IdEstado = 1,
                        IdRol = 1,
                        //IdTipo = 1,
                        IdUsuario = 1,
                        Nombres = "Johanna",
                        ObservacionEstado = "",
                        Telefono = "0996179325",
                        TipoIdentificacion = "CED",
                        DescripcionEstado = estado.Obtener(1).EstadoDescripcion,
                        NombreAgencia = agencia.ObtenerAgencia(1).Broker
                    });
                }
                else
                {
                    var usuariosBd = usuarioDao.ObtenerTodos().FindAll(x => x.IdBroker.Equals(broker));
                    if (usuariosBd != null)
                        usuariosBd.ForEach(x =>
                        {
                            usuarios.Add(new UsuarioDto
                            {
                                Apellidos = x.Apellidos,
                                Clave = x.Clave,
                                Correo = x.Correo,
                                DescripcionEstado = x.DescripcionEstado,
                                Direccion = x.Direccion,
                                FechaNacimineto = x.FechaNacimineto,
                                Genero = x.Genero,
                                IdBroker = x.IdBroker,
                                Identificacion = x.Identificacion,
                                IdEstado = x.IdEstado,
                                IdRol = x.IdRol,
                                //IdTipo = x.IdTipo,
                                IdUsuario = x.IdUsuario,
                                NombreAgencia = x.NombreAgencia,
                                Nombres = x.Nombres,
                                ObservacionEstado = x.ObservacionEstado,
                                Telefono = x.Telefono,
                                TipoIdentificacion = x.TipoIdentificacion,
                                DireccionAgencia = x.DireccionAgencia
                            });
                        });
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return usuarios;
        }

        public int InsertarUsuario(UsuarioDto usuario)//1 se inserto ok //0 correo repetido //-1 identificacion
        {
            int insertado = 1;
            try 
            { 
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    if (usuarios.Exists(x => x.Correo == usuario.Correo))
                        insertado = 0;
                    else if (usuarios.Exists(x => x.Identificacion == usuario.Identificacion))
                        insertado = -1;
                    else
                        usuarios.Add(usuario);
                }
                else
                {
                    var usuariosBd = usuarioDao.ObtenerTodos();
                    if (usuariosBd.Exists(x => x.Correo == usuario.Correo && x.IdEstado != 3))
                        insertado = -1;
                    else if (usuariosBd.Exists(x => x.Identificacion == usuario.Identificacion && x.IdEstado != 3))
                        insertado = -2;
                    else if (usuariosBd.Exists(x => x.Telefono == usuario.Telefono && x.IdEstado != 3))
                        insertado = -3;
                    else
                    {
                        var agenciaDao = new AgenciaDao();
                        var usuarioBd = new Usuario
                        {
                            Apellidos = usuario.Apellidos,
                            Clave = usuario.Clave,
                            Correo = usuario.Correo,
                            DescripcionEstado = usuario.DescripcionEstado,
                            Direccion = usuario.Direccion,
                            FechaNacimineto = usuario.FechaNacimineto,
                            Genero = usuario.Genero,
                            IdBroker = usuario.IdBroker,
                            Identificacion = usuario.Identificacion,
                            IdEstado = usuario.IdEstado,
                            IdRol = usuario.IdRol,
                            IdUsuario = usuario.IdUsuario,
                            NombreAgencia = agenciaDao.ObtenerById(usuario.IdBroker).Broker,//usuario.NombreAgencia,
                            Nombres = usuario.Nombres,
                            ObservacionEstado = usuario.ObservacionEstado,
                            Telefono = usuario.Telefono,
                            TipoIdentificacion = usuario.TipoIdentificacion,
                            IdProvincia = usuario.IdProvincia,
                            Provincia = usuario.Provincia
                        };

                        insertado = usuarioDao.Insertar(usuarioBd);
                        usuarioDao.EnvioMail(usuarioBd);
                        usuarioDao.EnvioMailUsuarioPendiente(usuarioBd);
                        //usuarioDao.EnvioMailUsuarioRemitente(usuarioBd);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return insertado;
        }
        public int ModificarUsuario(UsuarioDto usuario)
        {
            int modificado = 1;
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    if (usuarios.Exists(x => x.Correo == usuario.Correo))
                        modificado = 0;
                    else if (usuarios.Exists(x => x.Identificacion == usuario.Identificacion))
                        modificado = -1;
                    else
                        usuarios.Add(usuario);
                }
                else
                {
                    var usuariosBd = usuarioDao.ObtenerTodos();
                    if (usuariosBd.Exists(x => x.Correo == usuario.Correo && x.IdUsuario != usuario.IdUsuario))
                    {
                        modificado = 0;
                    }
                    else if (usuariosBd.Exists(x => x.Telefono == usuario.Telefono && x.IdUsuario != usuario.IdUsuario))
                        modificado = -1;
                    else
                    {
                        usuarioDao.Modificar(new Usuario
                        {
                            Apellidos = usuario.Apellidos,
                            Clave = usuario.Clave,
                            Correo = usuario.Correo,
                            DescripcionEstado = usuario.DescripcionEstado,
                            Direccion = usuario.Direccion,
                            FechaNacimineto = usuario.FechaNacimineto,
                            Genero = usuario.Genero,
                            IdBroker = usuario.IdBroker,
                            Identificacion = usuario.Identificacion,
                            IdEstado = usuario.IdEstado,
                            IdRol = usuario.IdRol,
                            //IdTipo = usuario.IdTipo,
                            IdUsuario = usuario.IdUsuario,
                            NombreAgencia = usuario.NombreAgencia,
                            Nombres = usuario.Nombres,
                            ObservacionEstado = usuario.ObservacionEstado,
                            Telefono = usuario.Telefono,
                            TipoIdentificacion = usuario.TipoIdentificacion,
                            IdProvincia = usuario.IdProvincia,
                            Provincia = usuario.Provincia
                        });
                        modificado = usuario.IdUsuario;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modificado;
        }

        //Aprobacion de usuarios
        //cuando es denegado se debe ingresar una observacion obligatoria
        public bool ModificarEstado(int idUsuario, int idEstado, string observacion)
        {
            bool modificado = false;
            
            try
            {
                if (!_onLine)
                {
                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    UsuarioDto usuario = new UsuarioDto();
                    usuario = usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                    usuario.IdEstado = idEstado;
                    modificado = true;
                }
                else
                {
                    usuarioDao.ModificarEstado(new Usuario { 
                        IdUsuario=idUsuario,
                        IdEstado=idEstado,
                        ObservacionEstado=observacion
                    });
                    modificado = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return modificado;
        }
        public bool ActualizarContrasenia(int idUsuario, string clave)
        {
            bool actualizado;
            try
            {
                actualizado = usuarioDao.ActualizaClave(idUsuario, clave);
                actualizado = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return actualizado;
        }
    }

}