using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class CalculaTarifasDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private CalculaTarifas calculaValorTarifas;
        CalculaTarifasResultado tarifasResultado = new CalculaTarifasResultado();
        private readonly CalculaTarifasDao calculaTarifasDao = new CalculaTarifasDao();
        
        public CalculaTarifasResultado CalculaTarifas(CalculaTarifas calculaTarifas)
        {
            try
            {
                if (!isOnline)
                {
                    int[] a = { 5, 6, 12 };
                    int[] b = { 1 };

                    calculaValorTarifas = new CalculaTarifas
                    {
                        IdPlan = calculaTarifas.IdPlan,
                        TitularBeneficio = calculaTarifas.TitularBeneficio,
                        TitularEdad = calculaTarifas.TitularEdad,
                        TitularGenero = calculaTarifas.TitularGenero,
                        TitularMaternidad = calculaTarifas.TitularMaternidad,
                        ConyugueEdad = calculaTarifas.ConyugueEdad,
                        ConyugueGenero = calculaTarifas.ConyugueGenero,
                        Dependientes = calculaTarifas.Dependientes,
                        CoberturasAdicionales = calculaTarifas.CoberturasAdicionales
                    };

                    tarifasResultado = new CalculaTarifasResultado
                    {
                        ValorMensual = 287,
                        ValorTrimestral = 861,
                        ValorSemestral = 1722,
                        ValorAnual = 3445,
                        ValorContado = 3273
                    };
                }
                else
                {
                    tarifasResultado = calculaTarifasDao.Calcular(calculaTarifas);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tarifasResultado;
        }

        public CalculaTarifasResultado CalculaTarifasPool(List<TarifaPool> calculaTarifasPool)
        {
            List<TarifaPool> ListaCalculaTarifasPool = new List<TarifaPool>();

            try
            {
                if (!isOnline)
                {
                    ListaCalculaTarifasPool.Add(new TarifaPool{ IdPlan = 1, IdCategoria = 1, CantidadMin = 2 });

                    tarifasResultado = new CalculaTarifasResultado
                    {
                        ValorMensual = 287,
                        ValorTrimestral = 861,
                        ValorSemestral = 1722,
                        ValorAnual = 3445,
                        ValorContado = 3273
                    };
                }
                else
                {
                    tarifasResultado = calculaTarifasDao.CalcularPool(calculaTarifasPool);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tarifasResultado;
        }
    }
}