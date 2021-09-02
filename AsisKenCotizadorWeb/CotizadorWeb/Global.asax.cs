using log4net;
using System.IO;
using System.Reflection;
using System.Web.Http;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]

namespace CotizadorWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(("~/Web.config")));

            GlobalConfiguration.Configure(WebApiConfig.Register);
            Log.Info("Aplicacion Cotizador Web iniciada.");

        }
    }
}