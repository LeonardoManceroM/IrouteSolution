using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class SubMenuDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public int Padre { get; set; }
        public string Page { get; set; }
        public string Permission { get; set; }

        public List<SubMenuDto> Obtener(int idPadre)
        {
            List<SubMenuDto> subMenu = new List<SubMenuDto>();
            if (!_onLine)
            {
                subMenu.Add(new SubMenuDto
                {
                    Padre = idPadre,
                    //Titulo = "Consultar Usuarios",
                    Page="ConsultarUsuario.aspx",
                    //IdRol=2
                });
                subMenu.Add(new SubMenuDto
                {
                    Padre = idPadre,
                    //Titulo = "Actualizar Usuarios",
                    Page = "ConsultarUsuario.aspx",
                    //IdRol = 1
                });
                subMenu.Add(new SubMenuDto
                {
                    Padre = idPadre,
                    //Titulo = "Crear Usuarios",
                    Page="CrearUsuario.aspx",
                    //IdRol = 1
                });
                subMenu.Add(new SubMenuDto
                {
                    Padre = idPadre,
                    //Titulo = "Consultar Usuarios",
                    Page="ConsultarUsuario.aspx",
                    //IdRol = 1
                });
            }
            return subMenu;
        } 
    }
}