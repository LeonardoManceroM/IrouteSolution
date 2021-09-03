using Data.Conexion;
using Data.Entidades;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace Data.Acceso
{
    public class ConfiguracionesDao
    {
        ConSql sql = new ConSql();

        public List<Configuraciones> ListaConfiguraciones()
        {
            List<Configuraciones> listaConfiguraciones = new List<Configuraciones>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_configuraciones";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        listaConfiguraciones.Add(Configuraciones.ConsultaConfiguracionesDR(dataReader));
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
            return listaConfiguraciones;
        }

        public int IngresoConfiguracion(Configuraciones configuracion)
        {
            int idConfiguracion = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_configuraciones";
                sql.Comando.Parameters.AddWithValue("p_configuracion", configuracion.DescConfiguracion);
                sql.Comando.Parameters.AddWithValue("p_descripcion", configuracion.Descripcion);
                sql.Comando.Parameters.AddWithValue("p_valor", configuracion.Valor);
                sql.Comando.Parameters.AddWithValue("p_observacion", configuracion.Observacion);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        idConfiguracion = int.Parse(dataReader[0].ToString());
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
            return idConfiguracion;
        }

        private XDocument ListaConfiguracionesXML(List<Configuraciones> listaConfiguraciones)
        {
            XNamespace xns = "";
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDeclaration);
            XElement xRoot = new XElement(xns + "Root");
            xDoc.Add(xRoot);

            listaConfiguraciones.ForEach(x =>
            {
                XElement XE_Configuraciones = new XElement(xns + "Configuraciones");
                XElement idconfiguracion = new XElement(xns + "idconfiguracion", x.IdConfiguracion);
                XElement configuracion = new XElement(xns + "configuracion", x.DescConfiguracion);
                XElement descripcion = new XElement(xns + "descripcion", x.Descripcion);
                XElement valor = new XElement(xns + "valor", x.Valor);
                XElement observacion = new XElement(xns + "observacion", x.Observacion);
                XE_Configuraciones.Add(idconfiguracion);
                XE_Configuraciones.Add(configuracion);
                XE_Configuraciones.Add(descripcion);
                XE_Configuraciones.Add(valor);
                XE_Configuraciones.Add(observacion);
                xRoot.Add(XE_Configuraciones);
            });
            return xDoc;
        }

        public int ActualizaConfiguraciones(List<Configuraciones> ListConfiguraciones)
        {
            int retorno = 0;
            sql = new ConSql();

            try
            {
                XDocument xml = ListaConfiguracionesXML(ListConfiguraciones);
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_configuraciones";
                sql.Comando.Parameters.AddWithValue("lista_conf", NpgsqlDbType.Xml, xml.ToString());

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
