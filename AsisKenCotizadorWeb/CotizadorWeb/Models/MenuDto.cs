using Data.Acceso;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class MenuDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public int IdMenu { get; set; }
        public int IdRol { get; set; }
        public string Titulo { get; set; }
        public int Padre { get; set; }
        public string Icon { get; set; }
        public string Page { get; set; }//url de la pagina
        public string Bullet { get; set; }// para subitems
        public bool Root { get; set; }//true si es padre 2 si es hijo
        public List<SubMenuDto> SubMenu { get; set; }
        private readonly MenuDao menuDao = new MenuDao();
        public List<MenuDto> Obtener(int idRol)
        {
            List<MenuDto> menuRol = new List<MenuDto>();
            List<SubMenuDto> SubMenuInstancia = new List<SubMenuDto>();
            try
            {
                if (!_onLine)
                {
                    menuRol.Add(new MenuDto
                    {
                        IdMenu = 3,
                        IdRol = 2,
                        Titulo = "Usuarios",
                        Icon = "imagen.png",
                        Padre = 0,
                        //SubMenu = subMenuDto.Obtener(3).FindAll(x => x.IdRol == 2)
                    });
                    menuRol.Add(new MenuDto
                    {
                        IdMenu = 3,
                        IdRol = 1,
                        Titulo = "Usuarios",
                        Icon = "imagen.png",
                        Padre = 0,
                        //SubMenu = SubMenu = subMenuDto.Obtener(3).FindAll(x => x.IdRol == 1)
                    });
                    menuRol.FindAll(x => x.IdRol == idRol);
                }
                else
                {
                    var menuBd = menuDao.ObtenerByRol(idRol);
                    menuBd.ForEach(x =>
                    {
                        if (!x.Root)
                        {
                            SubMenuInstancia.Add(new SubMenuDto
                            {
                                Padre = x.Padre,
                                Page = x.Page,
                                Permission = x.Persmission
                            });
                        }
                    });
                    menuBd.ForEach(x =>
                    {
                        if (x.Root)
                        {
                            menuRol.Add(new MenuDto
                            {
                                Page=x.Page,
                                IdMenu=x.IdMenu,
                                Icon=x.Icon,
                                Root=x.Root,
                                Titulo=x.Titulo,
                                Bullet=x.Bullet,
                                SubMenu=SubMenuInstancia.FindAll(y=>y.Padre.Equals(x.IdMenu))
                                
                            });
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menuRol;
        }
    }
}