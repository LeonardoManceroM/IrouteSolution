using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class CategoriasDto
    {
        private static readonly bool isOnline = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly CategoriasDao categoriasDao = new CategoriasDao();

        public List<Categorias> ObtenerCategorias()
        {
            List<Categorias> ListaCategorias = new List<Categorias>();

            try
            {
                if (!isOnline)
                {
                    ListaCategorias.Add(new Categorias
                    {
                        IdCategoria = 1,
                        DescCategoria = "Titular Solo",
                        Descripcion = "Persona mayor de 18 años, hombre o mujer. Que no tendrá el beneficio de maternidad.",
                        AplicaBeneficio = false,
                        Hombre = true,
                        Mujer = true,
                        TitularDesde = 18,
                        //TitularHasta = 0,
                        Conyugue = false,
                        Maternidad = false,
                        Dependientes = false,
                        DependienteDesde = 0,
                        DependientesHasta = 0,
                        PersonasDesde = 1,
                        PersonasHasta = 1
                    });
                    ListaCategorias.Add(new Categorias
                    {
                        IdCategoria = 2,
                        DescCategoria = "Titular Solo con Maternidad ",
                        Descripcion = "Mujer sola mayor de 18 años y menor a 46 años.",
                        AplicaBeneficio = false,
                        Hombre = false,
                        Mujer = true,
                        TitularDesde = 18,
                        TitularHasta = 46,
                        Conyugue = false,
                        Maternidad = true,
                        Dependientes = false,
                        DependienteDesde = 0,
                        DependientesHasta = 0,
                        PersonasDesde = 1,
                        PersonasHasta = 1
                    });
                    Log.Info("Consulta Categoria Offline");
                }
                else 
                {
                    ListaCategorias = categoriasDao.ListaCategorias();
                    Log.Info("Consulta Categoria OnLine");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ListaCategorias;

        }
            
    }
}