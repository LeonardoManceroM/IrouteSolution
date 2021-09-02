using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CotizadorWeb.Models
{
    public class CaracteristicasDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly CaracteristicasDao caracteristicasDao = new CaracteristicasDao();

        public List<SeccionBloqueDto> ObtenerCaracteristicasPlan(int idPlan/*, int[] coberturasAdicionales*/)
        {
            List<Caracteristicas> ListaCaracteristicasPlan = new List<Caracteristicas>();
            var CaracteristicasSeccion = new List<SeccionBloqueDto>();
            var CaracteristicasP = new List<SeccionCaracteristicasDto>();

            try
            {
                if (!isOnline)
                {
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Límite máximo por incapacidad por persona",
                        Valor = "$ 70.000,00 ",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Enfermedades crónicas y catastróficas sobrevinientes",
                        Valor = "Como cualquier incapacidad",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Cuarto y alimento diario en GHK",
                        Valor = "Habitación privada al 90%",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Cuarto y alimento diario libre elección",
                        Valor = "Al 90% hasta $200,00",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Maternidad y sus complicaciones para titular o cónyuge al 100% hasta",
                        Valor = "$ 2.500,00 ",
                        AplicaMaternidad = true,
                        AplicaNSolo = false,
                        Estado = 1
                    });

                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicasByPlan(idPlan);

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
                            CaracteristicasSeccion.Add(new SeccionBloqueDto {
                                IdSeccion = x.IdSeccion,
                                Seccion = x.Seccion,
                                Plantillas = CaracteristicasP.FindAll(z=> z.IdSeccion.Equals(x.IdSeccion))
                            });
                        }
                    });
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CaracteristicasSeccion;
        }

        public int IngresoCaracteristicas(List<Caracteristicas> datosCarateristica)
        {
            int respuesta = 1;

            if (!isOnline)
            {
                Log.Info("IngresoCaracteristicas OffLine");
            }
            else
            {
                respuesta = caracteristicasDao.IngresoCaracteristicas(datosCarateristica);
                Log.Info("IngresoCaracteristicas OnLine");
            }
            return respuesta;
        }

        public int ActualizaCaracteristicas(List<Caracteristicas> datosCarateristica)
        {
            int retorno = 1;

            if (!isOnline)
            {
                Log.Info("ActualizaCaracteristicas OffLine");
            }
            else
            {
                retorno = caracteristicasDao.ActualizaCaracteristicas(datosCarateristica);
                Log.Info("ActualizaCaracteristicas OnLine");
            }
            return retorno;
        }

        public List<Caracteristicas> ObtenerCaracteristicasNew(int idPlan/*, int[] coberturasAdicionales*/)
        {
            List<Caracteristicas> ListaCaracteristicasPlan = new List<Caracteristicas>();

            try
            {
                if (!isOnline)
                {
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Límite máximo por incapacidad por persona",
                        Valor = "$ 70.000,00 ",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Cuarto y alimento diario en GHK",
                        Valor = "Habitación privada al 90%",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Cuarto y alimento diario libre elección",
                        Valor = "Al 90% hasta $200,00",
                        AplicaMaternidad = false,
                        AplicaNSolo = false,
                        Estado = 1
                    });
                    ListaCaracteristicasPlan.Add(new Caracteristicas
                    {
                        IdCaracteristica = 1,
                        IdPlan = 1,
                        IdPlantillaC = 1,
                        Descripcion = "Maternidad y sus complicaciones para titular o cónyuge al 100% hasta",
                        Valor = "$ 2.500,00 ",
                        AplicaMaternidad = true,
                        AplicaNSolo = false,
                        Estado = 1
                    });

                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaCaracteristicasPlan = caracteristicasDao.ListaCaracteristicasByPlan(idPlan);

                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaCaracteristicasPlan;
        }

        public List<Secciones> ConSecciones()
        {
            List<Secciones> ListaSecciones = new List<Secciones>();

            try
            {
                if (!isOnline)
                {
                    Log.Info("ConSecciones OffLine");
                }
                else
                {
                    ListaSecciones = caracteristicasDao.ListaSecciones();
                    Log.Info("ConSecciones OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaSecciones;
        }

        public List<PlantillasCaracteristicas> ConPlantillasCaracteristicas(int tipoPlantilla)
        {
            List<PlantillasCaracteristicas> ListaPlantillasC = new List<PlantillasCaracteristicas>();

            try
            {
                if (!isOnline)
                {
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaPlantillasC = caracteristicasDao.ListaPlantillasCaract(tipoPlantilla);
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaPlantillasC;
        }

        public int IngresoPlantillasCaract(PlantillasCaracteristicas plantillasCarateristicas)
        {
            int respuesta = 1;

            if (!isOnline)
            {
                Log.Info("IngresoPlantillasCaract OffLine");
            }
            else
            {
                respuesta = caracteristicasDao.IngresoPlantillasCaract(plantillasCarateristicas);
                Log.Info("IngresoPlantillasCaract OnLine");
            }
            return respuesta;
        }

        public int ActualizaPlantillasCaract(PlantillasCaracteristicas plantillasCarateristicas)
        {
            int retorno = 1;

            if (!isOnline)
            {
                Log.Info("ActualizaPlantillasCaract OffLine");
            }
            else
            {
                retorno = caracteristicasDao.ActualizaPlantillasCaract(plantillasCarateristicas);
                Log.Info("ActualizaPlantillasCaract OnLine");
            }
            return retorno;
        }

        public List<SeccionCaracteristicas> ConsultarCaracteristicasSecciones(int TipoPlantilla)
        {
            List<SeccionCaracteristicas> seccionCaracteristicas = new List<SeccionCaracteristicas>();
            try
            {
                if (!isOnline)
                {
                    List<CaracteristicasSeccion> caracteristicas = new List<CaracteristicasSeccion>();
                    caracteristicas.Add(new CaracteristicasSeccion() {
                        IdCharecteristics = 2,
                        Charecteristics = "Tipo de Deducible",
                        Posicion = 2,
                        status = 1
                    });
                    caracteristicas.Add(new CaracteristicasSeccion()
                    {
                        IdCharecteristics = 1,
                        Charecteristics = "Monto maximo de cobertura",
                        Posicion = 1,
                        status = 1
                    });
                    seccionCaracteristicas.Add(new SeccionCaracteristicas() {
                        IdSeccion = 1,
                        Seccion = "",
                        Posicion = 1,
                        Charecteristics = caracteristicas
                    });
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    seccionCaracteristicas = caracteristicasDao.ConsultarCaracteristicasOrden(TipoPlantilla);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return seccionCaracteristicas;
        }

        public string GuardarCaracteristicasSecciones(List<SeccionCaracteristicas> seccionCaracteristicas)
        {
            StringBuilder response = new StringBuilder("");
            try
            {
                if (!isOnline)
                {
                    response.Append("SUCCESS");
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    int iSeccion = 1;
                    foreach(SeccionCaracteristicas sc in seccionCaracteristicas)
                    {
                        sc.Posicion = iSeccion;
                        if((sc.Charecteristics?.Count ?? 0) > 0)
                        {
                            int idSeccion = caracteristicasDao.GuardarSeccionOrden(sc.IdSeccion, sc.Posicion, sc.Charecteristics[0].isPool ? 3 : 1);
                            if (idSeccion > 0)
                            {
                                Log.Info("Se actualizo o ingreso el orden de la seccion con ID " + idSeccion);
                            }
                            else
                            {
                                if (response.Length > 0) response.Append("\n");
                                response.Append("No se pudo actualizar o ingresar el orden de la seccion con ID " + sc.IdSeccion);
                                Log.Warn("No se pudo actualizar o ingresar el orden de la seccion con ID " + sc.IdSeccion);
                            }
                            int iCaracteristica = 1;
                            foreach (CaracteristicasSeccion cs in sc.Charecteristics)
                            {
                                cs.Posicion = iCaracteristica;
                                int idcaracteristica = caracteristicasDao.GuardarCaracteristicaOrden(sc.IdSeccion, cs.IdCharecteristics, cs.Posicion, cs.status, cs.isPool ? 3 : 1);
                                if (idSeccion > 0)
                                {
                                    Log.Info("Se actualizo o ingreso el orden de la caracteristica con ID " + idcaracteristica);
                                }
                                else
                                {
                                    if (response.Length > 0) response.Append("\n");
                                    response.Append("No se pudo actualizar o ingresar el orden de la caracteristica con ID " + cs.IdCharecteristics);
                                    Log.Warn("No se pudo actualizar o ingresar el orden de la caracteristica con ID " + cs.IdCharecteristics);
                                }
                                iCaracteristica += 1;
                            }
                        }
                        iSeccion += 1;
                    }
                    if (response.Length > 0) response.Append("SUCCESS");
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response.ToString();
        }

        public List<CatalogoCaracteristica> ConsultarCatalogoCaracteristicas(int estado)
        {
            List<CatalogoCaracteristica> response;

            if (!isOnline)
            {
                response = new List<CatalogoCaracteristica>();
                response.Add(new CatalogoCaracteristica()
                {
                    IdCaracteristica = 1,
                    Caracteristica = "Caracteristica Prueba",
                    Estado = 0
                });
                response.Add(new CatalogoCaracteristica()
                {
                    IdCaracteristica = 2,
                    Caracteristica = "Caracteristica Activa",
                    Estado = 1
                });
                Log.Info("Consulta OffLine");
            }
            else
            {
                response = caracteristicasDao.ConsultarCatalogoCaracteristicas(estado);
            }
            return response;
        }

        public List<CatalogoCaracteristica> ConsultarCaracteristicasDisponibles(bool isPool)
        {
            List<CatalogoCaracteristica> response;

            if (!isOnline)
            {
                response = new List<CatalogoCaracteristica>();
                response.Add(new CatalogoCaracteristica()
                {
                    IdCaracteristica = 1,
                    Caracteristica = "Caracteristica Prueba",
                    Estado = 0
                });
                response.Add(new CatalogoCaracteristica()
                {
                    IdCaracteristica = 2,
                    Caracteristica = "Caracteristica Activa",
                    Estado = 1
                });
                Log.Info("Consulta OffLine");
            }
            else
            {
                response = caracteristicasDao.ConsultarCaracteristicasDisponibles(isPool);
            }
            return response;
        }

        public int GuardarCatalogoCaracteristicas(CatalogoCaracteristica caracteristica)
        {
            if (isOnline)
            {
                return caracteristicasDao.GuardarCatalogoCaracteristicas(caracteristica);
            }
            return 1;
        }

        public List<Secciones> ConsultarCatalogoSecciones(int estado)
        {
            List<Secciones> response;

            if (!isOnline)
            {
                response = new List<Secciones>();
                response.Add(new Secciones()
                {
                    IdSeccion = 1,
                    Seccion = "Prueba",
                    Estado = 0
                });
                response.Add(new Secciones()
                {
                    IdSeccion = 2,
                    Seccion = "Beneficios",
                    Estado = 1
                });
                response.Add(new Secciones()
                {
                    IdSeccion = 3,
                    Seccion = "Coberturas",
                    Estado = 1
                });
                Log.Info("Consulta OffLine");
            }
            else
            {
                response = caracteristicasDao.ConsultarCatalogoSecciones(estado);
            }
            return response;
        }

        public int GuardarCatalogoSecciones(Secciones seccion)
        {
            if (isOnline)
            {
                return caracteristicasDao.GuardarCatalogoSecciones(seccion);
            }
            return 1;
        }

    }
}