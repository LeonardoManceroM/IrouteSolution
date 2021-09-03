using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class BeneficiosAdiDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly BeneficiosAdicionalesDao beneficiosDao = new BeneficiosAdicionalesDao();

        public List<BeneficiosAdicionales> ObtenerBeneficios()
        {
            List<BeneficiosAdicionales> ListaBeneficiosAd = new List<BeneficiosAdicionales>();
            try
            {
                
                if (!isOnline)
                {
                    ListaBeneficiosAd.Add(new BeneficiosAdicionales
                    {
                        IdBeneficio = 1,
                        DescBeneficio = "Continuidad de cobertura por desempleo involuntario del titular o cónyuge afiliado",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 1,
                        DescPlan = "CURAE PLENUS",
                        Costo = 5,
                        Observacion = "en todo el plan"

                    });
                    ListaBeneficiosAd.Add(new BeneficiosAdicionales
                    {
                        IdBeneficio = 1,
                        DescBeneficio = "Cobertura de Enfermedades Graves nombradas y diagnosticadas en la vigencia del contrato y después de haber superado el período de carencia por afiliado, por accidente cubierto y ocurrido dentro de la cobertura del contrato solo para el titular. A partir de los 75 años la indemnización se reduce al 50%",
                        IdProducto = 1,
                        DescProducto = "Individual",
                        IdPlan = 1,
                        DescPlan = "CURAE PLENUS",
                        Costo = 5,
                        Observacion = "en todo el plan"
                    });
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaBeneficiosAd = beneficiosDao.ListaBeneficiosAdicionales();
                    Log.Info("Consulta OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        
        return ListaBeneficiosAd;

        }

        public int IngBeneficioAdicional(BeneficiosAdicionales beneficio)
        {
            int IdBeneficio = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("IngBeneficioAdicional OffLine");
                }
                else
                {
                    IdBeneficio = beneficiosDao.IngresoBeneficioAdicional(beneficio);
                    Log.Info("IngBeneficioAdicional OnLine");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return IdBeneficio;
        }

        public int ActualizaBeneficioAdicional(BeneficiosAdicionales beneficio)
        {
            int retorno = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("ActualizaBeneficioAdicional OffLine");
                }
                else
                {
                    retorno = beneficiosDao.ActualizaBeneficioAdicional(beneficio);
                    Log.Info("ActualizaBeneficioAdicional OnLine. " + retorno);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return retorno;
        }

        public List<BeneficioPlan> ObtenerBeneficioPlan(int IdPlan)
        {
            List<BeneficioPlan> ListaBeneficioPlan = new List<BeneficioPlan>();
            try { 

                if (!isOnline)
                {
                    ListaBeneficioPlan.Add(new BeneficioPlan
                    {
                        IdBeneficio = 1,
                        DescBeneficio = "Continuidad de cobertura por desempleo involuntario del titular o cónyuge afiliado",
                        Descripcion = "Si aplica"
                    });
                    ListaBeneficioPlan.Add(new BeneficioPlan
                    {
                        IdBeneficio = 1,
                        DescBeneficio = "Cobertura de Enfermedades Graves nombradas y diagnosticadas en la vigencia del contrato y después de haber superado el período de carencia por afiliado, por accidente cubierto y ocurrido dentro de la cobertura del contrato solo para el titular. A partir de los 75 años la indemnización se reduce al 50%",
                        Descripcion = "Si aplica"
                    });
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaBeneficioPlan = beneficiosDao.ListaBeneficiosAdicionalesByPlan(IdPlan);
                    Log.Info("Consulta ListaBeneficioPlan OnLine");
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return ListaBeneficioPlan;
        }
        public int InsertaCatalogoBeneficio(BeneficiosAdicionales beneficio)
        {
            int retorno = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("InsertaCatalogoBeneficio OffLine");
                }
                else
                {
                    retorno = beneficiosDao.IngresoCatalogoBeneficio(beneficio);
                    Log.Info("InsertaCatalogoBeneficio OnLine. " + retorno);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return retorno;
        }
        public int ActualizaCatalogoBeneficio(BeneficiosAdicionales beneficio)
        {
            int retorno = 1;
            try
            {
                if (!isOnline)
                {
                    Log.Info("ActualizaCatalogoBeneficio OffLine");
                }
                else
                {
                    retorno = beneficiosDao.ActualizaCatalogoBeneficio(beneficio);
                    Log.Info("ActualizaCatalogoBeneficio OnLine. " + retorno);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            return retorno;
        }

        public List<BeneficiosAdicionales> ConsultaCatalogosBeneficios()
        {
            List<BeneficiosAdicionales> ListaCatalogos = new List<BeneficiosAdicionales>();
            try
            {

                if (!isOnline)
                {
                    Log.Info("Consulta OffLine");
                }
                else
                {
                    ListaCatalogos = beneficiosDao.ListaCatalogosBeneficios();
                    Log.Info("Consulta ListaBeneficioPlan OnLine");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaCatalogos;
        }
    }
}