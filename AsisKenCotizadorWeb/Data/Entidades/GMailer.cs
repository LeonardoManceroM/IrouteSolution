using log4net;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace Data.Entidades
{
    public class GMailer
    {
        public static string FromUsername { get; set; }
        public static string MailHost { get; set; }
        public static int MailPort { get; set; }
        public static bool MailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        public string[] Archivos { get; set; }

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static GMailer()
        {

            MailHost = ConfigurationManager.AppSettings["Host"];
            MailPort = int.Parse(ConfigurationManager.AppSettings["Puerto"]);
            MailSSL = true;
        }

        public void Send()
        {
            var smtp = new SmtpClient();
            smtp.Host = MailHost;
            smtp.Port = MailPort;
            smtp.EnableSsl = MailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["CorreoRemitente"], ConfigurationManager.AppSettings["clave"]);
            try
            {
                var message = new MailMessage(FromUsername, ToEmail);
                using (message)
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    if(Archivos!=null)
                    {
                        foreach (string archivo in Archivos)
                        {
                            //comprobamos si existe el archivo y lo agregamos a los adjuntos
                            if (File.Exists(archivo))
                                message.Attachments.Add(new Attachment(archivo));

                        }
                    }
                    //para firma
                    //var firma= HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["Firma"]);
                    //if (File.Exists(firma) && IsHtml)
                    //{
                    //    message.Attachments.Add(new Attachment(firma));
                    //    message.Body = message.Body + "<br/><br/><image src='" + message.Attachments[message.Attachments.Count - 1].Name + "'/>";
                    //}
                    smtp.Send(message);
                }
            }
            catch (Exception exception)
            {
                log.Error(exception.Message, exception);
                throw exception;
            }

        }

    }
}