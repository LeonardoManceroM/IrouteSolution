using Data.Entidades;
using System;

namespace Data.Acceso
{
    public class EnvioCorreoDao
    {
        public bool EnvioCorreo(EnvioCorreo contenido)
        {
            bool envio;
            try
            {
                GMailer mail = new GMailer();
                GMailer.FromUsername = contenido.Remitente;//ConfigurationManager.AppSettings["Correo"];
                mail.ToEmail = contenido.Destinatario;
                mail.Subject = contenido.Asunto;
                mail.Body = contenido.Contenido;
                mail.IsHtml = true;
                mail.Send();
                envio = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
        public bool EnvioCorreo(EnvioCorreo contenido, string[] archivos)
        {
            bool envio;
            try
            {
                GMailer mail = new GMailer();
                GMailer.FromUsername = contenido.Remitente;//ConfigurationManager.AppSettings["Correo"];
                mail.ToEmail = contenido.Destinatario;
                mail.Subject = contenido.Asunto;
                mail.Body = contenido.Contenido;
                mail.IsHtml = true;
                mail.Archivos = archivos;
                mail.Send();
                envio = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
    }
}
