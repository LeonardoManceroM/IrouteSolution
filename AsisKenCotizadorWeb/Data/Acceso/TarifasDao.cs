using Data.Conexion;
using Data.Entidades;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace Data.Acceso
{
    public class TarifasDao
    {
        ConSql sql = new ConSql();

        public List<TiposTarifa> ListaTiposTarifa()
        {
            List<TiposTarifa> listaTiposTarifas = new List<TiposTarifa>();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tipostarifas";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaTiposTarifas.Add(TiposTarifa.ConTiposTarifasDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return listaTiposTarifas;
        }

        public List<TarifasCategoria> ListaTarifasCategorias(int idPlan)
        {
            List<TarifasCategoria> listaTiposTarifas = new List<TarifasCategoria>();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tarifascategoriasbyplan";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaTiposTarifas.Add(TarifasCategoria.ConTarifasCategoriasByPlanDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return listaTiposTarifas;
        }

        private XDocument ListaTarifasByCategoriasXML(List<TarifasCategoria> ListaTarifasCategorias)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);

            ListaTarifasCategorias.ForEach(x =>
            {
                XElement XE_TarifasCategorias = new XElement(xns + "TarifasCategorias");
                XElement idtarifacat = new XElement(xns + "idtarifacat", x.IdTarifaCat);
                XElement idplan = new XElement(xns + "idplan", x.IdPlan);
                XElement idcategoria = new XElement(xns + "idcategoria", x.IdCategoria);
                //XElement categoria = new XElement(xns + "categoria", x.DescCategoria);
                XElement rango1 = new XElement(xns + "rango1", x.Rango1);
                XElement rango2 = new XElement(xns + "rango2", x.Rango2);
                XElement rango3 = new XElement(xns + "rango3", x.Rango3);
                XElement rango4 = new XElement(xns + "rango4", x.Rango4);
                XElement rango5 = new XElement(xns + "rango5", x.Rango5);
                XElement rango6 = new XElement(xns + "rango6", x.Rango6);
                XElement rango7 = new XElement(xns + "rango7", x.Rango7);
                XElement rango8 = new XElement(xns + "rango8", x.Rango8);
                XElement rango9 = new XElement(xns + "rango9", x.Rango9);
                XElement rango10 = new XElement(xns + "rango10", x.Rango10);
                XElement rango11 = new XElement(xns + "rango11", x.Rango11);
                XElement rango12 = new XElement(xns + "rango12", x.Rango12);
                XElement rango13 = new XElement(xns + "rango13", x.Rango13);
                XElement rango14 = new XElement(xns + "rango14", x.Rango14);
                XElement rango15 = new XElement(xns + "rango15", x.Rango15);
                XE_TarifasCategorias.Add(idtarifacat);
                XE_TarifasCategorias.Add(idplan);
                XE_TarifasCategorias.Add(idcategoria);
                //XE_TarifasCategorias.Add(categoria);
                XE_TarifasCategorias.Add(rango1);
                XE_TarifasCategorias.Add(rango2);
                XE_TarifasCategorias.Add(rango3);
                XE_TarifasCategorias.Add(rango4);
                XE_TarifasCategorias.Add(rango5);
                XE_TarifasCategorias.Add(rango6);
                XE_TarifasCategorias.Add(rango7);
                XE_TarifasCategorias.Add(rango8);
                XE_TarifasCategorias.Add(rango9);
                XE_TarifasCategorias.Add(rango10);
                XE_TarifasCategorias.Add(rango11);
                XE_TarifasCategorias.Add(rango12);
                XE_TarifasCategorias.Add(rango13);
                XE_TarifasCategorias.Add(rango14);
                XE_TarifasCategorias.Add(rango15);
                xRoot.Add(XE_TarifasCategorias);
            });
            return xDoc;
        }

        public int IngresoTarifasCategoria(List<TarifasCategoria> listaTarCategorias)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaTarifasByCategoriasXML(listaTarCategorias);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_tarifascategorias";
                sql.Comando.Parameters.AddWithValue("listatarcategorias", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public int ActualizaTarifasCategoria(List<TarifasCategoria> listaTarCategorias)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaTarifasByCategoriasXML(listaTarCategorias);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_tarifascategorias";
                sql.Comando.Parameters.AddWithValue("listatarcategorias", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public TarifaNiñoSolo ConTarifasNiñoSolo(int idPlan)
        {
            TarifaNiñoSolo tarifaNiñoSolo = new TarifaNiñoSolo();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tarifasnsolo";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        tarifaNiñoSolo= TarifaNiñoSolo.ConTarifasNSoloDR(dataReader);
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return tarifaNiñoSolo;
        }

        public int IngresoTarifasNSolo(TarifaNiñoSolo tarifasSolo)
        {
            int idTarifaSolo = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_tarifasnsolo";
                sql.Comando.Parameters.AddWithValue("p_idplan", tarifasSolo.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_rangon1", tarifasSolo.RangoN1);
                sql.Comando.Parameters.AddWithValue("p_rangon2", tarifasSolo.RangoN2);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        idTarifaSolo = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return idTarifaSolo;
        }

        public int ActualizaTarifasNSolo(TarifaNiñoSolo tarifasSolo)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_tarifasnsolo";
                sql.Comando.Parameters.AddWithValue("p_idtarifa", tarifasSolo.IdTarifaSolo);
                sql.Comando.Parameters.AddWithValue("p_idplan", tarifasSolo.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_rangon1", tarifasSolo.RangoN1);
                sql.Comando.Parameters.AddWithValue("p_rangon2", tarifasSolo.RangoN2);

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public TarifaEdad ConTarifasByEdades(int idPlan)
        {
            TarifaEdad tarifaEdad = new TarifaEdad();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tarifasedades";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        tarifaEdad = TarifaEdad.ConTarifasEdadesDR(dataReader);
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return tarifaEdad;
        }

        public int IngresoTarifasEdades(TarifaEdad tarifaEdades)
        {
            int idTarifaEdad = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_tarifasedades";
                sql.Comando.Parameters.AddWithValue("p_idplan", tarifaEdades.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_rangoe1", tarifaEdades.RangoE1);
                sql.Comando.Parameters.AddWithValue("p_rangoe2", tarifaEdades.RangoE2);
                sql.Comando.Parameters.AddWithValue("p_rangoe3", tarifaEdades.RangoE3);
                sql.Comando.Parameters.AddWithValue("p_rangoe4", tarifaEdades.RangoE4);
                sql.Comando.Parameters.AddWithValue("p_rangoe5", tarifaEdades.RangoE5);
                sql.Comando.Parameters.AddWithValue("p_rangoe6", tarifaEdades.RangoE6);
                sql.Comando.Parameters.AddWithValue("p_rangoe7", tarifaEdades.RangoE7);
                sql.Comando.Parameters.AddWithValue("p_rangoe8", tarifaEdades.RangoE8);
                sql.Comando.Parameters.AddWithValue("p_rangoe9", tarifaEdades.RangoE9);
                sql.Comando.Parameters.AddWithValue("p_rangoe10", tarifaEdades.RangoE10);
                sql.Comando.Parameters.AddWithValue("p_rangoe11", tarifaEdades.RangoE11);
                sql.Comando.Parameters.AddWithValue("p_rangoe12", tarifaEdades.RangoE12);
                sql.Comando.Parameters.AddWithValue("p_rangoe13", tarifaEdades.RangoE13);
                sql.Comando.Parameters.AddWithValue("p_rangoe14", tarifaEdades.RangoE14);
                sql.Comando.Parameters.AddWithValue("p_rangoe15", tarifaEdades.RangoE15);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        idTarifaEdad = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return idTarifaEdad;
        }

        public int ActualizaTarifasEdades(TarifaEdad tarifaEdades)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_tarifasedades";
                sql.Comando.Parameters.AddWithValue("p_idtarifaedad", tarifaEdades.IdTarifaEdad);
                sql.Comando.Parameters.AddWithValue("p_idplan", tarifaEdades.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_rangoe1", tarifaEdades.RangoE1);
                sql.Comando.Parameters.AddWithValue("p_rangoe2", tarifaEdades.RangoE2);
                sql.Comando.Parameters.AddWithValue("p_rangoe3", tarifaEdades.RangoE3);
                sql.Comando.Parameters.AddWithValue("p_rangoe4", tarifaEdades.RangoE4);
                sql.Comando.Parameters.AddWithValue("p_rangoe5", tarifaEdades.RangoE5);
                sql.Comando.Parameters.AddWithValue("p_rangoe6", tarifaEdades.RangoE6);
                sql.Comando.Parameters.AddWithValue("p_rangoe7", tarifaEdades.RangoE7);
                sql.Comando.Parameters.AddWithValue("p_rangoe8", tarifaEdades.RangoE8);
                sql.Comando.Parameters.AddWithValue("p_rangoe9", tarifaEdades.RangoE9);
                sql.Comando.Parameters.AddWithValue("p_rangoe10", tarifaEdades.RangoE10);
                sql.Comando.Parameters.AddWithValue("p_rangoe11", tarifaEdades.RangoE11);
                sql.Comando.Parameters.AddWithValue("p_rangoe12", tarifaEdades.RangoE12);
                sql.Comando.Parameters.AddWithValue("p_rangoe13", tarifaEdades.RangoE13);
                sql.Comando.Parameters.AddWithValue("p_rangoe14", tarifaEdades.RangoE14);
                sql.Comando.Parameters.AddWithValue("p_rangoe15", tarifaEdades.RangoE15);

                retorno =  sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public List<TarifaGenero> ListaTarifaGeneros(int idPlan)
        {
            List<TarifaGenero> listaTarifaGeneros = new List<TarifaGenero>();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tarifasgenerobyplan";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaTarifaGeneros.Add(TarifaGenero.ConTarifasGeneroByPlanDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return listaTarifaGeneros;
        }

        private XDocument ListaTarifasByGeneroXML(List<TarifaGenero> listaTarifaGeneros)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);

            listaTarifaGeneros.ForEach(x =>
            {
                XElement XE_TarifasGenero = new XElement(xns + "TarifasGenero");
                XElement idtarifagen = new XElement(xns + "idtarifagen", x.IdTarifaGen);
                XElement idplan = new XElement(xns + "idplan", x.IdPlan);
                XElement genero = new XElement(xns + "genero", x.Genero);
                XElement rangog1 = new XElement(xns + "rangog1", x.RangoG1);
                XElement rangog2 = new XElement(xns + "rangog2", x.RangoG2);
                XElement rangog3 = new XElement(xns + "rangog3", x.RangoG3);
                XElement rangog4 = new XElement(xns + "rangog4", x.RangoG4);
                XElement rangog5 = new XElement(xns + "rangog5", x.RangoG5);
                XElement rangog6 = new XElement(xns + "rangog6", x.RangoG6);
                XElement rangog7 = new XElement(xns + "rangog7", x.RangoG7);
                XElement rangog8 = new XElement(xns + "rangog8", x.RangoG8);
                XElement rangog9 = new XElement(xns + "rangog9", x.RangoG9);
                XElement rangog10 = new XElement(xns + "rangog10", x.RangoG10);
                XElement rangog11 = new XElement(xns + "rangog11", x.RangoG11);
                XElement rangog12 = new XElement(xns + "rangog12", x.RangoG12);
                XElement rangog13 = new XElement(xns + "rangog13", x.RangoG13);
                XElement rangog14 = new XElement(xns + "rangog14", x.RangoG14);
                XElement rangog15 = new XElement(xns + "rangog15", x.RangoG15);
                XE_TarifasGenero.Add(idtarifagen);
                XE_TarifasGenero.Add(idplan);
                XE_TarifasGenero.Add(genero);
                XE_TarifasGenero.Add(rangog1);
                XE_TarifasGenero.Add(rangog2);
                XE_TarifasGenero.Add(rangog3);
                XE_TarifasGenero.Add(rangog4);
                XE_TarifasGenero.Add(rangog5);
                XE_TarifasGenero.Add(rangog6);
                XE_TarifasGenero.Add(rangog7);
                XE_TarifasGenero.Add(rangog8);
                XE_TarifasGenero.Add(rangog9);
                XE_TarifasGenero.Add(rangog10);
                XE_TarifasGenero.Add(rangog11);
                XE_TarifasGenero.Add(rangog12);
                XE_TarifasGenero.Add(rangog13);
                XE_TarifasGenero.Add(rangog14);
                XE_TarifasGenero.Add(rangog15);
                xRoot.Add(XE_TarifasGenero);
            });
            return xDoc;
        }

        public int IngresoTarifasGenero(List<TarifaGenero> listaTarifaGeneros)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaTarifasByGeneroXML(listaTarifaGeneros);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_tarifasgenero";
                sql.Comando.Parameters.AddWithValue("lista_genero", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public int ActualizaTarifasGenero(List<TarifaGenero> listaTarGenero)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaTarifasByGeneroXML(listaTarGenero);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_tarifasgenero";
                sql.Comando.Parameters.AddWithValue("lista_genero", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public List<TarifaGenDependiente> ListaTarifaGenDependientes(int idPlan)
        {
            List<TarifaGenDependiente> listaTarifaGenDependientes = new List<TarifaGenDependiente>();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tarifasgenerodependientes";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaTarifaGenDependientes.Add(TarifaGenDependiente.ConTarifasGenDependientesDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return listaTarifaGenDependientes;
        }

        private XDocument ListaTarifasGByDependientesXML(List<TarifaGenDependiente> listaTarifasD)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);

            listaTarifasD.ForEach(x =>
            {
                XElement XE_TarifasDependientes = new XElement(xns + "TarifasDependientes");
                XElement idtarifad = new XElement(xns + "idtarifad", x.IdTarifa);
                XElement idplan = new XElement(xns + "idplan", x.IdPlan);
                XElement descripcion = new XElement(xns + "descripcion", x.TarifaDep);
                XElement rangod1 = new XElement(xns + "rangod1", x.RangoD1);
                XElement rangod2 = new XElement(xns + "rangod2", x.RangoD2);
                XE_TarifasDependientes.Add(idtarifad);
                XE_TarifasDependientes.Add(idplan);
                XE_TarifasDependientes.Add(descripcion);
                XE_TarifasDependientes.Add(rangod1);
                XE_TarifasDependientes.Add(rangod2);                
                xRoot.Add(XE_TarifasDependientes);
            });
            return xDoc;
        }

        public int IngresoTarifasGenDependientes(List<TarifaGenDependiente> listaTarifasDependientes)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaTarifasGByDependientesXML(listaTarifasDependientes);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_tarifasdependientes";
                sql.Comando.Parameters.AddWithValue("lista_dependientes", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public int ActualizaTarifasGenDependientes(List<TarifaGenDependiente> listaTarifasDependientes)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaTarifasGByDependientesXML(listaTarifasDependientes);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_tarifasdependientes";
                sql.Comando.Parameters.AddWithValue("lista_dependientes", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public List<TarifaPool> ListaTarifasPool(int idPlan)
        {
            List<TarifaPool> listaTarifasPool = new List<TarifaPool>();

            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_tarifaspool";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaTarifasPool.Add(TarifaPool.ConTarifasPoolByPlanDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return listaTarifasPool;
        }

        

        public int IngresoTarifasPool(List<TarifaPool> listaTarifasPools)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = TarifaPool.ListaTarifasPoolXML(listaTarifasPools);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_tarifaspool";
                sql.Comando.Parameters.AddWithValue("lista_pools", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public int ActualizaTarifasPool(List<TarifaPool> listaTarifasPools)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = TarifaPool.ListaTarifasPoolXML(listaTarifasPools);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_tarifaspool";
                sql.Comando.Parameters.AddWithValue("lista_pools", NpgsqlDbType.Xml, xml.ToString());

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

    }
}
