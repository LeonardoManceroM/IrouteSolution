using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{

    public class TarifasDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly TarifasDao tarifasDao = new TarifasDao();

        //Nueva estructura niño solo
        public int IdTarifaSolo { get; set; }
        public int IdPlan { get; set; }
        public List<RangosNSoloDto> Rangos { get; set; }


    public List<TiposTarifa> ObtenerTiposTarifas() { 
            List<TiposTarifa> ListaTiposTarifa = new List<TiposTarifa>();
        
            try
            {
                if (!isOnline) { 
                    ListaTiposTarifa.Add(new TiposTarifa { IdTipoTarifa = 1, DescTipoTarifa = "Por Categoria"});
                    ListaTiposTarifa.Add(new TiposTarifa { IdTipoTarifa = 2, DescTipoTarifa = "Por Rango de Edad" });
                    ListaTiposTarifa.Add(new TiposTarifa { IdTipoTarifa = 3, DescTipoTarifa = "Por Genero" });
                    
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaTiposTarifa = tarifasDao.ListaTiposTarifa();
                    Log.Info("Consulta OnLine");
                }
            }
            catch(Exception ex)
            {
                throw ex; 
            }
            return ListaTiposTarifa;
        }

        public List<TarifasCategoria> ObtenerTarifasCategoriaPlan(int idPlan)
        {
            List<TarifasCategoria> listaTarifasCategorias = new List<TarifasCategoria>();

            try
            {
                if (!isOnline)
                {
                    listaTarifasCategorias.Add(new TarifasCategoria { 
                        IdTarifaCat = 1, 
                        IdCategoria= 1,
                        DescCategoria = "Titular Solo",
                        IdPlan = 1, 
                        Rango1 = decimal.Parse("96.62"),
                        Rango2 = decimal.Parse("104.36"),
                        Rango3 = decimal.Parse("110.17"),
                        Rango4 = decimal.Parse("119.47"),
                        Rango5 = decimal.Parse("160.52"),
                        Rango6 = decimal.Parse("335.62"),
                        Rango7 = decimal.Parse("400.62"),
                        Rango8 = decimal.Parse("451.62"),
                        Rango9 = decimal.Parse("542.08"),
                        Rango10 = decimal.Parse("110.17"),
                        Rango11 = decimal.Parse("119.47"),
                        Rango12 = decimal.Parse("160.52"),
                        Rango13 = decimal.Parse("335.62"),
                        Rango14 = decimal.Parse("400.62"),
                        Rango15 = decimal.Parse("451.62")
                    });
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    listaTarifasCategorias = tarifasDao.ListaTarifasCategorias(idPlan);
                    Log.Info("Consulta OnLine");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaTarifasCategorias;
        }

        public int IngresoTarifasCategoria(List<TarifasCategoria> tarifasCategorias)
        {
            int respuesta = 1;
            if (!isOnline)
            {
                Log.Info("IngresoTarifasCategoria OffLine");
            }
            else
            {
                respuesta = tarifasDao.IngresoTarifasCategoria(tarifasCategorias);
                Log.Info("IngresoTarifasCategoria OnLine");
            }

            return respuesta;
        }

        public int ActualizaTarifaCategoria(List<TarifasCategoria> tarifasCategorias)
        {
            int retorno = 1;
            if (!isOnline)
            {
                Log.Info("ActualizaTarifaCategoria OffLine");
            }
            else
            {
                retorno = tarifasDao.ActualizaTarifasCategoria(tarifasCategorias);
                Log.Info("ActualizaTarifaCategoria OnLine");
            }

            return retorno;
        }

        public TarifasDto ObtenerTarifaNiñoSoloPlan(int idPlan)
        {
            TarifaNiñoSolo tarifaNiñoSolo;
            TarifasDto tarifasDto = new TarifasDto();
            List<RangosNSoloDto> ListaNSolosDto = new List<RangosNSoloDto>();

            try
            {
                if (!isOnline)
                {
                    tarifaNiñoSolo = new TarifaNiñoSolo
                    {
                        IdTarifaSolo = 1,
                        IdPlan = 1,
                        RangoN1 = decimal.Parse("77.62"),
                        RangoN2 = decimal.Parse("63.30")
                    };
                    Log.Info("ObtenerTarifaNiñoSoloPlan OffLine");
                }
                else
                {
                    tarifaNiñoSolo = tarifasDao.ConTarifasNiñoSolo(idPlan);
                    //Armar nueva estructura
                    ListaNSolosDto.Add(new RangosNSoloDto { Des = "Niños hasta 1 año", Valor = tarifaNiñoSolo.RangoN1, Id = "RangoN1" });
                    ListaNSolosDto.Add(new RangosNSoloDto { Des = "Niños de 2 a 17 años", Valor = tarifaNiñoSolo.RangoN2, Id = "RangoN2" });

                    tarifasDto = new TarifasDto
                    {
                        IdTarifaSolo = tarifaNiñoSolo.IdTarifaSolo,
                        IdPlan = tarifaNiñoSolo.IdPlan,
                        Rangos = ListaNSolosDto
                    };
                    Log.Info("ObtenerTarifaNiñoSoloPlan OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tarifasDto;
        }

        public int IngresaTarifaNiñoSoloPlan(TarifaNiñoSolo tarifaNiñoSolo)
        {
            int idTarifa = 1;
            if (!isOnline)
            {
                Log.Info("IngresaTarifaNiñoSoloPlan OffLine");
            }
            else
            {
                idTarifa = tarifasDao.IngresoTarifasNSolo(tarifaNiñoSolo);
                Log.Info("IngresaTarifaNiñoSoloPlan OnLine");
            }
            return idTarifa;
        }

        public int ActualizaNiñoSolo(TarifaNiñoSolo tarifaNiñoSolo)
        {
            int retorno = 1;
            if (!isOnline)
            {
                Log.Info("ActualizaNiñoSolo OffLine");
            }
            else
            {
                retorno = tarifasDao.ActualizaTarifasNSolo(tarifaNiñoSolo);
                Log.Info("ActualizaNiñoSolo OnLine");
            }
            return retorno;
        }

        public HeaderTarifa ObtenerCabecerasTarifasPlan(int idPlan)
        {
            HeaderTarifa headerTarifa = new HeaderTarifa();

            try
            {
                //if (!isOnline)
                //{
                    headerTarifa.RangoDependientes = new List<string>();
                    headerTarifa.RangoDependientes.Add("0 - 1");
                    headerTarifa.RangoDependientes.Add("2 - 17");

                    headerTarifa.RangoEdades = new List<string>();
                    headerTarifa.RangoEdades.Add("0 - 1");
                    headerTarifa.RangoEdades.Add("2 - 17");
                    headerTarifa.RangoEdades.Add("18 - 24");
                    headerTarifa.RangoEdades.Add("25 - 29");
                    headerTarifa.RangoEdades.Add("30 - 34");
                    headerTarifa.RangoEdades.Add("35 - 39");
                    headerTarifa.RangoEdades.Add("40 - 44");
                    headerTarifa.RangoEdades.Add("45 - 49");
                    headerTarifa.RangoEdades.Add("50 - 54");
                    headerTarifa.RangoEdades.Add("55 - 59");
                    headerTarifa.RangoEdades.Add("60 - 64");
                    headerTarifa.RangoEdades.Add("65 - 69");
                    headerTarifa.RangoEdades.Add("70 - 74");
                    headerTarifa.RangoEdades.Add("75 - 79");
                    headerTarifa.RangoEdades.Add("80");

                    Log.Info("ObtenerTarifaEdadPlan OffLine");
                //}
                //else
                //{
                //    tarifaEdad = tarifasDao.ConTarifasByEdades(idPlan);
                //    Log.Info("ObtenerTarifaEdadPlan OnLine");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return headerTarifa;
        }

        public TarifaEdad ObtenerTarifaEdadPlan(int idPlan)
        {
            TarifaEdad tarifaEdad;

            try
            {
                if (!isOnline)
                {
                    tarifaEdad = new TarifaEdad
                    {
                        IdTarifaEdad = 1,
                        IdPlan = 2,
                        RangoE1 = decimal.Parse("86.62"),
                        RangoE2 = decimal.Parse("74.30"),
                        RangoE3 = decimal.Parse("68.14"),
                        RangoE4 = decimal.Parse("68.62"),
                        RangoE5 = decimal.Parse("105.62"),
                        RangoE6 = decimal.Parse("125.62"),
                        RangoE7 = decimal.Parse("149.62"),
                        RangoE8 = decimal.Parse("177.62"),
                        RangoE9 = decimal.Parse("191.62"),
                        RangoE10 = decimal.Parse("219.62"),
                        RangoE11 = decimal.Parse("258.62"),
                        RangoE12 = decimal.Parse("301.62"),
                        RangoE13 = decimal.Parse("337.62"),
                        RangoE14 = decimal.Parse("377.62"),
                        RangoE15 = decimal.Parse("434.62")
                    };
                    Log.Info("ObtenerTarifaEdadPlan OffLine");
                }
                else
                {
                    tarifaEdad = tarifasDao.ConTarifasByEdades(idPlan);
                    Log.Info("ObtenerTarifaEdadPlan OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tarifaEdad;
        }

        public int IngresoTarifaEdad(TarifaEdad tarifaEdad)
        {
            int idTarifa = 1;
            if (!isOnline)
            {
                Log.Info("IngresoTarifaEdad OffLine");
            }
            else
            {
                idTarifa = tarifasDao.IngresoTarifasEdades(tarifaEdad);
                Log.Info("IngresoTarifaEdad OnLine");
            }
            return idTarifa;
        }

        public int ActualizaTarifaEdad(TarifaEdad tarifaEdad)
        {
            int retorno = 1;
            if (!isOnline)
            {
                Log.Info("ActualizaTarifaEdad OffLine");
            }
            else
            {
                retorno = tarifasDao.ActualizaTarifasEdades(tarifaEdad);
                Log.Info("ActualizaTarifaEdad OnLine");
            }
            return retorno;
        }

        public List<TarifaGenero> ObtenerTarifasGenerosPlan(int idPlan)
        {
            List<TarifaGenero> ListaTarifaGenero = new List<TarifaGenero>();

            try
            {
                if (!isOnline)
                {
                    ListaTarifaGenero.Add(new TarifaGenero
                    {
                        IdTarifaGen = 1,
                        Genero = "M",
                        IdPlan = 3,
                        RangoG1 = decimal.Parse("62.27"),
                        RangoG2 = decimal.Parse("62.27"),
                        RangoG3 = decimal.Parse("119.17"),
                        RangoG4 = decimal.Parse("159.47"),
                        RangoG5 = decimal.Parse("200.06"),
                        RangoG6 = decimal.Parse("532.62"),
                        RangoG7 = decimal.Parse("624.24"),
                        RangoG8 = decimal.Parse("119.17"),
                        RangoG9 = decimal.Parse("159.47"),
                        RangoG10 = decimal.Parse("200.06"),
                        RangoG11 = decimal.Parse("532.62"),
                        RangoG12 = decimal.Parse("624.24"),
                        RangoG13 = decimal.Parse("200.06"),
                        RangoG14 = decimal.Parse("532.62"),
                        RangoG15 = decimal.Parse("624.24")
                    });
                    ListaTarifaGenero.Add(new TarifaGenero
                    {
                        IdTarifaGen = 1,
                        Genero = "F",
                        IdPlan = 3,
                        RangoG1 = decimal.Parse("62.27"),
                        RangoG2 = decimal.Parse("62.27"),
                        RangoG3 = decimal.Parse("62.27")
                    });
                    ListaTarifaGenero.Add(new TarifaGenero
                    {
                        IdTarifaGen = 1,
                        Genero = "FM",
                        IdPlan = 3,
                        RangoG1 = decimal.Parse("93.27"),
                        RangoG2 = decimal.Parse("128.27"),
                        RangoG3 = decimal.Parse("138.17"),
                        RangoG4 = decimal.Parse("164.05"),
                        RangoG5 = decimal.Parse("200.74"),
                        RangoG6 = decimal.Parse("396.62"),
                        RangoG7 = decimal.Parse("444.63")
                    });
                    Log.Info("ObtenerTarifasGenerosPlan OffLine");
                }
                else
                {
                    ListaTarifaGenero = tarifasDao.ListaTarifaGeneros(idPlan);
                    Log.Info("ObtenerTarifasGenerosPlan OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaTarifaGenero;
        }

        public int IngresoTarifasGenero(List<TarifaGenero> tarifasGeneros)
        {
            int respuesta = 1;
            if (!isOnline)
            {
                Log.Info("IngresoTarifasGenero OffLine");
            }
            else
            {
                respuesta = tarifasDao.IngresoTarifasGenero(tarifasGeneros);
                Log.Info("IngresoTarifasGenero OnLine");
            }

            return respuesta;
        }

        public int ActualizaTarifasGenero(List<TarifaGenero> tarifasGeneros)
        {
            int retorno = 1;
            if (!isOnline)
            {
                Log.Info("ActualizaTarifasGenero OffLine");
            }
            else
            {
                retorno = tarifasDao.ActualizaTarifasGenero(tarifasGeneros);
                Log.Info("ActualizaTarifasGenero OnLine");
            }
            return retorno;
        }

        public List<TarifaGenDependiente> ObtenerTarifaDependientePlan(int idPlan)
        {
            List<TarifaGenDependiente> ListaTarifaDependiente = new List<TarifaGenDependiente>();
            try
            {
                if (!isOnline)
                {
                    ListaTarifaDependiente.Add(new TarifaGenDependiente
                    {
                        IdTarifa = 1,
                        IdPlan = 3,
                        TarifaDep = "H",
                        RangoD1 = decimal.Parse("80.94"),
                        RangoD2 = decimal.Parse("54.73")
                    });
                    ListaTarifaDependiente.Add(new TarifaGenDependiente
                    {
                        IdTarifa = 2,
                        IdPlan = 3,
                        TarifaDep = "N",
                        RangoD1 = decimal.Parse("80.94"),
                        RangoD2 = decimal.Parse("54.73")
                    });
                    Log.Info("ObtenerTarifaDependientePlan OffLine");
                }
                else
                {
                    ListaTarifaDependiente = tarifasDao.ListaTarifaGenDependientes(idPlan);
                    Log.Info("ObtenerTarifaDependientePlan OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaTarifaDependiente;
        }

        public int IngresoTarifaGDependientes(List<TarifaGenDependiente> tarifaGenDependientes)
        {
            int respuesta = 1;
            if (!isOnline)
            {
                Log.Info("IngresoTarifaGDependientes OffLine");
            }
            else
            {
                respuesta = tarifasDao.IngresoTarifasGenDependientes(tarifaGenDependientes);
                Log.Info("IngresoTarifaGDependientes OnLine");
            }
            return respuesta;
        }

        public int ActualizaTarifaGDependientes(List<TarifaGenDependiente> tarifaGenDependientes)
        {
            int retorno = 1;
            if (!isOnline)
            {
                Log.Info("ActualizaTarifaGDependientes OffLine");
            }
            else
            {
                retorno = tarifasDao.ActualizaTarifasGenDependientes(tarifaGenDependientes);
                Log.Info("ActualizaTarifaGDependientes OnLine");
            }
            return retorno;
        }

        public List<TarifaPool> ObtenerTarifasPool(int idPlan)
        {
            List<TarifaPool> ListaTarifasPool = new List<TarifaPool>();
            try
            {
                if (!isOnline)
                {
                    ListaTarifasPool.Add(new TarifaPool
                    {
                        IdTarifaPool = 1,
                        IdPlan = 4,
                        IdCategoria = 1,
                        CantidadMin = 5,
                        Valor = decimal.Parse("55.52")
                    });
                    ListaTarifasPool.Add(new TarifaPool
                    {
                        IdTarifaPool = 2,
                        IdPlan = 4,
                        IdCategoria = 3,
                        CantidadMin = 5,
                        Valor = decimal.Parse("111.03")
                    });
                    ListaTarifasPool.Add(new TarifaPool
                    {
                        IdTarifaPool = 3,
                        IdPlan = 4,
                        IdCategoria = 5,
                        CantidadMin = 5,
                        Valor = decimal.Parse("117.66")
                    });
                    ListaTarifasPool.Add(new TarifaPool
                    {
                        IdTarifaPool = 4,
                        IdPlan = 4,
                        IdCategoria = 1,
                        CantidadMin = 16,
                        Valor = decimal.Parse("49.97")
                    });
                    Log.Info("ObtenerTarifasPool OffLine");
                }
                else
                {
                    ListaTarifasPool = tarifasDao.ListaTarifasPool(idPlan);
                    Log.Info("ObtenerTarifasPool OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaTarifasPool;
        }

        public int IngresoTarifasPool(List<TarifaPool> tarifasPool)
        {
            int respuesta = 1;
            if (!isOnline)
            {
                Log.Info("IngresoTarifasPool OffLine");
            }
            else
            {
                respuesta = tarifasDao.IngresoTarifasPool(tarifasPool);
                Log.Info("IngresoTarifasPool OnLine");
            }

            return respuesta;
        }

        public int ActualizaTarifasPool(List<TarifaPool> tarifasPool)
        {
            int retorno = 1;
            if (!isOnline)
            {
                Log.Info("ActualizaTarifasPool OffLine");
            }
            else
            {
                retorno = tarifasDao.ActualizaTarifasPool(tarifasPool);
                Log.Info("ActualizaTarifasPool OnLine");
            }

            return retorno;
        }
    }
}