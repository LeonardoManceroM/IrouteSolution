using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CotizadorWeb
{
    public static class WebApiConfig
    {
        private static readonly string OriginCORS = ConfigurationManager.AppSettings["OriginCORS"];
        public static void Register(HttpConfiguration config)
        {
            //CORS
            EnableCorsAttribute cors = new EnableCorsAttribute(OriginCORS, "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
