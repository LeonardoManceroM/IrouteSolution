using Data.Acceso;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;

namespace CotizadorWeb.Models
{
    public class EnvioCorreoDto
    {
        private readonly EnvioCorreoDao correoDao = new EnvioCorreoDao();
        public bool EnvioCotizacion(HttpPostedFile file, EnvioCorreo correo)
        {
            string DirectorioArchivo = ConfigurationManager.AppSettings["ruta"];
            bool envio;
            try
            {
                List<string> archivos = new List<string>();

                string nombre = ConfigurationManager.AppSettings["patron_incial"] + Convert.ToString(DateTime.Now.Year) + file.FileName;
                    
                var path = HttpContext.Current.Server.MapPath(Path.Combine(DirectorioArchivo, nombre));
                file.SaveAs(path);
                archivos.Add(path);
                envio = correoDao.EnvioCorreo(correo, archivos.ToArray());
                if (envio)//elimino el archivo del servidor
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return envio;
        }
        public bool EnvioCotizacion(string path, EnvioCorreo correo)
        {
            bool envio;
            List<string> archivos = new List<string>();
            archivos.Add(path);
            envio = correoDao.EnvioCorreo(correo, archivos.ToArray());
            if (envio && File.Exists(path))
            {
                File.Delete(path);
            }
            return envio;
        }
        public bool EnvioCotizacion(EnvioCorreo correo)
        {
            bool envio;
            try
            {
                envio = correoDao.EnvioCorreo(correo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return envio;
        }
    }
}