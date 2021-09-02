using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class CotizacionDependienteDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CotizacionDependienteDao cotizacionDao = new CotizacionDependienteDao();
        public int IdCotizacionDependiente { get; set; }
        public int IdCotizacion { get; set; }
        public int Edad { get; set; }

        public List<CotizacionDependienteDto> ObtenerTodos()
        {
            List<CotizacionDependienteDto> dependientes = new List<CotizacionDependienteDto>();
            try
            {
                if (!_onLine)
                {
                    dependientes.Add(new CotizacionDependienteDto
                    {
                        Edad=5,
                        IdCotizacion=1,
                        IdCotizacionDependiente=1
                    });
                    dependientes.Add(new CotizacionDependienteDto
                    {
                        Edad = 8,
                        IdCotizacion = 2,
                        IdCotizacionDependiente = 2
                    });

                }
                else
                {
                    cotizacionDao.Todos().ForEach(x =>
                    {
                        dependientes.Add(new CotizacionDependienteDto
                        {
                            Edad = x.Edad,
                            IdCotizacion = x.IdCotizacion,
                            IdCotizacionDependiente = x.IdCotizacionDependiente
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return dependientes;
        }
        public List<CotizacionDependienteDto> Obtener(int idCotizacion)
        {
            List<CotizacionDependienteDto> dependienteCotizacion = new List<CotizacionDependienteDto>();
            try
            {
                if (!_onLine)
                {
                    List<CotizacionDependienteDto> dependientes = new List<CotizacionDependienteDto>();
                    dependientes.Add(new CotizacionDependienteDto
                    {
                        Edad = 5,
                        IdCotizacion = 1,
                        IdCotizacionDependiente = 1
                    });
                    dependientes.Add(new CotizacionDependienteDto
                    {
                        Edad = 8,
                        IdCotizacion = 2,
                        IdCotizacionDependiente = 2
                    });
                    dependienteCotizacion = dependientes.FindAll(x => x.IdCotizacion == idCotizacion);
                }
                else
                {
                    cotizacionDao.ObtenerByIdCotizacion(idCotizacion).ForEach(x =>
                    {
                        dependienteCotizacion.Add(new CotizacionDependienteDto
                        {
                            Edad = x.Edad,
                            IdCotizacion = x.IdCotizacion,
                            IdCotizacionDependiente = x.IdCotizacionDependiente
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return dependienteCotizacion;
        }
        public bool Insertar(CotizacionDependienteDto dependiente)
        {
            bool insertado =false;
            try
            {
                if (!_onLine)
                {
                    List<CotizacionDependienteDto> menus = new List<CotizacionDependienteDto>();
                    menus.Add(dependiente);
                    insertado = true;
                }
                else
                {
                    insertado = cotizacionDao.Guardar(new CotizacionDependiente
                    {
                        Edad = dependiente.Edad,
                        IdCotizacionDependiente = dependiente.IdCotizacionDependiente,
                        IdCotizacion = dependiente.IdCotizacion
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return insertado;
        }
        public bool Modificar(CotizacionDependienteDto dependiente)
        {
            bool modificado = false;
            try
            {
                if (!_onLine)
                {
                    List<CotizacionDependienteDto> menus = new List<CotizacionDependienteDto>();
                    menus.Add(dependiente);
                    modificado = true;
                }
                else
                {
                    modificado = cotizacionDao.Modificar(new CotizacionDependiente
                    {
                        Edad = dependiente.Edad,
                        IdCotizacionDependiente = dependiente.IdCotizacionDependiente,
                        IdCotizacion = dependiente.IdCotizacion
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return modificado;
        }
    }
}