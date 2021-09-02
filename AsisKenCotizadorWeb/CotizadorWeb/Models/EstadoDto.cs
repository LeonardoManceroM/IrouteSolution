using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class EstadoDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly EstadoDao estadoDao = new EstadoDao();
        public int IdEstado { get; set; }
        public string EstadoDescripcion { get; set; }
        public List<EstadoDto> ObtenerTodos()
        {
            List<EstadoDto> brokers = new List<EstadoDto>();
            try
            {
                if (!_onLine)
                {
                    brokers.Add(new EstadoDto
                    {
                        IdEstado=1,
                        EstadoDescripcion="Activo"
                    });
                    brokers.Add(new EstadoDto
                    {
                        IdEstado = 2,
                        EstadoDescripcion = "Inactivo"
                    });
                    brokers.Add(new EstadoDto
                    {
                        IdEstado = 3,
                        EstadoDescripcion = "Denegado"
                    });
                    brokers.Add(new EstadoDto
                    {
                        IdEstado = 4,
                        EstadoDescripcion = "Pendiente de Aprobación"
                    });
                    brokers.Add(new EstadoDto
                    {
                        IdEstado = 5,
                        EstadoDescripcion = "Suspendido por Inactividad"
                    });
                }
                else
                {
                    estadoDao.ObtenerTodosEstado().ForEach(x =>
                    {
                        brokers.Add(new EstadoDto
                        {
                            EstadoDescripcion = x.Descripcion,
                            IdEstado = x.IdEstado
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return brokers;
        }
        public EstadoDto Obtener(int idestado)
        {
            EstadoDto estado = new EstadoDto();
            try
            {
                if (!_onLine)
                {
                    List<EstadoDto> estados = new List<EstadoDto>();
                    estados.Add(new EstadoDto
                    {
                        IdEstado = 1,
                        EstadoDescripcion = "Activo"
                    });
                    estados.Add(new EstadoDto
                    {
                        IdEstado = 2,
                        EstadoDescripcion = "Inactivo"
                    });
                    estados.Add(new EstadoDto
                    {
                        IdEstado = 3,
                        EstadoDescripcion = "Denegado"
                    });
                    estados.Add(new EstadoDto
                    {
                        IdEstado = 3,
                        EstadoDescripcion = "Pendiente de Aprobación"
                    });
                    estados.Add(new EstadoDto
                    {
                        IdEstado = 3,
                        EstadoDescripcion = "Suspendido por Inactividad"
                    });
                    estado = estados.FirstOrDefault(x => x.IdEstado == idestado);
                }
                else
                {
                    var estadoBd = estadoDao.ObtenerEstadoById(idestado);
                    estado.EstadoDescripcion = estadoBd.Descripcion;
                    estado.IdEstado = estadoBd.IdEstado;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return estado;
        }
        public bool Insertar(EstadoDto estado)
        {
            bool insertado;
            try
            {
                if (!_onLine)
                {
                    List<EstadoDto> estados = new List<EstadoDto>
                    {
                        estado
                    };
                    insertado = true;
                }
                else
                {
                    var estadoBd = new Estado
                    {
                        IdEstado = estado.IdEstado,
                        Descripcion = estado.EstadoDescripcion
                    };
                    insertado = estadoDao.Insertar(estadoBd);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return insertado;
        }
        public bool Modificar(EstadoDto estado)
        {
            bool modificado;
            try
            {
                if (!_onLine)
                {
                    List<EstadoDto> estados = new List<EstadoDto>();
                    estados.Add(estado);
                    modificado = true;
                }
                else
                {
                    var estadoBd = new Estado
                    {
                        IdEstado = estado.IdEstado,
                        Descripcion = estado.EstadoDescripcion
                    };
                    modificado = estadoDao.Modificar(estadoBd);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return modificado;
        }
    }
}