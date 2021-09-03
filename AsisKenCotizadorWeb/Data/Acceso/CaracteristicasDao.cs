using Data.Conexion;
using Data.Entidades;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace Data.Acceso
{
    public class CaracteristicasDao
    {
        ConSql sql = new ConSql();

        public List<Caracteristicas> ListaCaracteristicasByPlan(int idPlan)
        {
            List<Caracteristicas> ListaCaracteristicas = new List<Caracteristicas>();
            sql = new ConSql();
           
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_caracteristicasbyplan";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaCaracteristicas.Add(Caracteristicas.ConCaracteristicasByPlanDR(dataReader));
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
            return ListaCaracteristicas;
        }

        public int IngresoCaracteristicas(List<Caracteristicas> listaC)
        {
            int retorno = 0;
            sql = new ConSql();
            StringBuilder sb = new StringBuilder();
           
            try
            {
                XDocument xml = ListaCaracteristicasXML(listaC);
                sb.Append(xml);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_caracteristicas";
                //sql.Comando.Parameters.AddWithValue("lista_caract", sb.ToString());
                sql.Comando.Parameters.AddWithValue("lista_caract", NpgsqlDbType.Xml ,xml.ToString());

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

        private XDocument ListaCaracteristicasXML(List<Caracteristicas> listacaracteristicas)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);
            
            listacaracteristicas.ForEach(x =>
            {
                XElement XE_Caracteristicas = new XElement(xns + "Caracteristicas");
                XElement idcaracteristica = new XElement(xns + "idcaracteristica", x.IdCaracteristica);
                XElement idplantillac = new XElement(xns + "idplantillac", x.IdPlantillaC);
                XElement idplan = new XElement(xns + "idplan", x.IdPlan);
                XElement dato = new XElement(xns + "dato", x.Valor);
                XElement aplicamaternidad = new XElement(xns + "aplicamaternidad", x.AplicaMaternidad);
                XElement aplicansolo = new XElement(xns + "aplicansolo", x.AplicaNSolo);
                XElement estado = new XElement(xns + "estado", x.Estado);
                XE_Caracteristicas.Add(idcaracteristica);
                XE_Caracteristicas.Add(idplantillac);
                XE_Caracteristicas.Add(idplan);
                XE_Caracteristicas.Add(dato);
                XE_Caracteristicas.Add(aplicamaternidad);
                XE_Caracteristicas.Add(aplicansolo);
                XE_Caracteristicas.Add(estado);
                xRoot.Add(XE_Caracteristicas);
            });
            return xDoc;
        }

        public int ActualizaCaracteristicas(List<Caracteristicas> listaC)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaCaracteristicasXML(listaC);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_caracteristicas";
                sql.Comando.Parameters.AddWithValue("lista_caract", NpgsqlDbType.Xml, xml.ToString());

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

        public List<Caracteristicas> ListaCaracteristicas(int idPlan, int[] beneficiosAdicionales, bool titularbeneficio, bool maternidad)
        {
            List<Caracteristicas> ListaCaracteristicas = new List<Caracteristicas>();
            sql = new ConSql();

            try
            {
                XDocument xml = Caracteristicas.CaractetisticaBeneficioXML(beneficiosAdicionales);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_caracteristicasbyplan";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);
                sql.Comando.Parameters.AddWithValue("p_x_idbeneficios", NpgsqlDbType.Xml, xml.ToString());
                sql.Comando.Parameters.AddWithValue("p_titularbeneficio", titularbeneficio);
                sql.Comando.Parameters.AddWithValue("p_titularmaternidad", maternidad);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaCaracteristicas.Add(Caracteristicas.ConCaracteristicasByPlanDR(dataReader));
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
            return ListaCaracteristicas;
        }

        public List<Caracteristicas> ListaCaracteristicasPdf(int idPlan, int[] beneficiosAdicionales, bool titularbeneficio, bool maternidad, bool ispool)
        {
            List<Caracteristicas> ListaCaracteristicas = new List<Caracteristicas>();
            sql = new ConSql();

            try
            {
                XDocument xml = Caracteristicas.CaractetisticaBeneficioXML(beneficiosAdicionales);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_caracteristicaspdf";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);
                sql.Comando.Parameters.AddWithValue("p_ispool", ispool);
                sql.Comando.Parameters.AddWithValue("p_x_idbeneficios", NpgsqlDbType.Xml, xml.ToString());
                sql.Comando.Parameters.AddWithValue("p_titularbeneficio", titularbeneficio);
                sql.Comando.Parameters.AddWithValue("p_titularmaternidad", maternidad);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaCaracteristicas.Add(Caracteristicas.ConCaracteristicasByPlanDR(dataReader));
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
            return ListaCaracteristicas;
        }

        public List<Secciones> ListaSecciones()
        {
            List<Secciones> lSecciones = new List<Secciones>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_secciones";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        lSecciones.Add(Secciones.ConSeccionesDR(dataReader));
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
            return lSecciones;
        }

        public List<PlantillasCaracteristicas> ListaPlantillasCaract(int tipoPlantilla)
        {
            List<PlantillasCaracteristicas> lPlantillasCaracteristicas = new List<PlantillasCaracteristicas>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_plantillascaracteristicas";
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", tipoPlantilla); 

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        lPlantillasCaracteristicas.Add(PlantillasCaracteristicas.ConPlantillasCaracteristicasDR(dataReader));
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
            return lPlantillasCaracteristicas;
        }

        public int IngresoPlantillasCaract(PlantillasCaracteristicas PlantillasC)
        {
            int idPlantilla = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_plantillascaracteristicas";
                sql.Comando.Parameters.AddWithValue("p_idseccion", PlantillasC.IdSeccion);
                sql.Comando.Parameters.AddWithValue("p_descripcion", PlantillasC.Descripcion);
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", PlantillasC.TipoPlantilla);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        idPlantilla = int.Parse(dataReader[0].ToString());
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
            return idPlantilla;
        }

        public int ActualizaPlantillasCaract(PlantillasCaracteristicas PlantillasC)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_plantillascaracteristicas";
                sql.Comando.Parameters.AddWithValue("p_idseccion", PlantillasC.IdSeccion);
                sql.Comando.Parameters.AddWithValue("p_idplantillac", PlantillasC.IdPlantillaCaract);
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", PlantillasC.TipoPlantilla);
                sql.Comando.Parameters.AddWithValue("p_descripcion", PlantillasC.Descripcion);

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

        public int GuardarSeccionOrden(int IdSeccion, int Posicion, int TipoPlantilla)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_gua_seccionorden";
                sql.Comando.Parameters.AddWithValue("p_idseccion", IdSeccion);
                sql.Comando.Parameters.AddWithValue("p_posicion", Posicion);
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", TipoPlantilla);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        retorno = int.Parse(dataReader["retorno"].ToString());
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
            return retorno;
        }

        public List<SeccionCaracteristicas> ConsultarCaracteristicasOrden(int tipoPlantilla)
        {
            List<SeccionCaracteristicas> seccionesCaracteristicas = new List<SeccionCaracteristicas>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_caracteristicaorden";
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", tipoPlantilla);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        CaracteristicasSeccion caracteristica = new CaracteristicasSeccion();
                        int idSeccion = int.Parse(dataReader["idseccion"].ToString());
                        SeccionCaracteristicas seccion = seccionesCaracteristicas.Find(s => s.IdSeccion == idSeccion);
                        if(seccion == null)
                        {
                            seccion = new SeccionCaracteristicas();
                            seccion.IdSeccion = idSeccion;
                            seccion.Seccion = dataReader["seccion"].ToString();
                            seccion.Posicion = int.Parse(dataReader["orden"].ToString());
                            seccion.Charecteristics = new List<CaracteristicasSeccion>();
                            seccionesCaracteristicas.Add(seccion);
                        }
                        caracteristica.IdCharecteristics = int.Parse(dataReader["idcaracteristica"].ToString());
                        caracteristica.Charecteristics = dataReader["caracteristica"].ToString();
                        caracteristica.Posicion = int.Parse(dataReader["orden"].ToString());
                        caracteristica.status = int.Parse(dataReader["estado"].ToString());
                        caracteristica.isPool = int.Parse(dataReader["tipoplantilla"].ToString()) != 1;
                        seccion.Charecteristics.Add(caracteristica);
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
            return seccionesCaracteristicas;
        }

        public int GuardarCaracteristicaOrden(int IdSeccion, int IdCaracteristica, int Posicion, int Estado, int TipoPlanilla)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_gua_caracteristicaorden";
                sql.Comando.Parameters.AddWithValue("p_idseccion", IdSeccion);
                sql.Comando.Parameters.AddWithValue("p_idcaracteristica", IdCaracteristica);
                sql.Comando.Parameters.AddWithValue("p_posicion", Posicion);
                sql.Comando.Parameters.AddWithValue("p_estado", Estado);
                sql.Comando.Parameters.AddWithValue("p_tipoplantilla", TipoPlanilla);

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

        public List<CatalogoCaracteristica> ConsultarCatalogoCaracteristicas(int Estado)
        {
            List<CatalogoCaracteristica> secciones = new List<CatalogoCaracteristica>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_catalogocaracteristicas";
                sql.Comando.Parameters.AddWithValue("var_estado", Estado);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    CatalogoCaracteristica caracteristica;
                    while (dataReader.Read())
                    {
                        caracteristica = new CatalogoCaracteristica();
                        caracteristica.IdCaracteristica = int.Parse(dataReader["idcaracteristica"].ToString());
                        caracteristica.Caracteristica = dataReader["caracteristica"].ToString();
                        caracteristica.Estado = int.Parse(dataReader["estado"].ToString());
                        secciones.Add(caracteristica);
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
            return secciones;
        }

        public List<CatalogoCaracteristica> ConsultarCaracteristicasDisponibles(bool isPool)
        {
            List<CatalogoCaracteristica> secciones = new List<CatalogoCaracteristica>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_caracteristicasdisponibles";
                sql.Comando.Parameters.AddWithValue("var_is_pool", isPool);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    CatalogoCaracteristica caracteristica;
                    while (dataReader.Read())
                    {
                        caracteristica = new CatalogoCaracteristica();
                        caracteristica.IdCaracteristica = int.Parse(dataReader["idcaracteristica"].ToString());
                        caracteristica.Caracteristica = dataReader["caracteristica"].ToString();
                        caracteristica.Estado = int.Parse(dataReader["estado"].ToString());
                        secciones.Add(caracteristica);
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
            return secciones;
        }

        public int GuardarCatalogoCaracteristicas(CatalogoCaracteristica caracteristica)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_gua_catalogocaracteristica";
                sql.Comando.Parameters.AddWithValue("p_idcaracteristica", caracteristica.IdCaracteristica);
                sql.Comando.Parameters.AddWithValue("p_caracteristica", caracteristica.Caracteristica);
                sql.Comando.Parameters.AddWithValue("p_estado", caracteristica.Estado);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        retorno = int.Parse(dataReader[0].ToString());
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
            return retorno;
        }

        public List<Secciones> ConsultarCatalogoSecciones(int Estado)
        {
            List<Secciones> secciones = new List<Secciones>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_catalogosecciones";
                sql.Comando.Parameters.AddWithValue("var_estado", Estado);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    Secciones seccion;
                    while (dataReader.Read())
                    {
                        seccion = new Secciones();
                        seccion.IdSeccion = int.Parse(dataReader["idseccion"].ToString());
                        seccion.Seccion = dataReader["seccion"].ToString();
                        seccion.Estado = int.Parse(dataReader["estado"].ToString());
                        secciones.Add(seccion);
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
            return secciones;
        }

        public int GuardarCatalogoSecciones(Secciones seccion)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_gua_catalogoseccion";
                sql.Comando.Parameters.AddWithValue("p_idseccion", seccion.IdSeccion);
                sql.Comando.Parameters.AddWithValue("p_seccion", seccion.Seccion);
                sql.Comando.Parameters.AddWithValue("p_estado", seccion.Estado);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        retorno = int.Parse(dataReader[0].ToString());
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
            return retorno;
        }
    }
}