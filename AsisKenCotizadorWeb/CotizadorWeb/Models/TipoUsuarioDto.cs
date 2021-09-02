using Data.Acceso;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class TipoUsuarioDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly TipoUsuarioDao tipoDao =new TipoUsuarioDao();
        public int IdTipo{ get; set; }
        public string Descripcion { get; set; }
        public List<TipoUsuarioDto> ObtenerTodos()
        {
            List<TipoUsuarioDto> tipoUsuario = new List<TipoUsuarioDto>();
            try
            {
                if (!_onLine)
                {
                    tipoUsuario.Add(new TipoUsuarioDto
                    {
                        Descripcion = "Asisken",
                        IdTipo = 1
                    });
                    tipoUsuario.Add(new TipoUsuarioDto
                    {
                        Descripcion = "Broker",
                        IdTipo = 2
                    });
                }
                else
                {
                    tipoDao.ObtenerTodos().ForEach(x =>
                    {
                        tipoUsuario.Add(new TipoUsuarioDto
                        {
                            Descripcion = x.Descripcion,
                            IdTipo = x.IdTipo
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipoUsuario;
        }
        public TipoUsuarioDto ObtenerTipos(int idTipoUsuario)
        {
            TipoUsuarioDto tipoUsuario = new TipoUsuarioDto();
            try
            {
                if (!_onLine)
                {
                    List<TipoUsuarioDto> tipoUsuarios = new List<TipoUsuarioDto>();
                    tipoUsuarios.Add(new TipoUsuarioDto
                    {
                        Descripcion = "Asisken",
                        IdTipo = 1
                    });
                    tipoUsuarios.Add(new TipoUsuarioDto
                    {
                        Descripcion = "Broker",
                        IdTipo = 2
                    });
                    tipoUsuario = tipoUsuarios.FirstOrDefault(x => x.IdTipo == idTipoUsuario);
                }
                else
                {
                    var tiposuarioBD = tipoDao.ObtenerById(idTipoUsuario);
                    if (tiposuarioBD != null)
                    {
                        tipoUsuario.IdTipo = tiposuarioBD.IdTipo;
                        tipoUsuario.Descripcion = tiposuarioBD.Descripcion;
                    }
                }    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipoUsuario;
        }
        public bool InsertarTipo(TipoUsuarioDto tipoUsuario)
        {
            bool insertado = false;
            try
            {
                if (!_onLine)
                {
                    List<TipoUsuarioDto> tipoUsuarios = new List<TipoUsuarioDto>();
                    tipoUsuarios.Add(tipoUsuario);
                    insertado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertado;
        }
        public bool ModificarTipo(TipoUsuarioDto tipoUsuario)
        {
            bool modificado = false;
            try
            {
                if (!_onLine)
                {
                    List<TipoUsuarioDto> tipoUsuarios = new List<TipoUsuarioDto>();
                    tipoUsuarios.Add(tipoUsuario);
                    modificado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modificado;
        }
        public bool EliminarTipo(int IdtipoUsuario)
        {
            bool modificado = false;
            try
            {
                if (!_onLine)
                {

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