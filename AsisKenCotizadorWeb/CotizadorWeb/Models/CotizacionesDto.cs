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
    public class CotizacionesDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CotizacionDao cotizacionDao = new CotizacionDao();
        private readonly CaracteristicasDao caracteristicasDao = new CaracteristicasDao();
        private readonly UsuarioDao usuarioDao = new UsuarioDao();
        private readonly ConfiguracionesDto configuracionesDto = new ConfiguracionesDto();

        public int IdContizacion { get; set; }
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public int IdPlan { get; set; }
        public bool Estado { get; set; }
        public bool TitularBeneficio { get; set; }
        public DateTime TitularNacimiento{ get; set; }
        public char TitularGenero { get; set; }
        public int TitularEdad { get; set; }
        public bool TitularMaternidad { get; set; }
        public DateTime ConyugueFechaNacimiento { get; set; }
        public char ConyugueGenero { get; set; }
        public int ConyugueEdad { get; set; }
        public decimal ValorMensual { get; set; }
        public decimal ValorTrimestral { get; set; }
        public decimal ValorSemestral { get; set; }
        public decimal ValorAnual { get; set; }
        public decimal ValorContado { get; set; }
        public string NombrePlan { get; set; }
        public string EstadoDescripcion { get; set; }//1--->activo 0-->inactivo
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public bool Guardada { get; set; }
        public int IdRegion { get; set; }
        public string Region { get; set; }

        public string DescEstadoPlan { get; set; } //Activo Inactivo


        public List<CotizacionesDto> ObtenerTodos(int idUsuario)
        {
            List<CotizacionesDto> cotizacion = new List<CotizacionesDto>();
            try
            {
                PlanesDto planDao = new PlanesDto();
                if (!_onLine)
                {

                    cotizacion.Add(new CotizacionesDto
                    {
                        Cliente = "Jorge Uzca",
                        /*ConyugueEdad = 37,
                        ConyugueFechaNacimiento = new DateTime(1983, 12, 4),
                        ConyugueGenero = 'F',*/
                        Estado = true,
                        EstadoDescripcion = Estado ? "Activo" : "Inactivo",
                        FechaCotizacion = DateTime.Now,
                        IdContizacion = 1,
                        IdPlan = 1,
                        NombrePlan = "CURAE PLENUS",
                        DescEstadoPlan = "Activo",
                        IdUsuario = 1,
                        /*TitularEdad = 37,
                        TitularGenero = 'M',//F si es mujer
                        TitularMaternidad = "Aragundi Dana",
                        TitularNacimiento = new DateTime(1983, 12, 4),
                        ValorAnual = 235,
                        ValorMensual = 235,
                        ValorSemestral = 235,
                        ValorTrimestral = 235,
                        ValorContado = 235,*/
                        NombreProducto = planDao.ObtenerPlanesByIdPlan(1).DescProducto
                    }) ;
                    cotizacion.Add(new CotizacionesDto
                    {
                        Cliente = "Miguel Arteaga",
                        /*ConyugueEdad = 37,
                        ConyugueFechaNacimiento = new DateTime(1960, 5, 12),
                        ConyugueGenero = 'F',*/
                        Estado = true,
                        EstadoDescripcion = Estado ? "Activo" : "Inactivo",
                        FechaCotizacion = DateTime.Now,
                        IdContizacion = 1,
                        IdPlan = 1,
                        NombrePlan = "CURAE PLENUS",
                        DescEstadoPlan = "Activo",
                        IdUsuario = 1,
                        /*TitularEdad = 37,
                        TitularGenero = 'M',
                        TitularMaternidad = "Martha Vergara",
                        TitularNacimiento = new DateTime(1950, 6, 4),
                        ValorAnual = 235,
                        ValorMensual = 235,
                        ValorSemestral = 235,
                        ValorTrimestral = 235,
                        ValorContado = 235,*/
                        NombreProducto = planDao.ObtenerPlanesByIdPlan(1).DescProducto
                    });
                    cotizacion.Add(new CotizacionesDto
                    {
                        Cliente = "Miguel Arteaga",
                        /*ConyugueEdad = 37,
                        ConyugueFechaNacimiento = new DateTime(1960, 5, 12),
                        ConyugueGenero = 'F',*/
                        Estado = true,
                        EstadoDescripcion = Estado ? "Activo" : "Inactivo",
                        FechaCotizacion = DateTime.Now,
                        IdContizacion = 1,
                        IdPlan = 4,
                        NombrePlan = "POOL 1",
                        DescEstadoPlan = "Activo",
                        IdUsuario = 1,
                        /*TitularEdad = 37,
                        TitularGenero = 'M',
                        TitularMaternidad = "Martha Vergara",
                        TitularNacimiento = new DateTime(1950, 6, 4),
                        ValorAnual = 235,
                        ValorMensual = 235,
                        ValorSemestral = 235,
                        ValorTrimestral = 235,
                        ValorContado = 235,*/
                        NombreProducto = planDao.ObtenerPlanesByIdPlan(4).DescProducto
                    });
                    cotizacion.FindAll(x => x.IdUsuario == idUsuario);
                }
                else
                {
                    Log.Info("Inicio de consulta de cotizacion");
                    var cotizacionBD = idUsuario > 0 ? cotizacionDao.Todos().FindAll(x => x.IdUsuario.Equals(idUsuario)) : cotizacionDao.Todos();
                    cotizacionBD.ForEach(x =>
                    {
                        cotizacion.Add(new CotizacionesDto
                        {
                            Cliente = x.Cliente,
                            Estado = x.Estado,
                            EstadoDescripcion = x.EstadoDescripcion,
                            FechaCotizacion = x.FechaCotizacion,
                            IdContizacion = x.IdContizacion,
                            IdPlan = x.IdPlan,
                            NombrePlan = x.NombrePlan,
                            DescEstadoPlan = x.DescEstadoPlan,
                            IdUsuario = x.IdUsuario,
                            NombreProducto = x.NombreProducto,
                            IdProducto = x.IdProducto,
                            TitularBeneficio = x.TitularBeneficio,
                            Guardada = x.Guardada,
                            Region = x.Region
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return cotizacion;
        }
        public CotizacionesDto Obtener(int idCotizacion)
        {
            CotizacionesDto cotizacion = new CotizacionesDto();
            PlanesDto planDao = new PlanesDto();
            try
            {
                if (!_onLine)
                {
                    List<CotizacionesDto> cotizaciones = new List<CotizacionesDto>();
                    cotizaciones.Add(new CotizacionesDto
                    {
                        Cliente = "Jorge Uzca",
                        ConyugueEdad = 37,
                        ConyugueFechaNacimiento = new DateTime(1983, 12, 4),
                        ConyugueGenero = 'F',
                        Estado = true,
                        FechaCotizacion = DateTime.Now,
                        IdContizacion = 1,
                        IdPlan = 1,
                        IdUsuario = 1,
                        TitularEdad = 37,
                        TitularGenero = 'M',
                        //TitularMaternidad = "Aragundi Dana",
                        TitularNacimiento = new DateTime(1983, 12, 4),
                        ValorAnual = 235,
                        ValorMensual = 235,
                        ValorSemestral = 235,
                        ValorTrimestral = 235,
                        NombreProducto = planDao.ObtenerPlanesByIdPlan(1).DescProducto,
                        EstadoDescripcion = Estado ? "Activo" : "Inactivo",
                        DescEstadoPlan = "Activo"
                    });
                    cotizaciones.Add(new CotizacionesDto
                    {
                        Cliente = "Miguel Arteaga",
                        ConyugueEdad = 37,
                        ConyugueFechaNacimiento = new DateTime(1960, 5, 12),
                        ConyugueGenero = 'F',
                        Estado = true,
                        FechaCotizacion = DateTime.Now,
                        IdContizacion = 2,
                        IdPlan = 1,
                        IdUsuario = 1,
                        TitularEdad = 37,
                        TitularGenero = 'M',
                        TitularMaternidad = true,
                        TitularNacimiento = new DateTime(1950, 6, 4),
                        ValorAnual = 235,
                        ValorMensual = 235,
                        ValorSemestral = 235,
                        ValorTrimestral = 235,
                        NombreProducto = planDao.ObtenerPlanesByIdPlan(1).DescProducto,
                        EstadoDescripcion = Estado ? "Activo" : "Inactivo",
                        DescEstadoPlan = "Activo"
                    });
                    cotizaciones.Add(new CotizacionesDto
                    {
                        Cliente = "Angel Fuentes",
                        ConyugueEdad = 37,
                        ConyugueFechaNacimiento = new DateTime(1960, 5, 12),
                        ConyugueGenero = 'F',
                        Estado = true,
                        FechaCotizacion = DateTime.Now,
                        IdContizacion = 3,
                        IdPlan = 1,
                        IdUsuario = 1,
                        TitularEdad = 37,
                        TitularGenero = 'M',
                        TitularMaternidad = true,
                        TitularNacimiento = new DateTime(1950, 6, 4),
                        ValorAnual = 235,
                        ValorMensual = 235,
                        ValorSemestral = 235,
                        ValorTrimestral = 235,
                        NombreProducto = planDao.ObtenerPlanesByIdPlan(1).DescProducto,
                        EstadoDescripcion = Estado ? "Activo" : "Inactivo",
                        DescEstadoPlan = "Inactivo"
                    });
                    cotizacion = cotizaciones.FirstOrDefault(x => x.IdContizacion == idCotizacion);
                }
                else
                {
                    var cotizacionBd = cotizacionDao.ObtenerById(idCotizacion);
                    cotizacion.Cliente = cotizacionBd.Cliente;
                    cotizacion.ConyugueEdad = cotizacionBd.ConyugueEdad;
                    cotizacion.ConyugueFechaNacimiento = cotizacionBd.ConyugueFechaNacimiento;
                    cotizacion.ConyugueGenero = cotizacionBd.ConyugueGenero;
                    cotizacion.DescEstadoPlan = cotizacionBd.DescEstadoPlan;
                    cotizacion.Estado = cotizacionBd.Estado;
                    cotizacion.EstadoDescripcion = cotizacionBd.EstadoDescripcion;
                    cotizacion.FechaCotizacion = cotizacionBd.FechaCotizacion;
                    cotizacion.IdContizacion = cotizacionBd.IdContizacion;
                    cotizacion.IdPlan = cotizacionBd.IdPlan;
                    cotizacion.IdUsuario = cotizacionBd.IdUsuario;
                    cotizacion.NombrePlan = cotizacionBd.NombrePlan;
                    cotizacion.NombreProducto = cotizacionBd.NombreProducto;
                    cotizacion.TitularEdad = cotizacionBd.TitularEdad;
                    cotizacion.TitularGenero = cotizacionBd.TitularGenero;
                    cotizacion.TitularMaternidad = cotizacionBd.TitularMaternidad;
                    cotizacion.TitularNacimiento = cotizacionBd.TitularNacimiento;
                    cotizacion.ValorAnual = cotizacionBd.ValorAnual;
                    cotizacion.ValorContado = cotizacionBd.ValorContado;
                    cotizacion.ValorMensual = cotizacionBd.ValorMensual;
                    cotizacion.ValorSemestral = cotizacionBd.ValorSemestral;
                    cotizacion.ValorTrimestral = cotizacionBd.ValorTrimestral;
                    cotizacion.Region = cotizacionBd.Region;

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return cotizacion;
        }
        /*
        public int Insertar(CotizacionesDto cotizacion)
        {
            int insertado = 0;
            try
            {
                if (!_onLine)
                {
                    List<CotizacionesDto> menus = new List<CotizacionesDto>();
                    menus.Add(cotizacion);
                    insertado = 1;
                }
                else
                {
                    insertado = cotizacionDao.Guardar(new Cotizaciones
                    {
                        Cliente = cotizacion.Cliente,
                        ConyugueEdad = cotizacion.ConyugueEdad,
                        ConyugueFechaNacimiento = cotizacion.ConyugueFechaNacimiento,
                        ConyugueGenero = cotizacion.ConyugueGenero,
                        Estado = cotizacion.Estado,
                        EstadoDescripcion = cotizacion.EstadoDescripcion,
                        FechaCotizacion = cotizacion.FechaCotizacion,
                        IdContizacion = cotizacion.IdContizacion,
                        IdPlan = cotizacion.IdPlan,
                        NombrePlan = cotizacion.NombrePlan,
                        DescEstadoPlan = cotizacion.DescEstadoPlan,
                        IdUsuario = cotizacion.IdUsuario,
                        TitularEdad = cotizacion.TitularEdad,
                        TitularGenero = cotizacion.TitularGenero,//F si es mujer
                        TitularMaternidad = cotizacion.TitularMaternidad,
                        TitularNacimiento = cotizacion.TitularNacimiento,
                        ValorAnual = cotizacion.ValorAnual,
                        ValorMensual = cotizacion.ValorMensual,
                        ValorSemestral = cotizacion.ValorSemestral,
                        ValorTrimestral = cotizacion.ValorTrimestral,
                        NombreProducto = cotizacion.NombreProducto,
                        ValorContado = cotizacion.ValorContado
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return insertado;
        }
        public int Modificar(CotizacionesDto cotizacion)
        {
            int modificado = 0;
            try
            {
                if (!_onLine)
                {
                    List<CotizacionesDto> menus = new List<CotizacionesDto>();
                    menus.Add(cotizacion);
                    modificado = 1;
                }
                else
                {
                    modificado = cotizacionDao.Modificar(new Cotizaciones
                    {
                        Cliente = cotizacion.Cliente,
                        ConyugueEdad = cotizacion.ConyugueEdad,
                        ConyugueFechaNacimiento = cotizacion.ConyugueFechaNacimiento,
                        ConyugueGenero = cotizacion.ConyugueGenero,
                        Estado = cotizacion.Estado,
                        EstadoDescripcion = cotizacion.EstadoDescripcion,
                        FechaCotizacion = cotizacion.FechaCotizacion,
                        IdContizacion = cotizacion.IdContizacion,
                        IdPlan = cotizacion.IdPlan,
                        NombrePlan = cotizacion.NombrePlan,
                        DescEstadoPlan = cotizacion.DescEstadoPlan,
                        IdUsuario = cotizacion.IdUsuario,
                        TitularEdad = cotizacion.TitularEdad,
                        TitularGenero = cotizacion.TitularGenero,//F si es mujer
                        TitularMaternidad = cotizacion.TitularMaternidad,
                        TitularNacimiento = cotizacion.TitularNacimiento,
                        ValorAnual = cotizacion.ValorAnual,
                        ValorMensual = cotizacion.ValorMensual,
                        ValorSemestral = cotizacion.ValorSemestral,
                        ValorTrimestral = cotizacion.ValorTrimestral,
                        NombreProducto = cotizacion.NombreProducto,
                        ValorContado = cotizacion.ValorContado
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return modificado;
        }
        */
        public SeccionCotizacionIndDto GenereCotizacion(GeneraCotizacionIndividual datosCotizacion)
        {
            List<Caracteristicas> ListaCaracteristicasPlan = new List<Caracteristicas>();
            var CaracteristicasSeccion = new List<SeccionBloqueDto>();
            var CaracteristicasP = new List<SeccionCaracteristicasDto>();
            var DatosCotizacion = new SeccionCotizacionIndDto();
            GeneraCotizacionResultado cotizacionResultado = new GeneraCotizacionResultado();
            var GenDatosCotizacion = new SeccionCotizacionIndDto();
            List<ConsultaCotizacion> listaConsultaCot = new List<ConsultaCotizacion>();
            List<Configuraciones> ListaConfiguraciones;

            try
            {
                if (!_onLine)
                {
                    Log.Info("GenereCotizacion OffLine");
                }
                else
                {
                    //Genera la cotizacion en BD
                    cotizacionResultado = cotizacionDao.GeneraCotizacion(datosCotizacion);

                    //Consulta los nuevos datos de cotizacion valida solo cabecera
                    listaConsultaCot = cotizacionDao.ConsultaCotizacionByID(cotizacionResultado.IdCotizacion, false);

                    //Consulta las caracteristicas para el PDF
                    ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicasPdf(datosCotizacion.IdPlan, datosCotizacion.CoberturasAdicionales, datosCotizacion.TitularBeneficio, listaConsultaCot.FirstOrDefault().TitularMaternidad, false);

                    ListaCaracteristicasPlan.ForEach(x => {

                        CaracteristicasP.Add(new SeccionCaracteristicasDto
                        {
                            IdSeccion = x.IdSeccion,
                            IdPlantillaC = x.IdPlantillaC,
                            Descripcion = x.Descripcion,
                            IdCaracteristica = x.IdCaracteristica,
                            IdPlan = x.IdPlan,
                            Valor = x.Valor,
                            AplicaMaternidad = x.AplicaMaternidad,
                            AplicaNSolo = x.AplicaNSolo,
                            Estado = x.Estado
                        });
                    });

                    ListaCaracteristicasPlan.ForEach(x => {
                        if (!CaracteristicasSeccion.Exists(y => y.IdSeccion.Equals(x.IdSeccion)))
                        {
                            CaracteristicasSeccion.Add(new SeccionBloqueDto
                            {
                                IdSeccion = x.IdSeccion,
                                Seccion = x.Seccion,
                                Plantillas = CaracteristicasP.FindAll(z => z.IdSeccion.Equals(x.IdSeccion))
                            });
                        }
                    });

                    //Consultar la observacion final del PDF.
                    ListaConfiguraciones = configuracionesDto.ObtenerConfiguraciones();
                    string observacionFinPdf = (ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_Observaciones_Pdf").Descripcion);

                    //Armar cabecera
                    DatosCotizacion = new SeccionCotizacionIndDto
                    {
                        NombrePlan = cotizacionResultado.DescPlan,
                        IdCotizacion = cotizacionResultado.IdCotizacion,
                        FechaCotizacion = cotizacionResultado.FechaCotizacion,
                        Cliente = datosCotizacion.Cliente,
                        TitularEdad = datosCotizacion.TitularEdad,
                        ConyugueEdad = datosCotizacion.ConyugueEdad,
                        Dependientes = datosCotizacion.Dependientes,
                        IdUsuario = datosCotizacion.IdUsuario,
                        Agente = cotizacionResultado.Agente,
                        Telefono = cotizacionResultado.Telefono,
                        Agencia = cotizacionResultado.Agencia,
                        Direccion = cotizacionResultado.Direccion,
                        Region = cotizacionResultado.Region,
                        VersionPlan = 1,
                        VersionPlanTexto = "1.0",
                        SeccionBloquesPlantillas = CaracteristicasSeccion,
                        TarifasResultado = new CalculaTarifasResultado
                        {
                            ValorMensual = cotizacionResultado.ValorMensual,
                            ValorTrimestral = cotizacionResultado.ValorTrimestral,
                            ValorSemestral = cotizacionResultado.ValorSemestral,
                            ValorAnual = cotizacionResultado.ValorAnual,
                            ValorContado = cotizacionResultado.ValorContado
                        },
                        Conf_Observaciones_Pdf = observacionFinPdf
                    };

                    Log.Info("GenereCotizacion OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return DatosCotizacion;
        }

        public SeccionCotizaciones ConsultaCotizacionId(int idCotizacion, bool isPool, bool Comparar)
        {
            List<Caracteristicas> ListaCaracteristicasPlan = new List<Caracteristicas>();
            var CaracteristicasSeccion = new List<SeccionBloqueDto>();
            var CaracteristicasP = new List<SeccionCaracteristicasDto>();
            var DatosCotizacion = new SeccionCotizaciones();
            List<CotizacionCategoriaPool> categoriaPool = new List<CotizacionCategoriaPool>();
            List<ConsultaCotizacion> listaConsulta = new List<ConsultaCotizacion>();
            var beneficios = new List<int>();
            var catalogosBeneficios = new List<int>();
            var plan = new List<Planes>();
            var var_cotizacion = new List<ConsultaCotizacion>();
            var edad = new List<int>();
            var plan_pool = new List<CotizacionCategoriaPool>();
            List<Configuraciones> ListaConfiguraciones;

            try
            {
                listaConsulta = cotizacionDao.ConsultaCotizacionByID(idCotizacion, isPool);

                if (listaConsulta.Count <= 0)
                {
                    return new SeccionCotizaciones();
                }

                listaConsulta.ForEach(x =>
                {
                    if (!isPool && x.IdBeneficio > 0 && !beneficios.Exists(y => y.Equals(x.IdBeneficio)))
                    {
                        beneficios.Add(x.IdBeneficio);
                        catalogosBeneficios.Add(x.IdCatalogoBeneficio);
                    }
                    
                    if (!isPool && x.Edad >= 0)
                        edad.Add(x.Edad);

                    if (!var_cotizacion.Exists(w => w.IdCotizacion.Equals(x.IdCotizacion)))
                    {
                        var_cotizacion.Add(new ConsultaCotizacion
                        {
                            IdCotizacion = x.IdCotizacion,
                            IdUsuario = x.IdUsuario,
                            Cliente = x.Cliente,
                            FechaCotizacion = x.FechaCotizacion,
                            IdPlan = x.IdPlan,
                            Estado = x.Estado,
                            TitularNacimiento = x.TitularNacimiento,
                            TitularGenero = x.TitularGenero,
                            TitularEdad = x.TitularEdad,
                            TitularBeneficio = x.TitularBeneficio,
                            TitularMaternidad = x.TitularMaternidad,
                            ConyugueFechaNacimiento = x.ConyugueFechaNacimiento,
                            ConyugueGenero = x.ConyugueGenero,
                            ConyugueEdad = x.ConyugueEdad,
                            ValorMensual = x.ValorMensual,
                            ValorTrimestral = x.ValorTrimestral,
                            ValorSemestral = x.ValorSemestral,
                            ValorAnual = x.ValorAnual,
                            ValorContado = x.ValorContado,
                            NombrePlan = x.NombrePlan,
                            DescEstadoPlan = x.DescEstadoPlan,
                            Actividad = x.Actividad,
                            IdProducto = x.IdProducto,
                            Region = x.Region
                        });
                    }

                    if(isPool && !(plan_pool.Exists(t=>t.Cantidad.Equals(x.Cantidad) && t.IdCategoria.Equals(x.IdCategoria))))
                    {
                        plan_pool.Add(new CotizacionCategoriaPool
                        {
                            IdCategoria = x.IdCategoria,
                            Cantidad = x.Cantidad
                        });
                    }
                });

                var usuario = usuarioDao.ObtenerById(var_cotizacion.FirstOrDefault().IdUsuario);

                //Si es comparar planes debe imprimir todas las caracteristicas independiente del estado
                if (Comparar)
                {
                    //Si es pool obtener caracteristicas por seccion pool
                    if (isPool)
                    {
                        ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicasByPlan(var_cotizacion.FirstOrDefault().IdPlan);
                    }
                    else
                    {
                        ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicas(var_cotizacion.FirstOrDefault().IdPlan, beneficios.ToArray(), var_cotizacion.FirstOrDefault().TitularBeneficio, var_cotizacion.FirstOrDefault().TitularMaternidad);
                    }
                }
                else
                //Imprime solo las caracteristicas Activas del plan
                {
                    ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicasPdf(var_cotizacion.FirstOrDefault().IdPlan, beneficios.ToArray(), var_cotizacion.FirstOrDefault().TitularBeneficio, var_cotizacion.FirstOrDefault().TitularMaternidad, isPool);
                }

                ListaCaracteristicasPlan.ForEach(x => {
                    CaracteristicasP.Add(new SeccionCaracteristicasDto
                    {
                        IdSeccion = x.IdSeccion,
                        IdPlantillaC = x.IdPlantillaC,
                        Descripcion = x.Descripcion,
                        IdCaracteristica = x.IdCaracteristica,
                        IdPlan = x.IdPlan,
                        Valor = x.Valor,
                        AplicaMaternidad = x.AplicaMaternidad,
                        AplicaNSolo = x.AplicaNSolo,
                        Estado = x.Estado
                    });
                });

                ListaCaracteristicasPlan.ForEach(x => {
                    if (!CaracteristicasSeccion.Exists(y => y.IdSeccion.Equals(x.IdSeccion)))
                    {
                        CaracteristicasSeccion.Add(new SeccionBloqueDto
                        {
                            IdSeccion = x.IdSeccion,
                            Seccion = x.Seccion,
                            Plantillas = CaracteristicasP.FindAll(z => z.IdSeccion.Equals(x.IdSeccion))
                        });
                    }
                });

                //Consultar la observacion final del PDF.
                ListaConfiguraciones = configuracionesDto.ObtenerConfiguraciones();
                string observacionFinPdf = (ListaConfiguraciones.Find(c => c.DescConfiguracion == "Conf_Observaciones_Pdf").Descripcion);

                //Armo la respuesta de la consulta
                Log.Info("Arma formato respuesta SeccionCotizaciones");
                DatosCotizacion = new SeccionCotizaciones
                {
                    IdCotizacion = var_cotizacion.FirstOrDefault().IdCotizacion,
                    FechaCotizacion = var_cotizacion.FirstOrDefault().FechaCotizacion,
                    EstadoCotizacion = var_cotizacion.FirstOrDefault().Estado,
                    Cliente = var_cotizacion.FirstOrDefault().Cliente,
                    TitularEdad = var_cotizacion.FirstOrDefault().TitularEdad,
                    TitularBeneficio = var_cotizacion.FirstOrDefault().TitularBeneficio,
                    TitularGenero = var_cotizacion.FirstOrDefault().TitularGenero.ToString(),
                    TitularNacimiento = var_cotizacion.FirstOrDefault().TitularNacimiento,
                    TitularMaternidad = var_cotizacion.FirstOrDefault().TitularMaternidad,
                    ConyugueGenero = var_cotizacion.FirstOrDefault().ConyugueGenero.ToString(),
                    ConyugueEdad = var_cotizacion.FirstOrDefault().ConyugueEdad,
                    ConyugueFechaNacimiento = var_cotizacion.FirstOrDefault().ConyugueFechaNacimiento,
                    Dependientes = edad.ToArray(),
                    IdBeneficiosAdicionales = beneficios.ToArray(),
                    IdCatalogosBeneficios = catalogosBeneficios.ToArray(),
                    IdPlan = var_cotizacion.FirstOrDefault().IdPlan,
                    NombrePlan = var_cotizacion.FirstOrDefault().NombrePlan,
                    DescEstadoPlan = var_cotizacion.FirstOrDefault().DescEstadoPlan,
                    IdUsuario = var_cotizacion.FirstOrDefault().IdUsuario,
                    Agente = usuario.Apellidos + usuario.Nombres,
                    Telefono = usuario.Telefono,
                    Agencia = usuario.NombreAgencia,
                    Direccion = usuario.Direccion,
                    Region = var_cotizacion.FirstOrDefault().Region,
                    SeccionBloquesPlantillas = CaracteristicasSeccion,
                    TarifasResultado = new CalculaTarifasResultado
                    {
                        ValorMensual = var_cotizacion.FirstOrDefault().ValorMensual,
                        ValorTrimestral = var_cotizacion.FirstOrDefault().ValorTrimestral,
                        ValorSemestral = var_cotizacion.FirstOrDefault().ValorSemestral,
                        ValorAnual = var_cotizacion.FirstOrDefault().ValorAnual,
                        ValorContado = var_cotizacion.FirstOrDefault().ValorContado
                    },
                    Actividad = var_cotizacion.FirstOrDefault().Actividad,
                    CategoriasPools = plan_pool,
                    Conf_Observaciones_Pdf = observacionFinPdf,
                    IdProducto = var_cotizacion.FirstOrDefault().IdProducto
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return DatosCotizacion;
        }

    }
}