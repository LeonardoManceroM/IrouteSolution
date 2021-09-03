using Data.Acceso;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CotizadorWeb.Models
{
    public class RolDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private readonly RolDao rolDao = new RolDao();
        //private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public int IdRol { get; set; }
        public string RolDescripcion { get; set; }
        public List<RolDto> ObtenerTodos()
        {
            List<RolDto> roles = new List<RolDto>();
            try
            {
                if (!_onLine)
                {
                    roles.Add(new RolDto
                    {
                        IdRol = 1,
                        RolDescripcion = "Administrador"
                    });
                    roles.Add(new RolDto
                    {
                        IdRol = 2,
                        RolDescripcion = "Usuario"
                    });
                }
                else
                {
                    rolDao.ObtenerTodos().ForEach(x =>
                    {
                        roles.Add(new RolDto
                        {
                            IdRol = x.IdRol,
                            RolDescripcion = x.Descripcion
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roles;
        }
        public RolDto Obtener(int idRol)
        {
            RolDto rol = new RolDto();
            try
            {
                if (!_onLine)
                {
                    List<RolDto> roles = new List<RolDto>();
                    roles.Add(new RolDto
                    {
                        IdRol = 1,
                        RolDescripcion = "Administrador"
                    });
                    roles.Add(new RolDto
                    {
                        IdRol = 2,
                        RolDescripcion = "Usuario"
                    });
                    rol = roles.FirstOrDefault(x => x.IdRol == idRol);
                }
                else
                {
                    var rolBd = rolDao.ObtenerById(idRol);
                    rol.RolDescripcion = rolBd.Descripcion;
                    rol.IdRol = rolBd.IdRol;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return rol;
        }
        public bool Insertar(RolDto rol)
        {
            bool insertado = false;
            try
            {
                if (!_onLine)
                {
                    List<RolDto> estados = new List<RolDto>();
                    estados.Add(rol);
                    insertado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertado;
        }
        public bool Modificar(RolDto rol)
        {
            bool modificado = false;
            try
            {
                if (!_onLine)
                {
                    List<RolDto> estados = new List<RolDto>();
                    estados.Add(rol);
                    modificado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modificado;
        }
    }
}