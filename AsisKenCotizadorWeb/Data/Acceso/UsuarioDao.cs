using Data.Conexion;
using Data.Entidades;
using log4net;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;

namespace Data.Acceso
{
    public class UsuarioDao
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<Usuario> ObtenerTodos()
        {
            var usuario = new List<Usuario>();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_usuario";
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            usuario.Add(Usuario.ConsultaUsuarioFromDataRecord(reader));
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
        public Usuario ObtenerById(int idUsuario)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_usuario";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", idUsuario));
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            usuario = Usuario.ConsultaUsuarioFromDataRecord(reader);
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
        public int Insertar(Usuario usuario)
        {
            int guardado = 0;
            if (string.IsNullOrEmpty(usuario.ObservacionEstado))
                usuario.ObservacionEstado = "";
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_ing_usuario";
                    //sql.Comando.Parameters.Add(new NpgsqlParameter("var_tipousuario", usuario.IdTipo));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_tipoidentificacion", usuario.TipoIdentificacion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_identificacion", usuario.Identificacion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_apellidos", usuario.Apellidos));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_nombre", usuario.Nombres));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_correo", usuario.Correo));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_clave", usuario.Clave));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_direccion", usuario.Direccion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idbroker", usuario.IdBroker));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_telefono", usuario.Telefono));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_genero", usuario.Genero.ToString()));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_fechanacimiento", usuario.FechaNacimineto));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idestado", usuario.IdEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idrol", usuario.IdRol));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_observacionestado", string.IsNullOrEmpty(usuario.ObservacionEstado) ? "" : usuario.ObservacionEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idprovincia", usuario.IdProvincia));
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                        {
                            var dr = reader;
                            guardado = int.Parse(dr[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return guardado;
        }
        public int Modificar(Usuario usuario)
        {
            int modificado = 0;
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_usuario";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", usuario.IdUsuario));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_tipoidentificacion", usuario.TipoIdentificacion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_identificacion", usuario.Identificacion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_apellidos", usuario.Apellidos));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_nombre", usuario.Nombres));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_correo", usuario.Correo));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_clave", usuario.Clave));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idbroker", usuario.IdBroker));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_telefono", usuario.Telefono));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_genero", usuario.Genero));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_fechanacimiento", usuario.FechaNacimineto));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idestado", usuario.IdEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idrol", usuario.IdRol));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_observacionestado", string.IsNullOrEmpty(usuario.ObservacionEstado) ? "" : usuario.ObservacionEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_direccion", string.IsNullOrEmpty(usuario.Direccion) ? "" : usuario.Direccion));
                    //se tiene que añadir tiposuario al sp de insersion
                    //sql.Comando.Parameters.Add(new NpgsqlParameter("var_tipousuario", usuario.IdTipo));
                    sql.EjecutaQuery();
                    modificado = usuario.IdUsuario;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return modificado;
        }
        public int ModificarEstado(Usuario usuario)
        {
            int modificado = 0;
            try
            {
                using (ConSql sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_usuarioestado";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", usuario.IdUsuario));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idestado", usuario.IdEstado));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_observacion", usuario.ObservacionEstado));
                    sql.EjecutaQuery();
                    modificado = usuario.IdUsuario;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return modificado;
        }
        public bool ActualizaClave(int idUsuario, string clave)
        {
            bool actualizada = false;
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_mod_usuariocambioclave";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_idusuario", idUsuario));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_clave", DbType.String) { Value = clave });
                    sql.EjecutaQuery();
                    actualizada = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actualizada;
        }
        public Usuario ValidaUsuarioIngreso(string identificacion, string clave)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_usuarioValidaIngreso";
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_identificacion", identificacion));
                    sql.Comando.Parameters.Add(new NpgsqlParameter("var_clave", DbType.String) { Value = clave });
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            usuario = Usuario.ValidaUsuarioDR(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }
        public int EnvioMail(Usuario usuario)
        {
            int envio = 0;
            try
            {
                AgenciaDao agencia = new AgenciaDao();
                string genero = usuario.Genero.ToString().ToLower() == "m" ? "Masculino" : "Femenino";
                string nombreAgencia = usuario.NombreAgencia.ToLower() == "asisken" ? "Asisken" : "Broker";
                EnvioCorreoDao correo = new EnvioCorreoDao();
                string contenido = "<p> Se acaba de generar el ingreso de un usuario nuevo.<br/><br/>" +
                    "Dato de la cuenta:<br/>" +
                    "Identificación: " + usuario.Identificacion + "<br/>" +
                    "Tipo de usuario: " + nombreAgencia + "<br/>" +
                    "Nombres: " + usuario.Apellidos + " " + usuario.Nombres + "<br/>" +
                    "Email: " + usuario.Correo + "<br/>" +
                    "Broker: " + usuario.NombreAgencia + "<br/>" +
                    "Teléfono: " + usuario.Telefono + "<br/>" +
                    "Dirección: " + usuario.Direccion + "<br/>" +
                    "Genero: " + genero + "<br/>" +
                    "Fecha Nacimiento: " + usuario.FechaNacimineto.ToString("dd/MM/yyyy") + "<br/><br/>" +
                    "Active la cuenta dando click en el siguiente enlace" + "<br/>" +
                    ConfigurationManager.AppSettings["Aprobacion"] + usuario.Identificacion +
                    "</p>";
                if (correo.EnvioCorreo(new EnvioCorreo
                {
                    Asunto = ConfigurationManager.AppSettings["AsuntoUsuario"] + " " + usuario.Identificacion,
                    Contenido = contenido,
                    Destinatario = ConfigurationManager.AppSettings["CorreoDestinatario"],
                    Remitente = ConfigurationManager.AppSettings["CorreoRemitente"]
                }))
                    envio = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
        public int EnvioMailUsuarioRemitente(Usuario usuario)
        {
            int envio = 0;
            try
            {//el link del login
                AgenciaDao agencia = new AgenciaDao();
                EnvioCorreoDao correo = new EnvioCorreoDao();
                string contenido = "<p> Estimado Cliente,<br/><br/>" +
                    "Bienvenido al Cotizador de Asisken. Se confirma que su cuenta ha sido Aprobada con éxito.<br/><br/>" +

                    "Inicie Sesión haciendo click Aquí " + ConfigurationManager.AppSettings["Login"] + "</p>";
                if (correo.EnvioCorreo(new EnvioCorreo
                {
                    Asunto = ConfigurationManager.AppSettings["AsuntoUsuario"] + " " + usuario.Identificacion,
                    Contenido = contenido,
                    Destinatario = usuario.Correo,
                    Remitente = ConfigurationManager.AppSettings["CorreoRemitente"]
                }))
                    envio = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
        public int EnvioMailUsuarioPendiente(Usuario usuario)
        {
            int envio = 0;
            try
            {//el link del login
                AgenciaDao agencia = new AgenciaDao();
                EnvioCorreoDao correo = new EnvioCorreoDao();
                string contenido = "<p>Estimado,</p>" +
                    "<p align='justify'>Su cuenta está pendiente de aprobación.<br/> Cuando su cuenta sea " +
                    "aprobada recibirá un correo electrónico confirmando que su cuenta " +
                    "está activa y podrá iniciar sesión. <br/></p>";
                correo.EnvioCorreo(new EnvioCorreo
                {
                    Asunto = ConfigurationManager.AppSettings["Confirmacion"],
                    Contenido = contenido,
                    Destinatario = usuario.Correo,
                    Remitente = ConfigurationManager.AppSettings["CorreoRemitente"]
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
        public int EnvioMailUsuarioContrasenia(Usuario usuario)
        {
            int envio = 0;
            string contrasena;

            try
            {//el link del login
                contrasena = Base64_Decode(usuario.Clave);
                AgenciaDao agencia = new AgenciaDao();
                EnvioCorreoDao correo = new EnvioCorreoDao();
                
                string contenido = "<p> Estimado Cliente,<br/><br/>" +
                    "Su contraseña es: <b>" + contrasena + "</b><br/><br/>" +
                    "Inicie Sesión haciendo click Aquí: " + ConfigurationManager.AppSettings["Login"] + "</p>";
                correo.EnvioCorreo(new EnvioCorreo
                {
                    Asunto = ConfigurationManager.AppSettings["ContraseniaConfirmacion"] + " " + usuario.Identificacion,
                    Contenido = contenido,
                    Destinatario = usuario.Correo,
                    Remitente = ConfigurationManager.AppSettings["CorreoRemitente"]
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
        public int EnvioMailUsuarioDenegado(Usuario usuario)
        {
            int envio = 0;
            try
            {//el link del login
                AgenciaDao agencia = new AgenciaDao();
                EnvioCorreoDao correo = new EnvioCorreoDao();
                string contenido = "<p> Estimado Cliente,<br/><br/>" +
                    "Se confirma que su cuenta ha sido Denegada con por los siguientes motivos:<br/>" +

                    usuario.ObservacionEstado + "<br/>" +
                    "Muchas gracias por su compresión.</p>";
                if (correo.EnvioCorreo(new EnvioCorreo
                {
                    Asunto = ConfigurationManager.AppSettings["AsuntoUsuario"] + " " + usuario.Identificacion,
                    Contenido = contenido,
                    Destinatario = usuario.Correo,
                    Remitente = ConfigurationManager.AppSettings["CorreoRemitente"]
                }))
                    envio = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }

        //Funcion para desencriptar
        public static string Base64_Decode(string str)
        {
            try
            {
                byte[] decbuff = Convert.FromBase64String(str);
                return Encoding.UTF8.GetString(decbuff);
            }
            catch
            {
                //si se envia una cadena si codificación base64, mandamos vacio
                return "";
            }
        }


    }
}
